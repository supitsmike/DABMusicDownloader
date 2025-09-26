using QobuzMusicDownloader.Properties;
using QobuzMusicDownloader.QobuzDL;
using QobuzMusicDownloader.QobuzDL.Album;
using QobuzMusicDownloader.QobuzDL.Core;
using QobuzMusicDownloader.QobuzDL.Track;

namespace QobuzMusicDownloader.Forms
{
    public partial class MainForm : Form
    {
        private static readonly HttpClient HttpClient = new();
        private static readonly Dictionary<string, Image> AlbumCoverCache = [];

        private List<SearchResponseItem> _currentItems = [];
        private List<SearchResponseItem> _currentAlbumItems = [];
        private string _currentSearchQuery = string.Empty;
        private SearchFilter _currentSearchType = SearchFilter.Albums;
        private int _currentSearchOffset;
        private bool _searching;

        public MainForm()
        {
            InitializeComponent();

            cmbSearchType.SelectedIndex = 0;
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SettingsForm().ShowDialog(this);
        }

        private void txtSearchQuery_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter || _searching) return;

            btnSearch.PerformClick();

            e.Handled = true;
            e.SuppressKeyPress = true;
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchQuery.Text) || _searching) return;

            _currentSearchQuery = txtSearchQuery.Text;
            _currentSearchType = (SearchFilter)cmbSearchType.SelectedIndex;
            _currentSearchOffset = 0;

            UpdateStatus(StatusType.Searching);

            _currentItems.Clear();
            await SearchQobuzDL();

            UpdateStatus(StatusType.Ready);
        }

        private async void dgvSearchResults_Scroll(object sender, ScrollEventArgs e)
        {
            if (dgvSearchResults.DisplayedRowCount(false) + dgvSearchResults.FirstDisplayedScrollingRowIndex < dgvSearchResults.RowCount) return;
            if (_currentAlbumItems.Count != 0) return;

            UpdateStatus(StatusType.LoadingMore);

            await SearchQobuzDL();

            UpdateStatus(StatusType.Ready);
        }

        private void dgvSearchResults_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var columnName = dgvSearchResults.Columns[e.ColumnIndex].Name;
            var sortOrder = GetSortOrder(e.ColumnIndex);

            if (_currentAlbumItems.Count != 0)
            {
                var propertyInfo = typeof(SearchResponseItem).GetProperty(columnName);
                if (propertyInfo == null) return;
                if (propertyInfo.Name == nameof(SearchResponseItem.AlbumCover)) return;

                _currentAlbumItems = sortOrder == SortOrder.Ascending
                    ? _currentAlbumItems.OrderBy(x => propertyInfo.GetValue(x, null)).ToList()
                    : _currentAlbumItems.OrderByDescending(x => propertyInfo.GetValue(x, null)).ToList();

                dgvSearchResults.DataSource = null;
                dgvSearchResults.DataSource = _currentAlbumItems;

                FormatResultsGrid(true);
            }
            else if (_currentItems.Count != 0)
            {
                var propertyInfo = typeof(SearchResponseItem).GetProperty(columnName);
                if (propertyInfo == null) return;
                if (propertyInfo.Name == nameof(SearchResponseItem.AlbumCover)) return;

                _currentItems = sortOrder == SortOrder.Ascending
                    ? _currentItems.OrderBy(x => propertyInfo.GetValue(x, null)).ToList()
                    : _currentItems.OrderByDescending(x => propertyInfo.GetValue(x, null)).ToList();

                dgvSearchResults.DataSource = null;
                dgvSearchResults.DataSource = _currentItems;

                FormatResultsGrid();
            }

            dgvSearchResults.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = sortOrder;
        }

        private async void dgvSearchResults_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if (dgvSearchResults.DataSource is not List<SearchResponseItem>) return;
            if (dgvSearchResults.Rows[e.RowIndex].DataBoundItem is not SearchResponseItem searchResponseItem) return;

            var response = await QobuzDLAPI.GetAlbumAsync(searchResponseItem.AlbumId);
            if (response == null || response.Data == null) return;

            dgvSearchResults.DataSource = null;
            _currentAlbumItems.Clear();
            _currentAlbumItems.AddRange(response.Data.Tracks.Items.Select(track => new SearchResponseItem(track, searchResponseItem.Album)));
            dgvSearchResults.DataSource = _currentAlbumItems;

            FormatResultsGrid(true);

            btnBackToAlbums.Visible = true;
            lblSearchResults.Text = $@"{response.Data.TracksCount} unique tracks loaded";
        }

        private void dgvSearchResults_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.XButton1) == 0) return;

            btnBackToAlbums.PerformClick();
        }

        private void btnBackToAlbums_Click(object sender, EventArgs e)
        {
            _currentAlbumItems.Clear();
            dgvSearchResults.DataSource = null;
            dgvSearchResults.DataSource = _currentItems;

            FormatResultsGrid();

            btnBackToAlbums.Visible = false;
            lblSearchResults.Text = $@"{_currentItems.Count} unique albums loaded";
        }

        private async void btnDownloadSelected_Click(object sender, EventArgs e)
        {
            if (dgvSearchResults.SelectedRows.Count == 0) return;
            if (dgvSearchResults.SelectedRows[0].DataBoundItem is not SearchResponseItem searchResponseItem) return;

            UpdateStatus(StatusType.Downloading);

            var albumResponse = await QobuzDLAPI.GetAlbumAsync(searchResponseItem.AlbumId);
            if (albumResponse == null || albumResponse.Data == null)
            {
                UpdateStatus(StatusType.Ready);
                return;
            }

            var trackList = new List<QobuzTrack>();
            if (searchResponseItem.TrackId == null)
            {
                trackList.AddRange(albumResponse.Data.Tracks.Items);
            }
            else
            {
                trackList.Add(searchResponseItem.Track);
            }


            var folderPath = $"{Settings.Default.DownloadLocation}\\{searchResponseItem.Album?.Artist.Name}\\{searchResponseItem.Album?.Title}";
            Directory.CreateDirectory(folderPath);

            prgDownload.Value = 0;
            prgDownload.Maximum = trackList.Count;

            var tasks = new List<Task>();
            var semaphore = new SemaphoreSlim(Settings.Default.ConcurrentDownloads);
            for (var i = 0; i < trackList.Count; i++)
            {
                var track = trackList[i];
                tasks.Add(Task.Run(async () =>
                {
                    await semaphore.WaitAsync();
                    try
                    {
                        var downloadResponse = await QobuzDLAPI.DownloadMusicAsync(track.Id, Settings.Default.DownloadQuality);
                        if (downloadResponse == null || downloadResponse.Data == null) return;

                        if (string.IsNullOrWhiteSpace(downloadResponse.Data.Url))
                        {
                            Invoke(() =>
                            {
                                MessageBox.Show(@"Failed to get track stream... Skipping song.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                prgDownload.Value++;
                            });
                            return;
                        }

                        using var httpClient = new HttpClient();
                        await using var stream = await httpClient.GetStreamAsync(downloadResponse.Data.Url);

                        var index = albumResponse.Data.Tracks.Items.FindIndex(x => x.Id == track.Id) + 1;
                        var extension = Settings.Default.DownloadQuality == (int)AudioQuality.High ? "mp3" : "flac";

                        var fileName = $"{index}. {track.Title}.{extension}";
                        fileName = string.Join("_", fileName.Split(Path.GetInvalidFileNameChars())).Trim();
                        var filePath = $"{folderPath}\\{fileName}";

                        await using var fileStream = new FileStream(filePath, FileMode.OpenOrCreate);
                        await stream.CopyToAsync(fileStream);

                        Invoke(() =>
                        {
                            prgDownload.Value++;
                        });
                    }
                    finally
                    {
                        semaphore.Release();
                    }
                }));
            }

            await Task.WhenAll(tasks);
            UpdateStatus(StatusType.Ready);
        }

        private async Task SearchQobuzDL()
        {
            if (_searching) return;
            _searching = true;
            dgvSearchResults.Enabled = false;

            var response = await QobuzDLAPI.GetMusicAsync(_currentSearchQuery, _currentSearchOffset);
            if (response == null || response.Data == null)
            {
                UpdateStatus(StatusType.Ready);
                return;
            }

            dgvSearchResults.DataSource = null;
            if (_currentSearchType == SearchFilter.Albums)
            {
                _currentItems.AddRange(response.Data.Albums.Items.Select(album => new SearchResponseItem(album)));
            }
            else if (_currentSearchType == SearchFilter.Tracks)
            {
                _currentItems.AddRange(response.Data.Tracks.Items.Select(track => new SearchResponseItem(track)));
            }
            dgvSearchResults.DataSource = _currentItems;


            FormatResultsGrid();
            if (dgvSearchResults.RowCount > 0)
            {
                var rowIndex = _currentSearchOffset != 0 ? _currentSearchOffset - 1 : 0;
                if (rowIndex >= 0 && rowIndex < dgvSearchResults.RowCount)
                {
                    dgvSearchResults.FirstDisplayedScrollingRowIndex = rowIndex;
                    dgvSearchResults.PerformLayout();
                }
            }

            if (response.Data.Tracks.Offset < response.Data.Tracks.Total)
            {
                _currentSearchOffset = response.Data.Tracks.Offset + response.Data.Tracks.Limit;
                lblSearchResults.Text = _currentSearchType switch
                {
                    SearchFilter.Tracks when response.Data.Tracks.Items.Count != 0 => $@"{_currentSearchOffset} unique tracks loaded",
                    SearchFilter.Albums when response.Data.Albums.Items.Count != 0 => $@"{_currentSearchOffset} unique albums loaded",
                    _ => string.Empty
                };
            }

            dgvSearchResults.Enabled = true;
            _searching = false;
        }

        private SortOrder GetSortOrder(int columnIndex)
        {
            return dgvSearchResults.Columns[columnIndex].HeaderCell.SortGlyphDirection is SortOrder.None or SortOrder.Descending
                ? SortOrder.Ascending
                : SortOrder.Descending;
        }

        private void FormatResultsGrid(bool albumItems = false)
        {
            var columns = dgvSearchResults.Columns;
            if (columns.Count == 0) return;

            var trackColumn = columns[nameof(SearchResponseItem.Track)];
            if (trackColumn != null) trackColumn.Visible = false;

            var trackIdColumn = columns[nameof(SearchResponseItem.TrackId)];
            if (trackIdColumn != null) trackIdColumn.Visible = false;

            var albumColumn = columns[nameof(SearchResponseItem.Album)];
            if (albumColumn != null) albumColumn.Visible = false;

            var albumIdColumn = columns[nameof(SearchResponseItem.AlbumId)];
            if (albumIdColumn != null) albumIdColumn.Visible = false;

            if (columns[nameof(SearchResponseItem.AlbumCover)] is DataGridViewImageColumn albumCoverColumn)
            {
                albumCoverColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            }

            if (_currentSearchType == SearchFilter.Tracks || albumItems)
            {
                var trackCountColumn = columns[nameof(SearchResponseItem.TrackCount)];
                if (trackCountColumn != null) trackCountColumn.Visible = false;
            }
            else if (_currentSearchType == SearchFilter.Albums)
            {
                var titleColumn = columns[nameof(SearchResponseItem.Title)];
                if (titleColumn != null) titleColumn.Visible = false;
            }

            dgvSearchResults.AutoResizeColumns();
        }

        private enum StatusType
        {
            Ready,
            Searching,
            LoadingMore,
            Downloading
        }

        private void UpdateStatus(StatusType statusType)
        {
            string message;
            switch (statusType)
            {
                case StatusType.Searching:
                    btnSearch.Enabled = false;
                    btnDownloadSelected.Enabled = false;
                    lblStatusSplash.Visible = true;
                    message = @"Searching...";
                    break;
                case StatusType.LoadingMore:
                    btnSearch.Enabled = false;
                    btnDownloadSelected.Enabled = false;
                    lblStatusSplash.Visible = true;
                    message = @"Loading More...";
                    break;
                case StatusType.Downloading:
                    btnSearch.Enabled = false;
                    btnDownloadSelected.Enabled = false;
                    lblStatusSplash.Visible = true;
                    message = @"Downloading...";
                    break;
                case StatusType.Ready:
                default:
                    btnSearch.Enabled = true;
                    btnDownloadSelected.Enabled = true;
                    lblStatusSplash.Visible = false;
                    message = @"Ready";
                    break;
            }

            lblStatusMessage.Text = message;
            lblStatusSplash.Text = message;
        }

        private class SearchResponseItem
        {
            private enum ItemType { Track, Album }
            private ItemType Type { get; }

            public readonly QobuzTrack? Track;
            public readonly QobuzAlbum? Album;

            public SearchResponseItem(QobuzTrack track)
            {
                Type = ItemType.Track;
                Track = track;
                Album = track.Album;
            }

            public SearchResponseItem(QobuzAlbum album)
            {
                Type = ItemType.Album;
                Album = album;
            }

            public SearchResponseItem(QobuzTrack track, QobuzAlbum album)
            {
                Type = ItemType.Track;
                Track = track;
                Album = album;
            }

            public int? TrackId => Type == ItemType.Track ? Track?.Id : null;
            public string AlbumId => Album?.Id;
            public Image AlbumCover
            {
                get
                {
                    var albumId = Album?.Id;
                    var albumCover = Album?.Image.Small;
                    if (string.IsNullOrWhiteSpace(albumId) || string.IsNullOrWhiteSpace(albumCover)) return null;

                    try
                    {
                        var image = AlbumCoverCache.GetValueOrDefault(albumId);
                        if (image != null) return image;

                        using var stream = HttpClient.GetStreamAsync(albumCover).GetAwaiter().GetResult();
                        AlbumCoverCache[albumId] = Image.FromStream(stream);

                        return AlbumCoverCache.GetValueOrDefault(albumId);
                    }
                    catch
                    {
                        return null;
                    }
                }
            }
            public string Title => Type == ItemType.Track ? Track?.Title : null;
            public string AlbumName => Album?.Version == null ? Album?.Title : $"{Album?.Title} ({Album?.Version})";
            public string Artist => Album?.Artist.Name;
            public string TrackCount => Type == ItemType.Album ? $"{Album?.TracksCount} tracks" : null;
            public string Explicit
            {
                get
                {
                    var parentalWarning = Track?.ParentalWarning ?? Album?.ParentalWarning;
                    return parentalWarning == true ? "True" : "False";
                }
            }
            public string ReleaseDate => Album?.ReleaseDateOriginal;
            public string AudioQuality
            {
                get
                {
                    var maximumBitDepth = Track?.MaximumBitDepth ?? Album?.MaximumBitDepth;
                    var maximumSamplingRate = Track?.MaximumSamplingRate ?? Album?.MaximumSamplingRate;
                    return $"{maximumBitDepth}-bit / {maximumSamplingRate} kHz";
                }
            }
            public string HiRes
            {
                get
                {
                    var hiRes = Track?.HiRes ?? Album?.HiRes;
                    return hiRes == true ? "True" : "False";
                }
            }
        }
    }
}
