using DrawmateLib.DocumentBuilder;

var builder = new XmlBuilder();
var doc = builder.RootDocument;
var root = builder.RootElement;

var mxSerializer = new MxSerializer();

var mxCellOne = new MxCellBuilder()
    .CreateNew("This is a label", "textbox;alignVertical")
    .WithGeometry(25.0m, 25.0m, 50, 50)
    .Build();

var mxCellElement = mxSerializer.SerializeMxCell(mxCellOne);
root.Add(mxCellElement);

doc.Save(Console.Out);
