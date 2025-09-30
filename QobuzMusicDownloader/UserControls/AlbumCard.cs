using QobuzMusicDownloader.Extensions;
using QobuzMusicDownloader.QobuzDL.Album;
using QobuzMusicDownloader.Services;
using System.Drawing.Drawing2D;

namespace QobuzMusicDownloader.UserControls
{
    public partial class AlbumCard : UserControl
    {
        private readonly IImageCacheService _imageCacheService;
        private readonly QobuzAlbum? _album;

        private Image? _albumCover;

        public AlbumCard(QobuzAlbum? album)
        {
            _album = album;
            _imageCacheService = ServiceLocator.GetService<IImageCacheService>();
            InitializeComponent();

            UpdateAlbumDisplay();
        }

        private void UpdateAlbumInfo()
        {
            lblAlbumTitle.Text = _album?.Title;
            lblArtistName.Text = _album?.Artist.Name;

            if (_album?.ParentalWarning == false)
            {
                lblExplicit.Visible = false;
                lblAlbumTitle.Location = new Point(0, lblAlbumTitle.Location.Y);
                lblAlbumTitle.Size = new Size(200, lblAlbumTitle.Size.Height);
            }
        }

        private async void UpdateAlbumDisplay()
        {
            try
            {
                if (_album == null)
                {
                    lblAlbumTitle.Visible = false;
                    lblArtistName.Visible = false;
                    lblExplicit.Visible = false;
                    return;
                }

                UpdateAlbumInfo();

                _albumCover = await _imageCacheService.GetImageAsync(_album.Image.Small, _album.Id);

                Invalidate();
            }
            catch (Exception)
            {
                // ignore
            }
        }

        public event EventHandler<QobuzAlbum>? AlbumClicked;
        private void AlbumCard_Click(object sender, EventArgs e)
        {
            AlbumClicked?.Invoke(this, _album);
        }

        public event EventHandler<QobuzAlbum>? AlbumDoubleClicked;
        private void AlbumCard_DoubleClick(object sender, EventArgs e)
        {
            AlbumDoubleClicked?.Invoke(this, _album);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (Properties.Settings.Default.DarkMode)
            {
                lblExplicit.BackColor = SystemColors.Control;
                lblExplicit.ForeColor = SystemColors.ControlText;

                lblAlbumTitle.ForeColor = SystemColors.Control;
                lblArtistName.ForeColor = SystemColors.ControlDark;
            }
            else
            {
                lblExplicit.BackColor = SystemColors.ControlText;
                lblExplicit.ForeColor = SystemColors.Control;

                lblAlbumTitle.ForeColor = SystemColors.ControlText;
                lblArtistName.ForeColor = SystemColors.GrayText;
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
