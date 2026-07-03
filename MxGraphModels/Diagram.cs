namespace DrawmateLib.MxGraphModels;

public class Diagram(string pageName, MxId mxId)
{
    public string PageName { get; set; } = pageName;
    public MxId Id { get; set; } = mxId;
}
