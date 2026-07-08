using DrawmateLib.MxGraphModels;

namespace DrawmateLib.Configuration;

public static class DrawmateCommon
{
    public static class MxGraphModelCommon
    {
        public const int Dx = 1329;
        public const int Dy = 802;
        public const int GridSize = 10;
        public const int PageScale = 1;
        public const int PageHeight = 1100;
        public const int PageWidth = 850;
        public const MxGraphModelFlags Flags = MxGraphModelFlags.Grid | MxGraphModelFlags.Guides | MxGraphModelFlags.ToolTips | MxGraphModelFlags.Connect | MxGraphModelFlags.Arrows | MxGraphModelFlags.Fold;
    }
}
