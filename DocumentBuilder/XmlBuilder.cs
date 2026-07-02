using System.Xml.Linq;

namespace DrawmateLib.DocumentBuilder;

public class XmlBuilder
{
    public XDocument RootDocument { get; }
    public XDeclaration Declaration { get; }
    public XElement MxFileElement { get; } = new XElement(MxElementNames.MxFile);
    public XElement DiagramElement { get; } = new XElement(MxElementNames.Diagram);
    public XElement MxGraphModelElement { get; } = new XElement(MxElementNames.MxGraphModel);
    public XElement RootElement { get; } = new XElement(MxElementNames.Root);

    public XmlBuilder() : this("1.0", "utf-8", "yes")
    {
    }

    public XmlBuilder(string? version, string? encoding, string? standalone)
    {
        MxFileElement.Add(DiagramElement);
        DiagramElement.Add(MxGraphModelElement);
        MxGraphModelElement.Add(RootElement);
        // Add Top Level MxCell Elements
        RootElement.Add(
            new XElement(MxElementNames.MxCell, new XAttribute(MxAttributeNames.Id, "0")),
            new XElement(MxElementNames.MxCell, new XAttribute(MxAttributeNames.Id, "1"), new XAttribute(MxAttributeNames.Parent, "0"))
        );

        Declaration = new XDeclaration(version, encoding, standalone);
        RootDocument = new XDocument(
            Declaration,
            MxFileElement
        );
    }

    private void SetMxGraphModelAttributes()
    {

    }

    private void SetDiagramAttributes()
    {

    }
}
