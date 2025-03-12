using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Aeat
{
    public class MrTabControl : TabControl
    {
        private int _cornerRadius = 20;
        private float _borderThickness = 2f;
        private Color _borderColor = Color.FromArgb(5, 222, 5);
        private Color _tabBackColor = Color.FromArgb(20, 20, 20);
        private Color _tabForeColor = Color.White;

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int CornerRadius
        {
            get => _cornerRadius;
            set
            {
                _cornerRadius = value;
                this.Invalidate();
            }
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public float BorderThickness
        {
            get => _borderThickness;
            set
            {
                _borderThickness = value;
                this.Invalidate();
            }
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color BorderColor
        {
            get => _borderColor;
            set
            {
                _borderColor = value;
                this.Invalidate();
            }
        }

        public MrTabControl()
        {
            this.SetStyle(ControlStyles.UserPaint |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.OptimizedDoubleBuffer, true);
            this.SizeMode = TabSizeMode.Fixed;
            this.ItemSize = new Size(100, 40); // Ensure enough space for the tabs
            this.DrawMode = TabDrawMode.OwnerDrawFixed;
            this.BackColor = _tabBackColor;
            this.ForeColor = _tabForeColor;
            this.Alignment = TabAlignment.Top; // Set tabs to top position
            this.Region = new Region(GetRoundedRectanglePath(new Rectangle(0, 0, this.Width, this.Height), _cornerRadius));

            // Adding sample tabs for demonstration
            this.TabPages.Add(new TabPage("TabPage1"));
            this.TabPages.Add(new TabPage("TabPage2"));
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Region = new Region(GetRoundedRectanglePath(new Rectangle(0, 0, this.Width, this.Height), _cornerRadius));
            this.Invalidate(); // Redraw the control when resized
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (SolidBrush bgBrush = new SolidBrush(_tabBackColor))
            {
                e.Graphics.FillRectangle(bgBrush, this.ClientRectangle);
            }

            Rectangle borderRect = new Rectangle(
                (int)(_borderThickness / 2),
                (int)(_borderThickness / 2),
                this.Width - (int)_borderThickness,
                this.Height - (int)_borderThickness
            );

            using (GraphicsPath path = GetRoundedRectanglePath(borderRect, _cornerRadius))
            using (Pen pen = new Pen(_borderColor, _borderThickness))
            {
                e.Graphics.DrawPath(pen, path);
            }
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle tabRect = GetTabRect(e.Index);
            bool isSelected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;

            using (Brush tabBrush = new SolidBrush(isSelected ? _borderColor : _tabBackColor))
            {
                e.Graphics.FillRectangle(tabBrush, tabRect);
            }

            using (Brush textBrush = new SolidBrush(_tabForeColor))
            {
                StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                e.Graphics.DrawString(this.TabPages[e.Index].Text, this.Font, textBrush, tabRect, sf);
            }
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
