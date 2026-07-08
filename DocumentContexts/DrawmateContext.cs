using System.Xml.Linq;
using DrawmateLib.Builders;
using DrawmateLib.Configuration;
using DrawmateLib.MxGraphModels;
using DrawmateLib.Serializers;

namespace DrawmateLib.DocumentContexts;

public class DrawmateContext
{
    private readonly XElement diagramElement;
    private readonly XElement mxGraphModelElement;
    private readonly MxSerializer serializer = new();

    private readonly XmlBuilder xmlBuilder;

    public DrawmateContext()
    {
        diagramElement = serializer.SerializeDiagram(new Diagram("Page-1", new MxId()));
        mxGraphModelElement = serializer.SerializeMxGraphModel(new MxGraphModel()
        {
            Dx = DrawioCommon.MxGraphModelCommon.Dx,
            Dy = DrawioCommon.MxGraphModelCommon.Dy,
            PageScale = DrawioCommon.MxGraphModelCommon.PageScale,
            PageHeight = DrawioCommon.MxGraphModelCommon.PageHeight,
            PageWidth = DrawioCommon.MxGraphModelCommon.PageWidth,
            GridSize = DrawioCommon.MxGraphModelCommon.GridSize,
            MxFlags = DrawioCommon.MxGraphModelCommon.Flags
        });
        xmlBuilder = new(new XDeclaration("1.0", "utf-8", "yes"), diagramElement, mxGraphModelElement);
    }

    public void AddMxCell(MxCell mxCell)
    {
        xmlBuilder.RootElement.Add(serializer.SerializeMxCell(mxCell));
    }

    public void SaveDiagram(string diagramPath)
    {
        xmlBuilder.RootDocument.Save(diagramPath);
    }
}
