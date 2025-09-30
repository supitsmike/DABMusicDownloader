using QobuzMusicDownloader.Extensions;
using QobuzMusicDownloader.QobuzDL.Album;
using QobuzMusicDownloader.QobuzDL.Track;
using QobuzMusicDownloader.Services;
using System.Drawing.Drawing2D;

namespace QobuzMusicDownloader.UserControls
{
    public partial class TrackCard : UserControl
    {
        private readonly IImageCacheService _imageCacheService;
        private readonly QobuzTrack? _track;

        private Image? _albumCover;

        public TrackCard(QobuzTrack? track)
        {
            _track = track;
            _imageCacheService = ServiceLocator.GetService<IImageCacheService>();
            InitializeComponent();

            UpdateAlbumDisplay();
        }

        private void UpdateAlbumInfo()
        {
            lblTrackTitle.Text = _track?.Title;
            lblArtistName.Text = _track?.Album.Artist.Name;
            lblAlbumTitle.Text = _track?.Album.Title;

            if (_track?.ParentalWarning == false)
            {
                lblExplicit.Visible = false;
                lblTrackTitle.Location = new Point(0, lblTrackTitle.Location.Y);
                lblTrackTitle.Size = new Size(200, lblTrackTitle.Size.Height);
            }
        }

        private async void UpdateAlbumDisplay()
        {
            try
            {
                if (_track == null)
                {
                    lblTrackTitle.Visible = false;
                    lblArtistName.Visible = false;
                    lblAlbumTitle.Visible = false;
                    lblExplicit.Visible = false;
                    return;
                }

                UpdateAlbumInfo();

                _albumCover = await _imageCacheService.GetImageAsync(_track.Album.Image.Small, _track.Album.Id);

                Invalidate();
            }
            catch (Exception)
            {
                // ignore
            }
        }

        public event EventHandler<QobuzTrack?>? TrackClicked;
        private void TrackCard_Click(object sender, EventArgs e)
        {
            TrackClicked?.Invoke(this, _track);
        }

        public event EventHandler<QobuzTrack?>? TrackDoubleClicked;
        private void TrackCard_DoubleClick(object sender, EventArgs e)
        {
            TrackDoubleClicked?.Invoke(this, _track);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (Properties.Settings.Default.DarkMode)
            {
                lblExplicit.BackColor = SystemColors.Control;
                lblExplicit.ForeColor = SystemColors.ControlText;

                lblTrackTitle.ForeColor = SystemColors.Control;
                lblArtistName.ForeColor = SystemColors.ControlDark;
                lblAlbumTitle.ForeColor = SystemColors.ControlDark;
            }
            else
            {
                lblExplicit.BackColor = SystemColors.ControlText;
                lblExplicit.ForeColor = SystemColors.Control;

                lblTrackTitle.ForeColor = SystemColors.ControlText;
                lblArtistName.ForeColor = SystemColors.GrayText;
                lblAlbumTitle.ForeColor = SystemColors.GrayText;
            }

            var graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            var state = graphics.Save();
            var albumCoverRect = new Rectangle(0, 0, 200, 200);
            using var path = albumCoverRect.GetRoundedRectanglePath(12);

            if (_albumCover != null)
            {
                graphics.SetClip(path);
                graphics.DrawImage(_albumCover, albumCoverRect);
            }
            else
            {
                using var brush = new SolidBrush(SystemColors.WindowFrame);
                graphics.FillPath(brush, path);
            }

            graphics.Restore(state);

            base.OnPaint(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            Invalidate();
        }
    }
}
