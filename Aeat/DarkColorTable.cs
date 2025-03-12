namespace Aeat;

public class DarkColorTable : ProfessionalColorTable
{
    private Color _mainColor;

    public DarkColorTable(Color mainColor)
    {
        _mainColor = mainColor;
    }

    public override Color MenuBorder => _mainColor;
    public override Color ImageMarginGradientBegin => _mainColor;
    public override Color ImageMarginGradientMiddle => ControlPaint.Light(_mainColor);
    public override Color ImageMarginRevealedGradientEnd => Color.Black;
    public override Color MenuItemSelectedGradientBegin => ControlPaint.Dark(_mainColor);
    public override Color MenuItemSelectedGradientEnd => Color.Black;
}
