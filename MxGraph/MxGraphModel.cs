namespace DrawmateLib.MxGraph;

public class MxGraphModel
{
    public int Dx { get; set; }
    public int Dy { get; set; }
    public int PageScale { get; set; }
    public int PageHeight { get; set; }
    public int PageWidth { get; set; }
    public int GridSize { get; set; }
    public MxGraphModelFlags MxFlags { get; set; }
}

[Flags]
public enum MxGraphModelFlags
{
    None = 0,
    Grid = 1 << 0,
    Guides = 1 << 1,
    ToolTips = 1 << 2,
    Connect = 1 << 3,
    Arrows = 1 << 4,
    Fold = 1 << 5,
    Math = 1 << 6,
    Shadow = 1 << 7
}
