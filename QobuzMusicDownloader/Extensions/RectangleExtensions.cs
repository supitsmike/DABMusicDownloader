using System.Drawing.Drawing2D;

namespace QobuzMusicDownloader.Extensions
{
    public static class RectangleExtensions
    {
        public static GraphicsPath GetRoundedRectanglePath(this Rectangle rect, int radius)
        {
            var path = new GraphicsPath();

            if (radius == 0)
            {
                path.AddRectangle(rect);
            }
            else
            {
                var diameter = radius * 2;

                // Top-left corner
                path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);

                // Top-right corner
                path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);

                // Bottom-right corner
                path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);

                // Bottom-left corner
                path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            }

            path.CloseFigure();
            return path;
        }
    }
}
