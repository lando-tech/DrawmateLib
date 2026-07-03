namespace DrawmateLib.MxGraphModels;

public class MxCell
{
    public readonly MxId Id;
    public MxId? Source { get; set; } = null;
    public MxId? Target { get; set; } = null;
    public string? Parent { get; set; } = null;
    public MxGeometry? Geometry { get; set; } = null;
    public MxGraphStyle Style { get; set; }
    public string? ValueLabel { get; set; } = "";
    public bool Vertex { get; set; } = false;
    public bool Connectable { get; set; } = false;
    public bool Edge { get; set; } = false;

    public MxCell(string label, MxId id, MxGraphStyle mxGraphStyle)
    {
        ValueLabel = label;
        Style = mxGraphStyle;
        Id = id;
    }

    public MxCell(string label, MxId id, MxGraphStyle mxGraphStyle, MxGeometry mxGeometry)
    {
        ValueLabel = label;
        Style = mxGraphStyle;
        Geometry = mxGeometry;
        Id = id;
    }
}
