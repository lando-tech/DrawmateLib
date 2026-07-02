using System.Xml.Linq;

namespace DrawmateLib.DocumentBuilder;

public class XmlBuilder
{
    public XDocument RootDocument { get; } = new XDocument();
    public XDeclaration Declaration { get; }
    public XElement MxFileElement { get; } = new XElement(MxElementNames.MxFile);
    public XElement DiagramElement { get; }
    public XElement MxGraphModelElement { get; }
    public XElement RootElement { get; } = new XElement(MxElementNames.Root);

    public XmlBuilder(XDeclaration xmlDeclaration)
    {
        DiagramElement = new XElement(MxElementNames.Diagram);
        MxGraphModelElement = new XElement(MxElementNames.MxGraphModel);
        Declaration = xmlDeclaration;
        BuildDocumentTree();
    }

    public XmlBuilder(XDeclaration xmlDeclaration, XElement mxGraphModelElement)
    {
        DiagramElement = new XElement(MxElementNames.Diagram);
        MxGraphModelElement = mxGraphModelElement;
        Declaration = xmlDeclaration;
        BuildDocumentTree();
    }

    public XmlBuilder(XDeclaration xmlDeclaration, XElement diagramElement, XElement mxGraphModelElement)
    {
        DiagramElement = diagramElement;
        MxGraphModelElement = mxGraphModelElement;
        Declaration = xmlDeclaration;
        BuildDocumentTree();
    }

    private void BuildDocumentTree()
    {
        MxFileElement.Add(DiagramElement);
        DiagramElement.Add(MxGraphModelElement);
        RootElement.Add(
            new XElement(MxElementNames.MxCell, new XAttribute(MxAttributeNames.Id, "0")),
            new XElement(MxElementNames.MxCell, new XAttribute(MxAttributeNames.Id, "1"), new XAttribute(MxAttributeNames.Parent, "0"))
        );

        RootDocument.Add(Declaration);
        RootDocument.Add(MxFileElement);
    }
}
