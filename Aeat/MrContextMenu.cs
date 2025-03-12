using Aeat;

public class MrContextMenuStrip : ContextMenuStrip
{
    public MrContextMenuStrip(Color? color = null)
    {
        ForeColor = Color.White;
        BackColor = Color.FromArgb(20, 20, 20);
        Font = new Font("Vazirmatn", 10, FontStyle.Regular);

        Color chosenColor = color ?? Color.FromArgb(0, 160, 0);
        Renderer = new ToolStripProfessionalRenderer(new DarkColorTable(chosenColor));
    }
}
