using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Aeat
{
    public class MrCheckBox : CheckBox
    {
        public enum TextAlignments { Left, Right }

        private int _cornerRadius = 10;
        private int _borderThickness = 2;
        private Color _borderColor = Color.FromArgb(5, 222, 5);
        private Color _backgroundColor = Color.FromArgb(20, 20, 20);
        private Color _checkColor = Color.FromArgb(5, 222, 5);
        private bool _isMouseOver = false;
        private bool _isMouseDown = false;
        private TextAlignments _textAlignment = TextAlignments.Right;

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int CornerRadius
        {
            get => _cornerRadius;
            set { _cornerRadius = value; Invalidate(); }
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int BorderThickness
        {
            get => _borderThickness;
            set { _borderThickness = value; Invalidate(); }
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color BorderColor
        {
            get => _borderColor;
            set { _borderColor = value; Invalidate(); }
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color BackgroundColor
        {
            get => _backgroundColor;
            set { _backgroundColor = value; Invalidate(); }
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color CheckColor
        {
            get => _checkColor;
            set { _checkColor = value; Invalidate(); }
        }

        [Browsable(true)]
        [DefaultValue(TextAlignments.Right)]
        public TextAlignments TextAlignment
        {
            get => _textAlignment;
            set { _textAlignment = value; Invalidate(); }
        }

        public MrCheckBox()
        {
            this.AutoSize = false;
            this.Size = new Size(100, 30);
            this.MinimumSize = new Size(8, 8);
            this.BackColor = Color.Transparent;
            this.FlatStyle = FlatStyle.Flat;
            this.Appearance = Appearance.Button;

            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);

            this.MouseEnter += (s, e) => { _isMouseOver = true; Invalidate(); };
            this.MouseLeave += (s, e) => { _isMouseOver = false; Invalidate(); };
            this.MouseDown += (s, e) => { _isMouseDown = true; Invalidate(); };
            this.MouseUp += (s, e) => { _isMouseDown = false; Invalidate(); };
            this.CheckedChanged += (s, e) => Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Clear(this.Parent?.BackColor ?? Color.Black);

            int boxSize = Math.Max(Height - 4, 4);
            int radius = Math.Min(_cornerRadius, boxSize / 2);
            Rectangle boxRect = new Rectangle(2, 2, boxSize, boxSize);

            if (_textAlignment == TextAlignments.Left)
                boxRect.X = Width - boxSize - 2;

            Color fillColor = _isMouseDown ? Color.FromArgb(80, _checkColor) : (_isMouseOver ? _borderColor : _backgroundColor);

            using (GraphicsPath path = GetRoundedRectanglePath(boxRect, radius))
            using (SolidBrush brush = new SolidBrush(fillColor))
            using (Pen pen = new Pen(_borderColor, Math.Max(_borderThickness, 1)))
            {
                e.Graphics.FillPath(brush, path);
                e.Graphics.DrawPath(pen, path);
            }

            if (Checked && boxSize > 6)
            {
                using (Pen checkPen = new Pen(_checkColor, 2))
                {
                    checkPen.StartCap = LineCap.Round;
                    checkPen.EndCap = LineCap.Round;
                    Point[] checkPoints =
                    {
                new Point(boxRect.Left + boxRect.Width / 4, boxRect.Top + boxRect.Height / 2),
                new Point(boxRect.Left + boxRect.Width / 2, boxRect.Bottom - boxRect.Width / 4),
                new Point(boxRect.Right - boxRect.Width / 4, boxRect.Top + boxRect.Height / 4)
            };
                    e.Graphics.DrawLines(checkPen, checkPoints);
                }
            }

            if (Width > 15)
            {
                using (Brush textBrush = new SolidBrush(ForeColor))
                using (StringFormat sf = new StringFormat { LineAlignment = StringAlignment.Center })
                {
                    sf.Alignment = _textAlignment == TextAlignments.Right ? StringAlignment.Near : StringAlignment.Far;
                    Rectangle textRect = new Rectangle(
                        _textAlignment == TextAlignments.Right ? boxRect.Right + 5 : 0,
                        0,
                        Width - boxSize - 10,
                        Height
                    );

                    e.Graphics.DrawString(Text, Font, textBrush, textRect, sf);
                }
            }
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {

        }

        private GraphicsPath GetRoundedRectanglePath(Rectangle rect, int radius)
        {
            int diameter = Math.Max(0, radius * 2);
            GraphicsPath path = new GraphicsPath();

            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);

            path.CloseFigure();
            return path;
        }
    }
}
