using System.Xml.Linq;

namespace DrawmateLib.DocumentBuilder;

public static class MxElement
{
    public static readonly XName MxFile = "mxfile";
    public static readonly XName Diagram = "diagram";
    public static readonly XName MxGraphModel = "mxGraphModel";
    public static readonly XName Root = "root";
    public static readonly XName MxCell = "mxCell";
    public static readonly XName MxGeometry = "mxGeometry";
    public static readonly XName MxArray = "mxArray";
}
