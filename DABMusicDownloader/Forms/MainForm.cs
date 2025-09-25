using DABMusicDownloader.Classes;
using DABMusicDownloader.Properties;

namespace DABMusicDownloader.Forms
{
    public partial class MainForm : Form
    {
        private static readonly HttpClient HttpClient = new();
        private static readonly Dictionary<string, Image> AlbumCoverCache = [];

        private List<SearchResponseTrack> _currentTracks = [];
        private List<SearchResponseAlbum> _currentAlbums = [];
        private List<SearchResponseAlbumTrack> _currentAlbumTracks = [];
        private string _currentSearchQuery = string.Empty;
        private Models.Search.SearchType _currentSearchType = Models.Search.SearchType.Track;
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
            _currentSearchType = (Models.Search.SearchType)cmbSearchType.SelectedIndex;
            _currentSearchOffset = 0;

            UpdateStatus(StatusType.Searching);

            _currentTracks.Clear();
            _currentAlbums.Clear();
            await SearchDABMusic();

            UpdateStatus(StatusType.Ready);
        }

        private async void dgvSearchResults_Scroll(object sender, ScrollEventArgs e)
        {
            if (dgvSearchResults.DisplayedRowCount(false) + dgvSearchResults.FirstDisplayedScrollingRowIndex < dgvSearchResults.RowCount) return;
            if (dgvSearchResults.DataSource is List<SearchResponseAlbumTrack>) return;

            UpdateStatus(StatusType.LoadingMore);

            await SearchDABMusic();

            UpdateStatus(StatusType.Ready);
        }

        private void dgvSearchResults_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var columnName = dgvSearchResults.Columns[e.ColumnIndex].Name;
            var sortOrder = GetSortOrder(e.ColumnIndex);

            if (dgvSearchResults.DataSource is List<SearchResponseTrack>)
            {
                var propertyInfo = typeof(SearchResponseTrack).GetProperty(columnName);
                if (propertyInfo == null) return;
                if (propertyInfo.Name == nameof(SearchResponseTrack.AlbumCover)) return;

                _currentTracks = sortOrder == SortOrder.Ascending
                    ? _currentTracks.OrderBy(x => propertyInfo.GetValue(x, null)).ToList()
                    : _currentTracks.OrderByDescending(x => propertyInfo.GetValue(x, null)).ToList();

                dgvSearchResults.DataSource = null;
                dgvSearchResults.DataSource = _currentTracks;
            }
            else if (dgvSearchResults.DataSource is List<SearchResponseAlbum>)
            {
                var propertyInfo = typeof(SearchResponseAlbum).GetProperty(columnName);
                if (propertyInfo == null) return;
                if (propertyInfo.Name == nameof(SearchResponseAlbum.AlbumCover)) return;

                _currentAlbums = sortOrder == SortOrder.Ascending
                    ? _currentAlbums.OrderBy(x => propertyInfo.GetValue(x, null)).ToList()
                    : _currentAlbums.OrderByDescending(x => propertyInfo.GetValue(x, null)).ToList();

                dgvSearchResults.DataSource = null;
                dgvSearchResults.DataSource = _currentAlbums;
            }
            else if (dgvSearchResults.DataSource is List<SearchResponseAlbumTrack>)
            {
                var propertyInfo = typeof(SearchResponseAlbumTrack).GetProperty(columnName);
                if (propertyInfo == null) return;
                if (propertyInfo.Name == nameof(SearchResponseAlbumTrack.AlbumCover)) return;

                _currentAlbumTracks = sortOrder == SortOrder.Ascending
                    ? _currentAlbumTracks.OrderBy(x => propertyInfo.GetValue(x, null)).ToList()
                    : _currentAlbumTracks.OrderByDescending(x => propertyInfo.GetValue(x, null)).ToList();

                dgvSearchResults.DataSource = null;
                dgvSearchResults.DataSource = _currentAlbumTracks;
            }

