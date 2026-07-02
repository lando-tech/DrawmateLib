namespace DrawmateLib.MxGraph;

public class MxGeometry
{
    public decimal X { get; set; }
    public decimal Y { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public string Relative { get; set; } = "";
    public string As { get; set; } = "geometry";
}
