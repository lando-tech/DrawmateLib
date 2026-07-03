using System.Xml.Linq;
using DrawmateLib.MxGraphModels;

namespace DrawmateLib.Serializers;

public class MxSerializer
{
    public XElement SerializeMxCell(MxCell mxCell)
    {
        var mxCellElement = new XElement(MxElement.MxCell);
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
        var mxGeometryElement = new XElement(MxElement.MxGeometry);
        AddMxGeometryAttributes(mxGeometryElement, mxGeometry);
        return mxGeometryElement;
    }

    public XElement SerializeMxArray()
    {
        return new XElement(MxElement.MxArray);
    }

    public XElement SerializeMxGraphModel(MxGraphModel mxGraphModel)
    {
        var mxGraphElement = new XElement(MxElement.MxGraphModel);
        AddMxGraphModelAttributes(mxGraphElement, mxGraphModel);
        return mxGraphElement;
    }

    public XElement SerializeDiagram(Diagram diagram)
    {
        var diagramElement = new XElement(MxElement.Diagram);
        AddDiagramAttributes(diagramElement, diagram);
        return diagramElement;
    }

    private static void AddMxCellAttributes(XElement mxCellElement, MxCell mxCell)
    {
        mxCellElement.Add(new XAttribute(MxAttribute.Id, mxCell.Id.Value));
        mxCellElement.Add(new XAttribute(MxAttribute.Value, mxCell.ValueLabel ?? ""));
        mxCellElement.Add(new XAttribute(MxAttribute.Style, mxCell.Style.Value));

        mxCellElement.Add(new XAttribute(MxAttribute.Connectable, mxCell.Connectable ? "1" : "0"));
        mxCellElement.Add(new XAttribute(MxAttribute.Edge, mxCell.Edge ? "1" : "0"));
        mxCellElement.Add(new XAttribute(MxAttribute.Vertex, mxCell.Vertex ? "1" : "0"));

        mxCellElement.Add(mxCell.Parent != null ? new XAttribute(MxAttribute.Parent, mxCell.Parent) : null);
        mxCellElement.Add(mxCell.Source != null ? new XAttribute(MxAttribute.Source, mxCell.Source.Value) : null);
        mxCellElement.Add(mxCell.Target != null ? new XAttribute(MxAttribute.Target, mxCell.Target.Value) : null);
    }

    private static void AddMxGeometryAttributes(XElement mxGeometryElement, MxGeometry mxGeometry)
    {
        mxGeometryElement.Add(mxGeometry.X != null ? new XAttribute(MxAttribute.X, mxGeometry.X) : null);
        mxGeometryElement.Add(mxGeometry.Y != null ? new XAttribute(MxAttribute.Y, mxGeometry.Y) : null);

        mxGeometryElement.Add(mxGeometry.Width != null ? new XAttribute(MxAttribute.Width, mxGeometry.Width) : null);
        mxGeometryElement.Add(mxGeometry.Height != null ? new XAttribute(MxAttribute.Height, mxGeometry.Height) : null);

        mxGeometryElement.Add(new XAttribute(MxAttribute.As, mxGeometry.As));
        mxGeometryElement.Add(mxGeometry.Relative ? new XAttribute(MxAttribute.Relative, "1") : null);
    }

    private static void AddMxGraphModelAttributes(XElement mxGraphElement, MxGraphModel mxGraphModel)
    {
        mxGraphElement.Add(new XAttribute(MxAttribute.Dx, mxGraphModel.Dx));
        mxGraphElement.Add(new XAttribute(MxAttribute.Dy, mxGraphModel.Dy));
        mxGraphElement.Add(new XAttribute(MxAttribute.PageHeight, mxGraphModel.PageHeight));
        mxGraphElement.Add(new XAttribute(MxAttribute.PageWidth, mxGraphModel.PageWidth));
        mxGraphElement.Add(new XAttribute(MxAttribute.GridSize, mxGraphModel.GridSize));

        foreach (MxGraphModelFlags flag in Enum.GetValues<MxGraphModelFlags>())
        {
            if (flag == MxGraphModelFlags.None)
            {
                continue;
            }

            if (mxGraphModel.MxFlags.HasFlag(flag))
            {
                mxGraphElement.Add(new XAttribute(MxAttribute.MatchNameWithFlag(flag), "1"));
            }
            else
            {
                mxGraphElement.Add(new XAttribute(MxAttribute.MatchNameWithFlag(flag), "0"));
            }
        }
    }

    private static void AddDiagramAttributes(XElement diagramElement, Diagram diagram)
    {
        diagramElement.Add(new XAttribute(MxAttribute.Name, diagram.PageName));
        diagramElement.Add(new XAttribute(MxAttribute.Id, diagram.Id.Value));
    }
}
