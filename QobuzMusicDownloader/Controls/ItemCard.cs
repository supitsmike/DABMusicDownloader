using System.Drawing.Drawing2D;
using QobuzMusicDownloader.Extensions;
using QobuzMusicDownloader.QobuzDL.Album;
using QobuzMusicDownloader.QobuzDL.Track;
using QobuzMusicDownloader.Services;

namespace QobuzMusicDownloader.Controls
{
    public partial class ItemCard : UserControl
    {
        private readonly IImageCacheService _imageCacheService;
        private readonly QobuzAlbum? _album;
        private readonly QobuzTrack? _track;

        private Image? _albumCover;
        private bool _isHovered;

        public ItemCard(QobuzAlbum? album = null, QobuzTrack? track = null)
        {
            _album = album;
            _track = track;
            _imageCacheService = ServiceLocator.GetService<IImageCacheService>();

            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);

            InitializeComponent();
            UpdateAlbumInfo();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (Properties.Settings.Default.DarkMode)
            {
                lblExplicit.BackColor = SystemColors.Control;
                lblExplicit.ForeColor = SystemColors.ControlText;

                lblItemTitle.ForeColor = SystemColors.Control;
                lblArtistName.ForeColor = SystemColors.ControlDark;
            }
            else
            {
                lblExplicit.BackColor = SystemColors.ControlText;
                lblExplicit.ForeColor = SystemColors.Control;

                lblItemTitle.ForeColor = SystemColors.ControlText;
                lblArtistName.ForeColor = SystemColors.GrayText;
            }

            base.OnPaint(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            pnlAlbumCover.Invalidate();
        }

        private async void UpdateAlbumInfo()
        {
            try
            {
                if (_album != null)
                {
                    Size = new Size(200, 237);

                    lblItemTitle.Text = _album.Title;
                    if (string.IsNullOrWhiteSpace(_album.Version) == false)
                    {
                        lblItemTitle.Text += $@" ({_album.Version})";
                    }

                    lblArtistName.Text = _album.Artist.Name;

                    if (_album.ParentalWarning == false)
                    {
                        lblExplicit.Visible = false;
                        lblItemTitle.Location = new Point(0, lblItemTitle.Location.Y);
                        lblItemTitle.Size = new Size(200, lblItemTitle.Size.Height);
                    }

                    _albumCover = await _imageCacheService.GetImageAsync(_album.Image.Small, _album.Id);
                }
                else if (_track != null)
                {
                    Size = new Size(200, 255);

                    lblItemTitle.Text = _track.Title;
                    if (string.IsNullOrWhiteSpace(_track.Version) == false)
                    {
                        lblItemTitle.Text += $@" ({_track.Version})";
                    }

                    lblArtistName.Text = _track.Album.Artist.Name;
                    lblAlbumTitle.Text = _track.Album.Title;
                    if (string.IsNullOrWhiteSpace(_track.Album.Version) == false)
                    {
                        lblAlbumTitle.Text += $@" ({_track.Album.Version})";
                    }

                    if (_track.Album.ParentalWarning == false)
                    {
                        lblExplicit.Visible = false;
                        lblItemTitle.Location = new Point(0, lblItemTitle.Location.Y);
                        lblItemTitle.Size = new Size(200, lblItemTitle.Size.Height);
                    }

                    _albumCover = await _imageCacheService.GetImageAsync(_track.Album.Image.Small, _track.Album.Id);
                }
                else
                {
                    Size = new Size(200, 200);
                }
            }
            catch (Exception e)
            {
                // ignore
            }
            finally
            {
                toolTip.SetToolTip(pnlAlbumCover, lblItemTitle.Text);
                pnlAlbumCover.Invalidate();
            }
        }

        public event EventHandler<QobuzAlbum?>? AlbumClicked;
        public event EventHandler<QobuzTrack?>? TrackClicked;
        private void ItemCard_Click(object sender, EventArgs e)
        {
            if (AlbumClicked != null && _album != null)
            {
                AlbumClicked.Invoke(this, _album);
            }
            if (TrackClicked != null && _track != null)
            {
                TrackClicked.Invoke(this, _track);
            }
        }

        public event EventHandler<QobuzAlbum?>? AlbumDoubleClicked;
        public event EventHandler<QobuzTrack?>? TrackDoubleClicked;
        private void ItemCard_DoubleClick(object sender, EventArgs e)
        {
            if (AlbumDoubleClicked != null && _album != null)
            {
                AlbumDoubleClicked.Invoke(this, _album);
            }
            if (TrackDoubleClicked != null && _track != null)
            {
                TrackDoubleClicked.Invoke(this, _track);
            }
        }

        private void pnlAlbumCover_Paint(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            var albumCoverRect = new Rectangle(0, 0, pnlAlbumCover.Width, pnlAlbumCover.Height);
            using var path = albumCoverRect.GetRoundedRectanglePath(12);

            if (_albumCover != null)
            {
                graphics.SetClip(path);
                graphics.DrawImage(_albumCover, albumCoverRect);

                if (_isHovered == false) return;

                using var dimmedBrush = new SolidBrush(Color.FromArgb(175, Color.Black));
                graphics.FillRectangle(dimmedBrush, albumCoverRect);
            }
            else
            {
                using var brush = new SolidBrush(SystemColors.WindowFrame);
                graphics.FillPath(brush, path);
            }
        }

        private void pnlAlbumCover_MouseEnter(object sender, EventArgs e)
        {
            if (_isHovered != false) return;

            _isHovered = true;
            pnlAlbumCover.Invalidate();
        }

        private void pnlAlbumCover_MouseLeave(object sender, EventArgs e)
        {
            if (_isHovered == false) return;

            _isHovered = false;
            pnlAlbumCover.Invalidate();
        }
    }
}
