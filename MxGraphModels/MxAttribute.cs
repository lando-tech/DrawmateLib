using System.Xml.Linq;

namespace DrawmateLib.MxGraphModels;

/// <summary>
/// The MxAttribute class serves as a definition for common draw.io
/// XML attributes across various XML elements.
/// </summary>
public static class MxAttribute
{
    public static readonly XName Id = "id";
    /// <summary>
    /// Value and Label are ambiguous in draw.io.
    /// When using an MxCell element, always use the Value as the true Label
    /// that will be rendered on the object. Label is an internal mechanism
    /// that will not render. This is a draw.io quirk.
    /// </summary>
    public static readonly XName Value = "value";
    public static readonly XName Label = "label";
    public static readonly XName Name = "name";
    public static readonly XName Type = "type";
    public static readonly XName Style = "style";
    public static readonly XName Parent = "parent";
    public static readonly XName Source = "source";
    public static readonly XName Target = "target";
    public static readonly XName Edge = "edge";
    public static readonly XName Vertex = "vertex";
    public static readonly XName Connectable = "connectable";
    public static readonly XName X = "x";
    public static readonly XName Y = "y";
    public static readonly XName Width = "width";
    public static readonly XName Height = "height";
    public static readonly XName As = "as";
    public static readonly XName Relative = "relative";
    public static readonly XName Grid = "grid";
    public static readonly XName GridSize = "gridSize";
    public static readonly XName Connect = "connect";
    public static readonly XName ToolTips = "tooltips";
    public static readonly XName Guides = "guides";
    public static readonly XName Dx = "dx";
    public static readonly XName Dy = "dy";
    public static readonly XName Arrows = "arrows";
    public static readonly XName Fold = "fold";
    public static readonly XName Page = "page";
    public static readonly XName PageScale = "pageScale";
    public static readonly XName PageWidth = "pageWidth";
    public static readonly XName PageHeight = "pageHeight";
    public static readonly XName Background = "background";
    public static readonly XName Math = "math";
    public static readonly XName Shadow = "shadow";

    /// <summary>
    /// Match the MxGraphModelFlag name with the proper XML attribute name
    /// </summary>
    /// <param name="flag">The flag to match</param>
    /// <returns>XName</returns>
    /// <exception cref="ArgumentException"></exception>
    public static XName MatchNameWithFlag(MxGraphModelFlags flag)
    {
        return flag switch
        {
            MxGraphModelFlags.Grid => Grid,
            MxGraphModelFlags.Guides => Guides,
            MxGraphModelFlags.ToolTips => ToolTips,
            MxGraphModelFlags.Connect => Connect,
            MxGraphModelFlags.Arrows => Arrows,
            MxGraphModelFlags.Fold => Fold,
            MxGraphModelFlags.Math => Math,
            MxGraphModelFlags.Shadow => Shadow,
            _ => throw new ArgumentException($"Unable to match: {flag} to a MxAttribute Name"),
        };
    }
}
