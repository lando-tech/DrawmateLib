using System.Xml.Linq;
using DrawmateLib.MxGraphModels;

namespace DrawmateLib.Builders;

public class XmlBuilder
{
    public XDocument RootDocument { get; }
    public XElement MxFileElement { get; }
    public XElement DiagramElement { get; }
    public XElement MxGraphModelElement { get; }
    public XElement RootElement { get; }

    public XmlBuilder(XDeclaration xmlDeclaration)
    {
        RootDocument = new XDocument(xmlDeclaration);
        MxFileElement = new XElement(MxElement.MxFile);
        DiagramElement = new XElement(MxElement.Diagram);
        MxGraphModelElement = new XElement(MxElement.MxGraphModel);
        RootElement = new XElement(MxElement.Root);
        BuildDocumentTree();
    }

    public XmlBuilder(XDeclaration xmlDeclaration, XElement mxGraphModelElement)
    {
        RootDocument = new XDocument(xmlDeclaration);
        MxFileElement = new XElement(MxElement.MxFile);
        DiagramElement = new XElement(MxElement.Diagram);
        MxGraphModelElement = mxGraphModelElement;
        RootElement = new XElement(MxElement.Root);
        BuildDocumentTree();
    }

    public XmlBuilder(XDeclaration xmlDeclaration, XElement diagramElement, XElement mxGraphModelElement)
    {
        RootDocument = new XDocument(xmlDeclaration);
        MxFileElement = new XElement(MxElement.MxFile);
        DiagramElement = diagramElement;
        MxGraphModelElement = mxGraphModelElement;
        RootElement = new XElement(MxElement.Root);
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
