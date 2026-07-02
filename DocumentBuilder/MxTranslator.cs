using System.Xml.Linq;
using DrawmateLib.MxGraph;

namespace DrawmateLib.DocumentBuilder;

public class MxTranslator
{
    public XElement TranslateMxCell(MxCell mxCell)
    {
        var mxCellElement = new XElement(MxElementNames.MxCell);
        CreateMxCellElementWithAttributes(mxCellElement, mxCell);
        return mxCellElement;
    }

    public XElement TranslateMxGeometry()
    {
        return new XElement(MxElementNames.MxGeometry);
    }

    public XElement TranslateMxArray()
    {
        return new XElement(MxElementNames.MxArray);
    }

    private static void CreateMxCellElementWithAttributes(XElement mxCellElement,MxCell mxCell)
    {
        mxCellElement.Add(new XAttribute(MxAttributeNames.Id, mxCell.Id.Value));
        mxCellElement.Add(new XAttribute(MxAttributeNames.Value, mxCell.ValueLabel ?? ""));
        mxCellElement.Add(new XAttribute(MxAttributeNames.Style, mxCell.Style.Value));

        mxCellElement.Add(new XAttribute(MxAttributeNames.Connectable, mxCell.Connectable ? "1" : "0"));
        mxCellElement.Add(new XAttribute(MxAttributeNames.Edge, mxCell.Edge ? "1" : "0"));
        mxCellElement.Add(new XAttribute(MxAttributeNames.Vertex, mxCell.Vertex ? "1" : "0"));

        mxCellElement.Add(mxCell.Parent != null ? new XAttribute(MxAttributeNames.Parent, mxCell.Parent.Value) : null);
        mxCellElement.Add(mxCell.Source != null ? new XAttribute(MxAttributeNames.Source, mxCell.Source.Value) : null);
        mxCellElement.Add(mxCell.Target != null ? new XAttribute(MxAttributeNames.Target, mxCell.Target.Value) : null);
    }
}
