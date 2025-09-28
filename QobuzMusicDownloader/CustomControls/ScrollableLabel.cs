using System.ComponentModel;

namespace QobuzMusicDownloader.CustomControls
{
    public partial class ScrollableLabel : Label
    {
        //private readonly System.Windows.Forms.Timer AutoScrollTimer = new()
        //{
        //    Interval = 30
        //};

        private bool _isPaused;
        private bool _isHovered;
        private bool _isDragging;
        private bool _autoScrollEnabled = true;
        private int _textOffsetX;
        private int _maxTextWidth;
        private int _autoScrollSpeed = 1;
        private int _pauseDelayDuration = 1000;
        private DateTime _pauseStartTime;
        private Point _lastMousePosition;

        [Category("Scrolling")]
        [Description("Enabled the automatically scrolling when it overflows the control bounds.")]
        [DefaultValue(true)]
        public bool AutoScroll
        {
            get => _autoScrollEnabled;
            set
            {
                _autoScrollEnabled = value;
                if (value) return;

                StopAutoScroll();
            }
        }

        [Category("Scrolling")]
        [Description("The speed at which the text automatically scrolls horizontally.")]
        [DefaultValue(1)]
        public int AutoScrollSpeed
        {
            get => _autoScrollSpeed;
            set => _autoScrollSpeed = Math.Max(1, Math.Min(5, value));
        }

        [Category("Scrolling")]
        [Description("The duration in milliseconds to pause before starting the scroll animation.")]
        [DefaultValue(1000)]
        public int PauseDelayDuration
        {
            get => _pauseDelayDuration;
            set => _pauseDelayDuration = Math.Max(100, value);
        }

        public ScrollableLabel()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(BackColor); 
            if (string.IsNullOrEmpty(Text)) return;

            using var brush = new SolidBrush(ForeColor);
            var format = new StringFormat();

            format.Alignment = TextAlign switch
            {
                ContentAlignment.TopLeft or ContentAlignment.MiddleLeft or ContentAlignment.BottomLeft => StringAlignment.Near,
                ContentAlignment.TopCenter or ContentAlignment.MiddleCenter or ContentAlignment.BottomCenter => StringAlignment.Center,
                ContentAlignment.TopRight or ContentAlignment.MiddleRight or ContentAlignment.BottomRight => StringAlignment.Far,
                _ => format.Alignment
            };
            
            format.LineAlignment = TextAlign switch
            {
                ContentAlignment.TopLeft or ContentAlignment.TopCenter or ContentAlignment.TopRight => StringAlignment.Near,
                ContentAlignment.MiddleLeft or ContentAlignment.MiddleCenter or ContentAlignment.MiddleRight => StringAlignment.Center,
                ContentAlignment.BottomLeft or ContentAlignment.BottomCenter or ContentAlignment.BottomRight => StringAlignment.Far,
                _ => format.LineAlignment
            };

            if (CanScroll() == false)
            {
                var textRect = new Rectangle(0, 0, Width, Height);
                e.Graphics.DrawString(Text, Font, brush, textRect, format);
            }
            else
            {
                format.Alignment = StringAlignment.Near;
                var textRect = new Rectangle(_textOffsetX, 0, _maxTextWidth, Height);
                e.Graphics.DrawString(Text, Font, brush, textRect, format);
            }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);

            StopAutoScroll();
            CalculateTextWidth();
            ResetScrollPosition();
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);

            StopAutoScroll();
            CalculateTextWidth();
            ResetScrollPosition();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            StopAutoScroll();
            CalculateTextWidth();
            ResetScrollPosition();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && CanScroll())
            {
                Cursor = Cursors.Hand;
                Capture = true;

                _isDragging = true;
                _lastMousePosition = e.Location;

                StopAutoScroll();
            }

            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (_isDragging && CanScroll())
            {
                var deltaX = e.X - _lastMousePosition.X;
                _textOffsetX += deltaX;

                var minOffset = Width - _maxTextWidth;
                _textOffsetX = Math.Max(minOffset, Math.Min(0, _textOffsetX));

                _lastMousePosition = e.Location;
                Invalidate();
            }

            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (_isDragging)
            {
                Cursor = _isHovered && CanScroll() ? Cursors.Hand : Cursors.Default;
                Capture = false;

                _isDragging = false;
            }

            base.OnMouseUp(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            _isHovered = true;
            if (CanScroll())
            {
                Cursor = Cursors.Hand;

                StartAutoScroll();
            }

            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            _isHovered = false;
            if (_isDragging == false)
            {
                Cursor = Cursors.Default;

                StopAutoScroll();
            }

            base.OnMouseLeave(e);
        }

        private void AutoScrollTimerOnTick(object? sender, EventArgs e)
        {
            if (CanScroll() == false || _isHovered == false || _isDragging)
            {
                StopAutoScroll();
                return;
            }

            var minOffset = Width - _maxTextWidth;
            var endOfLabel = _textOffsetX <= minOffset;

            if (_isPaused)
            {
                if (DateTime.Now.Subtract(_pauseStartTime).TotalMilliseconds < _pauseDelayDuration) return;

                _isPaused = false;
                if (endOfLabel)
                {
                    _isPaused = true;
                    _textOffsetX = 0;
                    _pauseStartTime = DateTime.Now;
                }

                Invalidate();
                return;
            }

            _textOffsetX -= _autoScrollSpeed;
            if (endOfLabel)
            {
                _isPaused = true;
                _textOffsetX = minOffset;
                _pauseStartTime = DateTime.Now;
            }

            Invalidate();
        }

        private void StartAutoScroll()
        {
            if (_isDragging || _autoScrollEnabled == false || CanScroll() == false) return;

            _isPaused = true;
            _pauseStartTime = DateTime.Now;

            AutoScrollTimer.Start();
        }

        private void StopAutoScroll()
        {
            AutoScrollTimer.Stop();
        }

        private void CalculateTextWidth()
        {
            if (string.IsNullOrEmpty(Text))
            {
                _maxTextWidth = 0;
                return;
            }

            using var g = CreateGraphics();
            var textSize = g.MeasureString(Text, Font);
            _maxTextWidth = (int)Math.Ceiling(textSize.Width);
        }

        private void ResetScrollPosition()
        {
            _textOffsetX = 0;
            _isPaused = false;
            Invalidate();
        }

        private bool CanScroll()
        {
            return _maxTextWidth > Width;
        }
    }
}
