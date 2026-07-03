using System.Text;

namespace DrawmateLib.MxGraphModels;

public class MxGraphStyle
{
    public string Value { get; set; }
    public StringBuilder ValueBuilder { get; set; }

    public MxGraphStyle()
    {
        ValueBuilder = new StringBuilder();
        Value = "";
    }

    public MxGraphStyle(string value)
    {
        Value = value;
        ValueBuilder = new StringBuilder();
    }
}
