using System.Drawing;
using System.Drawing.Drawing2D;
using GMap.NET;
using GMap.NET.WindowsForms;

namespace GMap.Extend
{
    /// <summary>
    /// GMap.NET marker
    /// </summary>
    public class GMapTip : GMapToolTip
    {
        internal GMapMarker Marker;

        public Point Offset;

        /// <summary>
        /// string format
        /// </summary>
        public StringFormat Format = new StringFormat();

        /// <summary>
        /// font
        /// </summary>
        public Font Font = new Font("微软雅黑", 9);

        /// <summary>
        /// specifies how the outline is painted
        /// </summary>
        public Pen Stroke = new Pen(Color.FromArgb(160, Color.MidnightBlue));

        /// <summary>
        /// background color
        /// </summary>
        public Brush Fill = null;

        /// <summary>
        /// forecolor
        /// </summary>
        public Brush Fore = null;

        /// <summary>
        /// text padding
        /// </summary>
        public Size TextPadding = new Size(6, 6);

        public GMapTip(GMapMarker marker, Color BackColor, Color ForeColor) : base(marker)
        {
            this.Marker = marker;
            this.Offset = new Point(10, -20);

            this.Fill = new SolidBrush(Color.FromArgb(200, BackColor));
            this.Fore = new SolidBrush(Color.FromArgb(255, ForeColor));

            this.Stroke.Width = 1;
            this.Stroke.LineJoin = LineJoin.Round;
            this.Stroke.StartCap = LineCap.RoundAnchor;

            this.Format.Alignment = StringAlignment.Center;
            this.Format.LineAlignment = StringAlignment.Center;
        }

        public override void OnRender(Graphics g)
        {
            System.Drawing.Size st = g.MeasureString(Marker.ToolTipText, Font).ToSize();
            System.Drawing.Rectangle rect = new System.Drawing.Rectangle(Marker.ToolTipPosition.X, Marker.ToolTipPosition.Y - st.Height, st.Width + TextPadding.Width, st.Height + TextPadding.Height);
            rect.Offset(Offset.X, Offset.Y);

            g.DrawLine(Stroke, Marker.ToolTipPosition.X, Marker.ToolTipPosition.Y, rect.X, rect.Y + rect.Height / 2);

            g.FillRectangle(Fill, rect);
            g.DrawRectangle(Stroke, rect);

            g.DrawString(Marker.ToolTipText, Font, Fore, rect, Format);
        }
    }
}
