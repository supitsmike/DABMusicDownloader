using QobuzMusicDownloader.Controls;
using QobuzMusicDownloader.Properties;
using QobuzMusicDownloader.QobuzDL;
using QobuzMusicDownloader.QobuzDL.Album;
using QobuzMusicDownloader.QobuzDL.Core;
using QobuzMusicDownloader.QobuzDL.Track;

namespace QobuzMusicDownloader.Forms
{
    public partial class SearchForm : Form
    {
        private readonly List<QobuzAlbum> _loadedAlbums = [];
        private readonly List<QobuzTrack> _loadedTracks = [];
        private readonly int _currentSearchLimit = 10;

        private bool _isSearching;
        private string _currentSearchQuery = string.Empty;
        private SearchFilter _currentSearchType = SearchFilter.Albums;
        private int _currentSearchOffset;

        public SearchForm()
        {
            InitializeComponent();

            cmbSearchType.SelectedIndex = 0;
            txtSearchQuery.Text = @"Kanye West";
            txtSearchQuery.Focus();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (Properties.Settings.Default.DarkMode)
            {
                BackColor = Color.FromArgb(20, 20, 20);
                ForeColor = SystemColors.Control;
            }
            else
            {
                BackColor = SystemColors.Control;
                ForeColor = SystemColors.ControlText;
            }

            base.OnPaint(e);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            new SettingsForm().ShowDialog(this);
            Invalidate();
        }

        private void txtSearchQuery_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter || _isSearching) return;

            btnSearch.PerformClick();

            e.Handled = true;
            e.SuppressKeyPress = true;
        }

        private void txtSearchQuery_TextChanged(object sender, EventArgs e)
        {
            btnSearch.Enabled = string.IsNullOrWhiteSpace(txtSearchQuery.Text) == false;
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (_isSearching) return;
                flpSearchResults.Controls.Clear();

                _currentSearchQuery = txtSearchQuery.Text;
                _currentSearchOffset = 0;

                _loadedAlbums.Clear();
                _loadedTracks.Clear();

                for (var i = 0; i < Settings.Default.SearchPageLimit; i++)
                {
                    await GetMusicFromQobuzDL(i != 0).ConfigureAwait(false);
                }
            }
            catch (Exception)
            {
                // ignore
            }
        }

        private void cmbSearchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_currentSearchType == (SearchFilter)cmbSearchType.SelectedIndex) return;

            _currentSearchType = (SearchFilter)cmbSearchType.SelectedIndex;
            if (_currentSearchType == SearchFilter.Artists)
            {
                MessageBox.Show(@"Artist Search is not supported.", @"Not Supported", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbSearchType.SelectedIndex = 0;
                _currentSearchType = SearchFilter.Albums;
                return;
            }

            flpSearchResults.Controls.Clear();
            AddItemCards(_loadedAlbums, _loadedTracks);
        }

        private async void flpSearchResults_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                await LoadMoreFromScroll();
            }
            catch (Exception)
            {
                // ignore
            }
        }

        private async void flpSearchResults_MouseWheel(object sender, MouseEventArgs e)
        {
            try
            {
                await LoadMoreFromScroll();
            }
            catch (Exception)
            {
                // ignore
            }
        }

        private async Task GetMusicFromQobuzDL(bool loadMore = false)
        {
            if (_isSearching) return;
            _isSearching = true;

            try
            {
                if (loadMore) _currentSearchOffset += _currentSearchLimit;

                var response = await QobuzDLAPI.GetMusicAsync(_currentSearchQuery, _currentSearchOffset).ConfigureAwait(false);
                if (response?.Data == null) return;

                _loadedAlbums.AddRange(response.Data.Albums.Items);
                _loadedTracks.AddRange(response.Data.Tracks.Items);
                
                AddItemCards(response.Data.Albums.Items, response.Data.Tracks.Items);
            }
            finally
            {
                _isSearching = false;
            }
        }

        private async Task LoadMoreFromScroll()
        {
            if (flpSearchResults.VerticalScroll.Value < (flpSearchResults.VerticalScroll.Maximum - flpSearchResults.VerticalScroll.LargeChange)) return;

            for (var i = 0; i < Settings.Default.SearchPageLimit; i++)
            {
                await GetMusicFromQobuzDL(true).ConfigureAwait(false);
            }
        }

        private void AddAlbumCards(IEnumerable<QobuzAlbum> albums)
        {
            if (InvokeRequired)
            {
                Invoke(AddAlbumCards, albums);
                return;
            }

            foreach (var album in albums)
            {
                var albumCard = new ItemCard(album: album);
                //albumCard.AlbumClicked += (s, e) => OnAlbumClicked(album);
                //albumCard.AlbumDoubleClicked += (s, e) => OnAlbumDoubleClick(album);

                flpSearchResults.Controls.Add(albumCard);
            }
        }

        private void AddTrackCards(IEnumerable<QobuzTrack> tracks)
        {
            if (InvokeRequired)
            {
                Invoke(AddTrackCards, tracks);
                return;
            }

            foreach (var track in tracks)
            {
                var trackCard = new ItemCard(track: track);
                //trackCard.TrackClicked += (s, e) => OnTrackClicked(track);
                //trackCard.TrackDoubleClicked += (s, e) => OnTrackDoubleClick(track);

                flpSearchResults.Controls.Add(trackCard);
            }
        }

        private void AddItemCards(IEnumerable<QobuzAlbum> albums, IEnumerable<QobuzTrack> tracks)
        {
            switch (_currentSearchType)
            {
                case SearchFilter.Albums: AddAlbumCards(albums); break;
                case SearchFilter.Tracks: AddTrackCards(tracks); break;
                case SearchFilter.Artists:
                default: throw new ArgumentOutOfRangeException();
            }
        }

        //private void OnAlbumClicked(QobuzAlbum album)
        //{
        //    MessageBox.Show($@"Clicked: {album.Title} by {album.Artist.Name}");
        //}
        //
        //private void OnAlbumDoubleClick(QobuzAlbum album)
        //{
        //    MessageBox.Show($@"Double Clicked: {album.Title} by {album.Artist.Name}");
        //}
        //
        //private void OnTrackClicked(QobuzTrack track)
        //{
        //    MessageBox.Show($@"Clicked: {track.Title} by {track.Album.Artist.Name}");
        //}
        //
        //private void OnTrackDoubleClick(QobuzTrack track)
        //{
        //    MessageBox.Show($@"Double Clicked: {track.Title} by {track.Album.Artist.Name}");
        //}
    }
}
