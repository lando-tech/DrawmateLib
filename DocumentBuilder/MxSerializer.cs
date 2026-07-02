using System.Xml.Linq;
using DrawmateLib.MxGraph;

namespace DrawmateLib.DocumentBuilder;

public class MxSerializer
{
    public XElement SerializeMxCell(MxCell mxCell)
    {
        var mxCellElement = new XElement(MxElementNames.MxCell);
        if (mxCell.Geometry != null)
        {
            var mxGeometryElement = SerializeMxGeometry(mxCell.Geometry);
            mxCellElement.Add(mxGeometryElement);
        }

        AddMxCellAttributes(mxCellElement, mxCell);
        return mxCellElement;
    }

    public XElement SerializeMxGeometry(MxGeometry mxGeometry)
    {
        var mxGeometryElement = new XElement(MxElementNames.MxGeometry);
        AddMxGeometryAttributes(mxGeometryElement, mxGeometry);
        return mxGeometryElement;
    }

    public XElement SerializeMxArray()
    {
        return new XElement(MxElementNames.MxArray);
    }

    private static void AddMxCellAttributes(XElement mxCellElement, MxCell mxCell)
    {
        mxCellElement.Add(new XAttribute(MxAttributeNames.Id, mxCell.Id.Value));
        mxCellElement.Add(new XAttribute(MxAttributeNames.Value, mxCell.ValueLabel ?? ""));
        mxCellElement.Add(new XAttribute(MxAttributeNames.Style, mxCell.Style.Value));

        mxCellElement.Add(new XAttribute(MxAttributeNames.Connectable, mxCell.Connectable ? "1" : "0"));
        mxCellElement.Add(new XAttribute(MxAttributeNames.Edge, mxCell.Edge ? "1" : "0"));
        mxCellElement.Add(new XAttribute(MxAttributeNames.Vertex, mxCell.Vertex ? "1" : "0"));

        mxCellElement.Add(mxCell.Parent != null ? new XAttribute(MxAttributeNames.Parent, mxCell.Parent) : null);
        mxCellElement.Add(mxCell.Source != null ? new XAttribute(MxAttributeNames.Source, mxCell.Source.Value) : null);
        mxCellElement.Add(mxCell.Target != null ? new XAttribute(MxAttributeNames.Target, mxCell.Target.Value) : null);
    }

    private static void AddMxGeometryAttributes(XElement mxGeometryElement, MxGeometry mxGeometry)
    {
        mxGeometryElement.Add(mxGeometry.X != null ? new XAttribute(MxAttributeNames.X, mxGeometry.X) : null);
        mxGeometryElement.Add(mxGeometry.Y != null ? new XAttribute(MxAttributeNames.Y, mxGeometry.Y) : null);

        mxGeometryElement.Add(mxGeometry.Width != null ? new XAttribute(MxAttributeNames.Width, mxGeometry.Width) : null);
        mxGeometryElement.Add(mxGeometry.Height != null ? new XAttribute(MxAttributeNames.Height, mxGeometry.Height) : null);

        mxGeometryElement.Add(new XAttribute(MxAttributeNames.As, mxGeometry.As));
        mxGeometryElement.Add(mxGeometry.Relative ? new XAttribute(MxAttributeNames.Relative, "1") : null);
    }
}
