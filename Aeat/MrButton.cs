using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Aeat;

public class MrButton : Button
{
    private int _cornerRadius = 20;
    private int _borderThickness = 2;
    private Color _borderColor = Color.FromArgb(5, 222, 5);
    private Color _backgroundColor = Color.FromArgb(20, 20, 20);
    private Color _clickColor = Color.FromArgb(50, 50, 50);
    private bool _isMouseOver = false;
    private bool _isMouseDown = false;

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
    public Color ClickColor
    {
        get => _clickColor;
        set { _clickColor = value; Invalidate(); }
    }

    public MrButton()
    {
        this.FlatStyle = FlatStyle.Flat;
        this.FlatAppearance.BorderSize = 0;
        this.FlatAppearance.MouseOverBackColor = Color.Transparent;
        this.FlatAppearance.MouseDownBackColor = Color.Transparent;
        this.BackColor = _backgroundColor;
        this.ForeColor = Color.White;

        this.Resize += (s, e) => this.Invalidate();
        this.MouseEnter += (s, e) => { _isMouseOver = true; Invalidate(); };
        this.MouseLeave += (s, e) => { _isMouseOver = false; Invalidate(); };
        this.MouseDown += (s, e) => { _isMouseDown = true; Invalidate(); };
        this.MouseUp += (s, e) => { _isMouseDown = false; Invalidate(); };
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

        Color fillColor = _isMouseDown ? _clickColor : (_isMouseOver ? _borderColor : _backgroundColor);
        Rectangle borderRect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);

        using (GraphicsPath path = GetRoundedRectanglePath(borderRect, _cornerRadius))
        using (SolidBrush brush = new SolidBrush(fillColor))
        using (Pen pen = new Pen(_borderColor, _borderThickness))
        {
            e.Graphics.FillPath(brush, path);
            e.Graphics.DrawPath(pen, path);
        }

        using (StringFormat sf = new StringFormat())
        {
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            using (SolidBrush textBrush = new SolidBrush(this.ForeColor))
            {
                e.Graphics.DrawString(this.Text, this.Font, textBrush, borderRect, sf);
            }
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