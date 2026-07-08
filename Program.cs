using DrawmateLib.Builders;
using DrawmateLib.DocumentContexts;

var drawmateContext = new DrawmateContext();

var mxStyleBuilder = new MxStyleBuilder();
var mxStyle = mxStyleBuilder
    .Create()
    .Rectangle()
    .Build(withCommonAttributes: true);

var mxCellOne = new MxCellBuilder()
    .Create("This is a label", mxStyle.Value)
    .WithGeometry(25.0m, 25.0m, 50, 50)
    .Build();

drawmateContext.AddMxCell(mxCellOne);
drawmateContext.SaveDiagram("./DrawioTestFiles/test3.drawio.xml");
