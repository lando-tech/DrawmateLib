using System.Xml.Linq;

namespace DrawmateLib.DocumentBuilder;

public class XmlBuilder
{
    public XDocument RootDocument { get; set; }
    public XElement MxFileElement { get; set; }
    public XElement DiagramElement { get; }
    public XElement MxGraphModelElement { get; set; }
    public XElement RootElement { get; } = new XElement(MxElement.Root);

    public XmlBuilder(XDeclaration xmlDeclaration)
    {
        RootDocument = new XDocument(xmlDeclaration);
        MxFileElement = new XElement(MxElement.MxFile);
        DiagramElement = new XElement(MxElement.Diagram);
        MxGraphModelElement = new XElement(MxElement.MxGraphModel);
        BuildDocumentTree();
    }

    public XmlBuilder(XDeclaration xmlDeclaration, XElement mxGraphModelElement)
    {
        RootDocument = new XDocument(xmlDeclaration);
        MxFileElement = new XElement(MxElement.MxFile);
        DiagramElement = new XElement(MxElement.Diagram);
        MxGraphModelElement = mxGraphModelElement;
        BuildDocumentTree();
    }

    public XmlBuilder(XDeclaration xmlDeclaration, XElement diagramElement, XElement mxGraphModelElement)
    {
        RootDocument = new XDocument(xmlDeclaration);
        MxFileElement = new XElement(MxElement.MxFile);
        DiagramElement = diagramElement;
        MxGraphModelElement = mxGraphModelElement;
        BuildDocumentTree();
    }

    private void BuildDocumentTree()
    {
        MxFileElement.Add(DiagramElement);
        DiagramElement.Add(MxGraphModelElement);
        RootElement.Add(
            new XElement(MxElement.MxCell, new XAttribute(MxAttribute.Id, "0")),
            new XElement(MxElement.MxCell, new XAttribute(MxAttribute.Id, "1"), new XAttribute(MxAttribute.Parent, "0"))
        );
        MxGraphModelElement.Add(RootElement);
        RootDocument.Add(MxFileElement);
    }
}
