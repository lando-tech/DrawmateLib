using DrawmateLib.DocumentBuilder;
using DrawmateLib.MxGraph;

var builder = new XmlBuilder();
var doc = builder.RootDocument;
var root = builder.RootElement;

var translator = new MxTranslator();
int cellCount = 0;

var mxCellOne = new MxCell("Cell One", "textbox", ++cellCount)
{
    Connectable = true,
    Edge = false,
    Vertex = false
};

var mxCellElement = translator.TranslateMxCell(mxCellOne);
root.Add(mxCellElement);

doc.Save(Console.Out);
