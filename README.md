# DrawmateLib

[![NuGet](https://img.shields.io/nuget/v/DrawmateLib.svg)](https://www.nuget.org/packages/DrawmateLib)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

A .NET library for programmatically generating [draw.io](https://app.diagrams.net/) (diagrams.net) XML diagrams using a fluent builder API.

## Installation

```shell
dotnet add package DrawmateLib
```

## Quick Start

```csharp
using DrawmateLib.Builders;
using DrawmateLib.DocumentContexts;

var drawmateContext = new DrawmateContext();
var styleBuilder = new MxStyleBuilder();
var cellBuilder = new MxCellBuilder();

// Create a rectangle
var rectangle = cellBuilder
    .Create("My Box", styleBuilder.Create().Rectangle().Build(true).Value)
    .WithGeometry(100m, 100m, 120, 60)
    .Build();

// Create an ellipse
var ellipse = cellBuilder
    .Create("My Circle", styleBuilder.Ellipse().WithAspect("fixed").Build(true).Value)
    .WithGeometry(300m, 100m, 80, 80)
    .Build();

// Connect them with an edge
var edge = cellBuilder
    .Create("", styleBuilder.Create().AsEdge().Build(false).Value)
    .AsEdge(rectangle.Id, ellipse.Id)
    .Build();

drawmateContext.AddMxCell(rectangle);
drawmateContext.AddMxCell(ellipse);
drawmateContext.AddMxCell(edge);
drawmateContext.SaveDiagram("output.drawio.xml");
```

## API Overview

### `DrawmateContext`

The entry point for building a diagram. Manages the XML document tree and exposes methods to add cells and save the output.

| Method | Description |
|---|---|
| `AddMxCell(MxCell)` | Adds a single cell to the diagram |
| `AddMxCells(IEnumerable<MxCell>)` | Adds multiple cells at once |
| `SaveDiagram(string path)` | Writes the diagram XML to a file |

### `MxCellBuilder`

Fluent builder for creating `MxCell` objects (shapes and edges).

| Method | Description |
|---|---|
| `Create(label, styleName)` | Starts a new cell with the given label and style string |
| `WithGeometry(x, y, width, height)` | Positions and sizes the cell |
| `AsEdge(sourceId, targetId)` | Configures the cell as a directed edge |
| `WithCustomParent(parentId)` | Sets a non-default parent cell |
| `Build()` | Produces the final `MxCell` |

### `MxStyleBuilder`

Fluent builder for constructing draw.io style strings.

| Method | Description |
|---|---|
| `Create()` | Resets and starts a new style |
| `Rectangle()` | Applies a sharp-cornered rectangle style |
| `Ellipse()` | Applies an ellipse style |
| `Rhombus()` | Applies a rhombus (diamond) style |
| `Triangle()` | Applies a triangle style |
| `TextBox()` | Applies a plain text style |
| `AsEdge()` | Applies an orthogonal edge style |
| `WithFillColor(color)` | Sets the fill color (e.g. `"#ffffff"`) |
| `WithStrokeColor(color)` | Sets the stroke/border color |
| `WithRounded(bool)` | Toggles rounded corners |
| `WithAlignment(string)` | Sets horizontal text alignment |
| `WithVerticalAlignment(string)` | Sets vertical text alignment |
| `WithAspect(string)` | Sets the aspect attribute (e.g. `"fixed"`) |
| `WithShape(string)` | Sets a custom shape name |
| `Build(withCommonAttributes)` | Returns the built `MxGraphStyle` |

Use `MxStyleConstants` for pre-defined values for colors, alignments, and shape names.

## License

MIT © Aaron Newman, lando-tech
