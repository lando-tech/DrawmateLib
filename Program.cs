using DrawmateLib.MxGraph;

var cell1 = new MxCell("Cell 1", "style;goes;here", 1);
Console.WriteLine($"Cell ID    : {cell1.Id.Value}");
Console.WriteLine($"Cell Label : {cell1.ValueLabel}");
Console.WriteLine($"Cell Style : {cell1.Style.Value}");
