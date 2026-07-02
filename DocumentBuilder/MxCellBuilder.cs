using DrawmateLib.MxGraph;

namespace DrawmateLib.DocumentBuilder;

public class MxCellBuilder
{
    private int _cellCount = 1; // Tracks IDs automatically

    // Core state for the cell we are currently building
    private string _label = "";
    private string _styleName = "";
    private MxGeometry? _geometry;
    private bool _connectable;
    private bool _vertex;
    private bool _edge;

    public MxCellBuilder CreateNew(string label, string styleName)
    {
        _label = label;
        _styleName = styleName;
        // Reset defaults for a new cell
        _geometry = null;
        _connectable = false;
        _vertex = false;
        _edge = false;
        return this; // Returning 'this' allows method chaining!
    }

    public MxCellBuilder WithGeometry(decimal x, decimal y, int width, int height)
    {
        _geometry = new MxGeometry(x, y, width, height);
        return this;
    }

    public MxCellBuilder AsVertex()
    {
        _vertex = true;
        _connectable = true;
        return this;
    }

    public MxCellBuilder AsEdge()
    {
        _edge = true;
        return this;
    }

    public MxCell Build()
    {
        var id = new MxId(_cellCount++);
        var style = new MxGraphStyle(_styleName);

        var cell = _geometry != null
            ? new MxCell(_label, id, style, _geometry)
            : new MxCell(_label, id, style);

        cell.Connectable = _connectable;
        cell.Vertex = _vertex;
        cell.Edge = _edge;

        return cell;
    }
}
