namespace DrawmateLib.MxGraphModels;

/// <summary>
/// The Diagram is 1 out of the 5 top-level XML elements that make up a valid draw.io
/// XML file. The Diagram element serves to set the page name, setting the stage for
/// multipage XML diagrams.
/// </summary>
/// <param name="pageName">The name of the page</param>
/// <param name="mxId">MxId object</param>
public class Diagram(string pageName, MxId mxId)
{
    public string PageName { get; set; } = pageName;
    public MxId Id { get; set; } = mxId;
}
