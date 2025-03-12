using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace Aeat;

public class MrPanel : Panel
{
    private int _cornerRadius = 20;
    private int _borderThickness = 2;
    private Color _borderColor = Color.FromArgb(5, 222, 5);

    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public int CornerBorder
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
    public int BorderThickness
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

    public MrPanel()
    {
        this.BackColor = Color.FromArgb(20, 20, 20);
        this.Resize += (s, e) => SetRoundedRegion();
    }

    private void SetRoundedRegion()
    {
        using (GraphicsPath path = GetRoundedRectanglePath(this.ClientRectangle, _cornerRadius, _borderThickness))
        {
            this.Region = new Region(path);
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

        Rectangle borderRect = new Rectangle(
            _borderThickness / 2,
            _borderThickness / 2,
            this.Width - _borderThickness,
            this.Height - _borderThickness
        );

        using (GraphicsPath path = GetRoundedRectanglePath(borderRect, _cornerRadius, _borderThickness))
        using (Pen pen = new Pen(_borderColor, _borderThickness))
        {
            e.Graphics.DrawPath(pen, path);
        }
    }

    private GraphicsPath GetRoundedRectanglePath(Rectangle rect, int radius, int borderThickness)
    {
        int diameter = Math.Max(0, (radius - borderThickness) * 2);
        GraphicsPath path = new GraphicsPath();

        path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
        path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
        path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
        path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);

        path.CloseFigure();
        return path;
    }
}
