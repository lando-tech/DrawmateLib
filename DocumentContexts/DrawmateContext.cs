using System.Xml.Linq;
using DrawmateLib.Builders;
using DrawmateLib.Configuration;
using DrawmateLib.MxGraphModels;
using DrawmateLib.Serializers;

namespace DrawmateLib.DocumentContexts;

public class DrawmateContext
{
    private readonly MxSerializer _serializer = new();
    private readonly XmlBuilder _xmlBuilder;

    /// <summary>
    /// Sets the top level XML Elements with sane defaults
    /// </summary>
    public DrawmateContext()
    {
        var diagramElement = _serializer.SerializeDiagram(new Diagram("Page-1", new MxId()));
        var mxGraphModelElement = _serializer.SerializeMxGraphModel(new MxGraphModel()
        {
            Dx = DrawioCommon.MxGraphModelCommon.Dx,
            Dy = DrawioCommon.MxGraphModelCommon.Dy,
            PageScale = DrawioCommon.MxGraphModelCommon.PageScale,
            PageHeight = DrawioCommon.MxGraphModelCommon.PageHeight,
            PageWidth = DrawioCommon.MxGraphModelCommon.PageWidth,
            GridSize = DrawioCommon.MxGraphModelCommon.GridSize,
            MxFlags = DrawioCommon.MxGraphModelCommon.Flags
        });
        _xmlBuilder = new XmlBuilder(new XDeclaration("1.0", "utf-8", "yes"), diagramElement, mxGraphModelElement);
    }

    /// <summary>
    ///  Creates the XmlBuilder instance with the provided top-level XML Elements (Diagram and MxGraphModel)
    /// and the custom XDeclaration
    /// </summary>
    /// <param name="diagram"></param>
    /// <param name="mxGraphModel"></param>
    /// <param name="xDeclaration"></param>
    public DrawmateContext(Diagram diagram, MxGraphModel mxGraphModel, XDeclaration xDeclaration)
    {
        var diagramElement = _serializer.SerializeDiagram(diagram);
        var mxGraphModelElement = _serializer.SerializeMxGraphModel(mxGraphModel);
        _xmlBuilder = new XmlBuilder(xDeclaration, diagramElement, mxGraphModelElement);
    }

    public void AddMxCell(MxCell mxCell)
    {
        _xmlBuilder.RootElement.Add(_serializer.SerializeMxCell(mxCell));
    }

    public void AddMxCells(IEnumerable<MxCell> mxCells)
    {
        foreach (var cell in mxCells)
        {
            _xmlBuilder.RootElement.Add(_serializer.SerializeMxCell(cell));
        }
    }

    public void SaveDiagram(string diagramPath)
    {
        _xmlBuilder.RootDocument.Save(diagramPath);
    }
}
