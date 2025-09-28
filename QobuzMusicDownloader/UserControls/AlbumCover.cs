using QobuzMusicDownloader.Extensions;
using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace QobuzMusicDownloader.UserControls
{
    public partial class AlbumCover : UserControl
    {
        private int _cornerRadius = 10;
        private Image? _albumCoverImage;

        [Category("Appearance")]
        [DefaultValue(10)]
        [Description("The radius of the rounded corners")]
        public int CornerRadius
        {
            get => _cornerRadius;
            set
            {
                _cornerRadius = Math.Max(0, value);
                Invalidate();
            }
        }

        public Image? AlbumCoverImage
        {
            get => _albumCoverImage;
            set
            {
                _albumCoverImage = value;
                Invalidate();
            }
        }

        public AlbumCover()
        {
            InitializeComponent();

            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            var state = graphics.Save();
            using var path = ClientRectangle.GetRoundedRectanglePath(CornerRadius);

            if (AlbumCoverImage != null)
            {
                graphics.SetClip(path);
                graphics.DrawImage(AlbumCoverImage, ClientRectangle);
            }
            else
            {
                using var brush = new SolidBrush(SystemColors.ControlDarkDark);
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

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Invalidate();
        }
    }
}
