using QobuzMusicDownloader.QobuzDL;
using QobuzMusicDownloader.QobuzDL.Album;
using QobuzMusicDownloader.QobuzDL.Core;
using QobuzMusicDownloader.UserControls;

namespace QobuzMusicDownloader.Forms
{
    public partial class SearchForm : Form
    {
        private readonly List<AlbumCard> _skeletonCards = [];

        private bool _isSearching;
        private string _currentSearchQuery = string.Empty;
        private SearchFilter _currentSearchType = SearchFilter.Albums;
        private int _currentSearchOffset;

        public SearchForm()
        {
            InitializeComponent();

            cmbSearchType.SelectedIndex = 0;
            txtSearchQuery.Text = @"Kanye West";
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            _currentSearchQuery = txtSearchQuery.Text;
            _currentSearchType = (SearchFilter)cmbSearchType.SelectedIndex;
            _currentSearchOffset = 0;

            await GetMusicFromQobuzDL();
            await GetMusicFromQobuzDL(true);
            await GetMusicFromQobuzDL(true);
        }

        private async Task GetMusicFromQobuzDL(bool loadMore = false)
        {
            if (_isSearching) return;
            _isSearching = true;

            try
        {
                if (loadMore) _currentSearchOffset += Properties.Settings.Default.SearchResultLimit;
                else flpSearchResults.Controls.Clear();

                _skeletonCards.Clear();
                for (var i = 0; i < Properties.Settings.Default.SearchResultLimit; i++)
                {
                    var albumCard = new AlbumCard(null);
                    _skeletonCards.Add(albumCard);
                    flpSearchResults.Controls.Add(albumCard);
                }

            var response = await QobuzDLAPI.GetMusicAsync(_currentSearchQuery, _currentSearchOffset);

                foreach (var skeletonCard in _skeletonCards.ToList())
                {
                    _skeletonCards.Remove(skeletonCard);
                    flpSearchResults.Controls.Remove(skeletonCard);
                }

            if (response == null || response.Data == null) return;
            if (_currentSearchType == SearchFilter.Albums)
            {
                foreach (var album in response.Data.Albums.Items)
                {
                    if (album == null) continue;
                    var albumCard = new AlbumCard(album);
                    //albumCard.AlbumClicked += (s, e) => OnAlbumClicked(album);
                    //albumCard.AlbumDoubleClicked += (s, e) => OnAlbumDoubleClick(album);

                    flpSearchResults.Controls.Add(albumCard);
                }
                }
            }
            finally
            {
                _isSearching = false;
            }
        }

        //private void OnAlbumClicked(QobuzAlbum album)
        //{
        //    MessageBox.Show($@"Clicked: {album.Title} by {album.Artist}");
        //}
        //
        //private void OnAlbumDoubleClick(QobuzAlbum album)
        //{
        //    MessageBox.Show($@"Double Clicked: {album.Title} by {album.Artist}");
        //}

        private void txtSearchQuery_TextChanged(object sender, EventArgs e)
        {
            btnSearch.Enabled = string.IsNullOrWhiteSpace(txtSearchQuery.Text) == false;
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            new SettingsForm().ShowDialog(this);
            Invalidate();
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
    }
}
