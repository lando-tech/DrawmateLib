using DrawmateLib.MxGraphModels;

namespace DrawmateLib.Builders;

public class MxCellBuilder
{
    private int _cellCount = 1;
    private string _label = "";
    private string _styleName = "";
    private MxGeometry? _geometry;
    private MxId? _source;
    private MxId? _target;
    private string _parent = "1";

    public MxCellBuilder Create(string label, string styleName)
    {
        _label = label;
        _styleName = styleName;

        // Reset defaults for a new cell
        _parent = "1";
        _source = null;
        _target = null;
        _geometry = null;

        return this;
    }

    public MxCellBuilder WithGeometry(decimal x, decimal y, int width, int height)
    {
        _geometry = new MxGeometry(x, y, width, height);
        return this;
    }

    public MxCellBuilder AsEdge(MxId source, MxId target)
    {
        _source = source;
        _target = target;
        _geometry = new MxGeometry(relative: true);
        return this;
    }

    public MxCellBuilder WithCustomParent(string parentId)
    {
        _parent = parentId;
        return this;
    }

    public MxCell Build()
    {
        var id = new MxId(_cellCount++);
        var style = new MxGraphStyle(_styleName);
        var cell = new MxCell(_label, id, style)
        {
            Parent = _parent
        };

        if (_geometry != null)
        {
            cell.Geometry = _geometry;
            if (_geometry.Relative)
            {
                cell.Source = _source;
                cell.Target = _target;

                cell.Edge = true;
                cell.Vertex = false;
                cell.Connectable = false;
            }
            else
            {
                cell.Vertex = true;
                cell.Connectable = true;
                cell.Edge = false;
            }
        }
        return cell;
    }
}
