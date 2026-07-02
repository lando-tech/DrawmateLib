namespace DrawmateLib.MxGraph;

public class MxGeometry
{
    public decimal? X { get; set; } = null;
    public decimal? Y { get; set; } = null;
    public int? Width { get; set; } = null;
    public int? Height { get; set; } = null;
    public bool Relative { get; set; } = false;
    public string As { get; set; } = "geometry";

    public MxGeometry()
    {

    }

    public MxGeometry(decimal x, decimal y, int width, int height)
    {
        X = x;
        Y = y;
        Width = width;
        Height = height;
    }
}
