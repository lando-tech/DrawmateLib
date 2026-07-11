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
            Dx = DrawmateCommon.MxGraphModelCommon.Dx,
            Dy = DrawmateCommon.MxGraphModelCommon.Dy,
            PageScale = DrawmateCommon.MxGraphModelCommon.PageScale,
            PageHeight = DrawmateCommon.MxGraphModelCommon.PageHeight,
            PageWidth = DrawmateCommon.MxGraphModelCommon.PageWidth,
            GridSize = DrawmateCommon.MxGraphModelCommon.GridSize,
            MxFlags = DrawmateCommon.MxGraphModelCommon.Flags
        });
        _xmlBuilder = new XmlBuilder(new XDeclaration("1.0", "utf-8", "yes"), diagramElement, mxGraphModelElement);
    }

    /// <summary>
    ///  Creates the XmlBuilder instance with the provided top-level XML Elements (Diagram and MxGraphModel)
    /// and the custom XDeclaration
    /// </summary>
    /// <param name="diagram">An instance of the Diagram object</param>
    /// <param name="mxGraphModel">An instance of the MxGraphModel object</param>
    /// <param name="xDeclaration">An instance of the XDeclaration object</param>
    public DrawmateContext(Diagram diagram, MxGraphModel mxGraphModel, XDeclaration xDeclaration)
    {
        var diagramElement = _serializer.SerializeDiagram(diagram);
        var mxGraphModelElement = _serializer.SerializeMxGraphModel(mxGraphModel);
        _xmlBuilder = new XmlBuilder(xDeclaration, diagramElement, mxGraphModelElement);
    }

    /// <summary>
    /// Adds the provided MxCell to the root element
    /// </summary>
    /// <param name="mxCell">An instance of MxCell</param>
    public void AddMxCell(MxCell mxCell)
    {
        _xmlBuilder.RootElement.Add(_serializer.SerializeMxCell(mxCell));
    }

    /// <summary>
    /// Iteratively adds MxCells to the root element
    /// </summary>
    /// <param name="mxCells">A collection of MxCell objects</param>
    public void AddMxCells(IEnumerable<MxCell> mxCells)
    {
        foreach (var cell in mxCells)
        {
            _xmlBuilder.RootElement.Add(_serializer.SerializeMxCell(cell));
        }
    }

    /// <summary>
    /// Saves the diagram to the given path
    /// </summary>
    /// <param name="diagramPath">The path to save the diagram</param>
    public void SaveDiagram(string diagramPath)
    {
        _xmlBuilder.RootDocument.Save(diagramPath);
    }
}
