using System.Xml.Linq;
using DrawmateLib.DocumentBuilder;
using DrawmateLib.MxGraph;

var mxSerializer = new MxSerializer();

var diagram = new Diagram("Page-1", new MxId());
var mxGraphModel = new MxGraphModel()
{
    Dx = 4000,
    Dy = 4000,
    PageHeight = 3000,
    PageWidth = 3000,
    PageScale = 10,
    GridSize = 10,
    MxFlags = MxGraphModelFlags.Grid | MxGraphModelFlags.Guides | MxGraphModelFlags.ToolTips
};
var declaration = new XDeclaration("1.0", "utf-8", "yes");

var diagramElement = mxSerializer.SerializeDiagram(diagram);
var mxGraphModelElement = mxSerializer.SerializeMxGraphModel(mxGraphModel);

var builder = new XmlBuilder(
    declaration,
    diagramElement,
    mxGraphModelElement
);

var doc = builder.RootDocument;
var root = builder.RootElement;


var mxCellOne = new MxCellBuilder()
    .CreateNew("This is a label", "textbox;alignVertical")
    .WithGeometry(25.0m, 25.0m, 50, 50)
    .Build();

var mxCellElement = mxSerializer.SerializeMxCell(mxCellOne);
root.Add(mxCellElement);

doc.Save(Console.Out);
