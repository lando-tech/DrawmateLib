using DrawmateLib.Builders;
using DrawmateLib.DocumentContexts;

// -------------------------------------------------------
// Sample: Build a simple draw.io diagram with DrawmateLib
// -------------------------------------------------------

var drawmateContext = new DrawmateContext();
var mxStyleBuilder = new MxStyleBuilder();
var mxCellBuilder = new MxCellBuilder();

var mxCellOne = mxCellBuilder
    .Create(
        "Cell 1",
        mxStyleBuilder.Create().Rectangle().Build(true).Value)
    .WithGeometry(400.0m, 400.0m, 50, 50)
    .Build();

var mxCellTwo = mxCellBuilder
    .Create(
        "Cell 2",
        mxStyleBuilder.Create().Rectangle().Build(true).Value)
    .WithGeometry(100.0m, 100.0m, 50, 50)
    .Build();

var mxCellThree = mxCellBuilder
    .Create("Cell 3", mxStyleBuilder.Ellipse().WithAspect("fixed").Build(true).Value)
    .WithGeometry(200.0m, 200.0m, 80, 80)
    .Build();

var edgeOne = mxCellBuilder
    .Create(
        "Edge 1",
        mxStyleBuilder.Create().AsEdge().Build(false).Value)
    .AsEdge(mxCellOne.Id, mxCellTwo.Id)
    .Build();

string homePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
string fileName = "test.drawio.xml";
string filePath = $"{homePath}/Documents/{fileName}";

drawmateContext.AddMxCell(mxCellOne);
drawmateContext.AddMxCell(mxCellTwo);
drawmateContext.AddMxCell(mxCellThree);
drawmateContext.AddMxCell(edgeOne);
drawmateContext.SaveDiagram(filePath);

Console.WriteLine($"Diagram saved to: {filePath}");
