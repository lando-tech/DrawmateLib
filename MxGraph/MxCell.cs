namespace DrawmateLib.MxGraph;

public class MxCell
{
    public readonly MxId Id;
    public MxId? Source { get; set; } = null;
    public MxId? Target { get; set; } = null;
    public MxId? Parent { get; set; } = null;
    public MxGeometry? Geometry { get; set; } = null;
    public MxGraphStyle Style { get; set; }
    public string? ValueLabel { get; set; } = "";
    public bool Vertex { get; set; } = false;
    public bool Connectable { get; set; } = false;
    public bool Edge { get; set; } = false;

    public MxCell(string label, string style, int cellCount)
    {
        ValueLabel = label;
        Style = new MxGraphStyle(style);
        Id = new MxId(cellCount);
    }
}
