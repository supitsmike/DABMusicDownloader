using DABMusicDownloader.Classes;
using DABMusicDownloader.Models.Search;
using DABMusicDownloader.Properties;

namespace DABMusicDownloader.Forms
{
    public partial class MainForm : Form
    {
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

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void dgvSearchResults_Scroll(object sender, ScrollEventArgs e)
        {
            if (dgvSearchResults.DisplayedRowCount(false) + dgvSearchResults.FirstDisplayedScrollingRowIndex >= dgvSearchResults.RowCount)
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
