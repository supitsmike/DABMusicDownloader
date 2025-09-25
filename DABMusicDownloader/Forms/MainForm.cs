using DABMusicDownloader.Classes;
using DABMusicDownloader.Models.Search;
using DABMusicDownloader.Properties;

namespace DABMusicDownloader.Forms
{
    public partial class MainForm : Form
    {
        private static readonly HttpClient HttpClient = new();
        private static readonly Dictionary<string, Image> AlbumCoverCache = [];
        private readonly List<SearchResponseTrack> _currentTracks = [];
        private readonly List<SearchResponseAlbum> _currentAlbums = [];

        private string _currentSearchQuery = string.Empty;
        private SearchType _currentSearchType = SearchType.Track;
        private int _currentSearchOffset;

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
            if (e.KeyCode != Keys.Enter) return;

            btnSearch.PerformClick();

            e.Handled = true;
            e.SuppressKeyPress = true;
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchQuery.Text)) return;

            _currentSearchQuery = txtSearchQuery.Text;
            _currentSearchType = (SearchType)cmbSearchType.SelectedIndex;
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
            
            UpdateStatus(StatusType.LoadingMore);

            await SearchDABMusic();

            UpdateStatus(StatusType.Ready);
        }

        private void btnDownloadSelected_Click(object sender, EventArgs e)
        {
            UpdateStatus(StatusType.Downloading);



            UpdateStatus(StatusType.Ready);
        }

        private async Task SearchDABMusic()
        {
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

            dgvSearchResults.DataSource = null;
            switch (_currentSearchType)
            {
                case SearchType.Track when response.Tracks.Count != 0:
                    _currentTracks.AddRange(response.Tracks.Select(track => new SearchResponseTrack(track)));
                    dgvSearchResults.DataSource = _currentTracks;
                    break;
                case SearchType.Album when response.Albums.Count != 0:
                    _currentAlbums.AddRange(response.Albums.Select(album => new SearchResponseAlbum(album)));
                    dgvSearchResults.DataSource = _currentAlbums;
                    break;
            }

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
            if (dgvSearchResults.RowCount > 0)
            {
                var rowIndex = _currentSearchOffset != 0 ? _currentSearchOffset - 1 : 0;
                if (rowIndex >= 0 && rowIndex < dgvSearchResults.RowCount)
                {
                    dgvSearchResults.FirstDisplayedScrollingRowIndex = rowIndex;
                }
            }

            if (response.Pagination.HasMore)
            {
                _currentSearchOffset = response.Pagination.Offset + response.Pagination.Returned;
                lblSearchResults.Text = $@"{_currentSearchOffset} unique tracks loaded";
            }

            dgvSearchResults.Enabled = true;
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
                    lblStatusSplash.Visible = true;
                    message = @"Searching...";
                    break;
                case StatusType.LoadingMore:
                    btnSearch.Enabled = false;
                    lblStatusSplash.Visible = true;
                    message = @"Loading More...";
                    break;
                case StatusType.Downloading:
                    btnDownloadSelected.Enabled = false;
                    btnSearch.Enabled = false;
                    lblStatusSplash.Visible = true;
                    message = @"Downloading...";
                    break;
                case StatusType.Ready:
                default:
                    btnDownloadSelected.Enabled = true;
                    btnSearch.Enabled = true;
                    lblStatusSplash.Visible = false;
                    message = @"Ready";
                    break;
            }

            lblStatusMessage.Text = message;
            lblStatusSplash.Text = message;
        }

        private class SearchResponseTrack(Track track)
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

        private class SearchResponseAlbum(Album album)
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
    }
}