            FormatResultsGrid();
            dgvSearchResults.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = sortOrder;
        }

        private async void dgvSearchResults_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if (dgvSearchResults.DataSource is not List<SearchResponseAlbum>) return;
            if (dgvSearchResults.Rows[e.RowIndex].DataBoundItem is not SearchResponseAlbum searchResponseAlbum) return;

            var albumInfo = await GetAlbumInfo(searchResponseAlbum.AlbumId);
            if (albumInfo == null) return;

            dgvSearchResults.DataSource = null;
            _currentAlbumTracks.Clear();
            _currentAlbumTracks.AddRange(albumInfo.Tracks.Select(track => new SearchResponseAlbumTrack(track)));
            dgvSearchResults.DataSource = _currentAlbumTracks;

            FormatResultsGrid();

            btnBackToAlbums.Visible = true;
            lblSearchResults.Text = $@"{albumInfo.TrackCount} unique tracks loaded";
        }

        private void btnBackToAlbums_Click(object sender, EventArgs e)
        {
            if (dgvSearchResults.DataSource is not List<SearchResponseAlbumTrack>) return;

            dgvSearchResults.DataSource = null;
            dgvSearchResults.DataSource = _currentAlbums;

            FormatResultsGrid();

            btnBackToAlbums.Visible = false;
            lblSearchResults.Text = $@"{_currentAlbums.Count} unique albums loaded";
        }

        private void btnDownloadSelected_Click(object sender, EventArgs e)
        {
            UpdateStatus(StatusType.Downloading);



            UpdateStatus(StatusType.Ready);
        }

        private async Task<Models.Album.Album> GetAlbumInfo(string albumId)
        {
            if (string.IsNullOrWhiteSpace(albumId)) return null;

            var response = await DABMusicPlayerAPI.DownloadAsync(albumId);
            if (response == null || !string.IsNullOrWhiteSpace(response.Error))
            {
                MessageBox.Show(
                    string.IsNullOrWhiteSpace(response?.Error) == false
                        ? response.Error
                        : @"Something went wrong while executing the API request.",
                    @"API Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            return response.Album;
        }

        private async Task SearchDABMusic()
        {
            if (_searching) return;

            _searching = true;
            dgvSearchResults.Enabled = false;

            var response = await DABMusicPlayerAPI.SearchAsync(_currentSearchQuery, _currentSearchType, Settings.Default.SearchResultLimit, _currentSearchOffset);
            if (response == null || !string.IsNullOrWhiteSpace(response.Error))
            {
                UpdateStatus(StatusType.Ready);

                MessageBox.Show(
                    string.IsNullOrWhiteSpace(response?.Error) == false
                        ? response.Error
                        : @"Something went wrong while executing the API request.",
                    @"API Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            object dataSource = null;
            dgvSearchResults.DataSource = null;
            switch (_currentSearchType)
            {
                case Models.Search.SearchType.Track when response.Tracks.Count != 0:
                    _currentTracks.AddRange(response.Tracks.Select(track => new SearchResponseTrack(track)));
                    dataSource = _currentTracks;
                    break;
                case Models.Search.SearchType.Album when response.Albums.Count != 0:
                    _currentAlbums.AddRange(response.Albums.Select(album => new SearchResponseAlbum(album)));
                    dataSource = _currentAlbums;
                    break;
            }
            dgvSearchResults.DataSource = dataSource;

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

            if (response.Pagination.HasMore)
            {
                _currentSearchOffset = response.Pagination.Offset + response.Pagination.Returned;
                lblSearchResults.Text = _currentSearchType switch
                {
                    Models.Search.SearchType.Track when response.Tracks.Count != 0 => $@"{_currentSearchOffset} unique tracks loaded",
                    Models.Search.SearchType.Album when response.Albums.Count != 0 => $@"{_currentSearchOffset} unique albums loaded",
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

        private void FormatResultsGrid()
        {
            var columns = dgvSearchResults.Columns;
            if (columns.Count == 0) return;

            var trackIdColumn = columns[nameof(SearchResponseTrack.TrackId)];
            if (trackIdColumn != null) trackIdColumn.Visible = false;

            var albumIdColumn = columns[nameof(SearchResponseAlbum.AlbumId)];
            if (albumIdColumn != null) albumIdColumn.Visible = false;

            if (columns[nameof(SearchResponseAlbum.AlbumCover)] is DataGridViewImageColumn albumCoverColumn)
            {
                albumCoverColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
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

        private class SearchResponseTrack(Models.Search.Track track)
        {
            public int TrackId => track.Id;
            public string AlbumId => track.AlbumId;
            public Image AlbumCover
            {
                get
                {
                    var albumId = track.AlbumId;
                    var albumCover = track.AlbumCover;
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
            public string Title => track.Title;
            public string Artist => track.Artist;
            public string Album => track.AlbumTitle;
            public string Explicit => track.ParentalWarning == true ? "True" : "False";
            public string AudioQuality => $"{track.AudioQuality.MaximumBitDepth}bit / {track.AudioQuality.MaximumSamplingRate}kHz";
            public string HiRes => track.AudioQuality.IsHiRes == true ? "True" : "False";
        }

        private class SearchResponseAlbum(Models.Search.Album album)
        {
            public string AlbumId => album.Id;
            public Image AlbumCover
            {
                get
                {
                    var albumId = album.Id;
                    var albumCover = album.Cover;
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
            public string Album => album.Title;
            public string Artist => album.Artist;
            public int TrackCount => album.TrackCount;
            public string AudioQuality => $"{album.AudioQuality.MaximumBitDepth}bit / {album.AudioQuality.MaximumSamplingRate}kHz";
            public string HiRes => album.AudioQuality.IsHiRes == true ? "True" : "False";
        }

        private class SearchResponseAlbumTrack(Models.Album.Track track)
        {
            public string TrackId => track.Id;
            public string AlbumId => track.AlbumId;
            public Image AlbumCover
            {
                get
                {
                    var albumId = track.AlbumId;
                    var albumCover = track.AlbumCover;
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
            public string Title => track.Title;
            public string Artist => track.Artist;
            public string Album => track.AlbumTitle;
            public string AudioQuality => $"{track.AudioQuality.MaximumBitDepth}bit / {track.AudioQuality.MaximumSamplingRate}kHz";
            public string HiRes => track.AudioQuality.IsHiRes == true ? "True" : "False";
        }
    }
}
