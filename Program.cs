using DrawmateLib.Builders;
using DrawmateLib.DocumentContexts;

var drawmateContext = new DrawmateContext();

var mxStyleBuilder = new MxStyleBuilder();
var mxCellBuilder = new MxCellBuilder();

var mxCellOne = mxCellBuilder
    .Create(
        "Cell 1",
        mxStyleBuilder.Create().Rectangle().Build(true).Value)
    .WithGeometry(25.0m, 25.0m, 50, 50)
    .Build();

var mxCellTwo = mxCellBuilder
    .Create(
        "Cell 2",
        mxStyleBuilder.Create().Rectangle().Build(true).Value)
    .WithGeometry(100.0m, 100.0m, 50, 50)
    .Build();

var edgeOne = mxCellBuilder
    .Create(
        "Edge 1",
        mxStyleBuilder.Create().AsEdge().Build(false).Value)
    .AsEdge(mxCellOne.Id, mxCellTwo.Id)
    .Build();

drawmateContext.AddMxCell(mxCellOne);
drawmateContext.AddMxCell(mxCellTwo);
drawmateContext.AddMxCell(edgeOne);
drawmateContext.SaveDiagram("./DrawioTestFiles/test5.drawio.xml");
