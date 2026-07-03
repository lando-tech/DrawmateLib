using DrawmateLib.MxGraphModels;

namespace DrawmateLib.Builders;

public class MxStyleBuilder
{
    private MxGraphStyle _style;

    public MxStyleBuilder()
    {
        _style = new MxGraphStyle();
    }

    public MxStyleBuilder Create()
    {
        _style.ValueBuilder.Clear();
        return this;
    }

    public MxStyleBuilder TextBox()
    {
        _style.ValueBuilder.Append("text;");
        return this;
    }

    public MxStyleBuilder Rectangle()
    {
        return this;
    }

    public MxStyleBuilder WithFillColor(string color)
    {
        _style.ValueBuilder.Append($"fillColor={color};");
        return this;
    }

    public MxStyleBuilder WithStrokeColor(string color)
    {
        _style.ValueBuilder.Append($"strokeColor={color};");
        return this;
    }

    public MxStyleBuilder WithRounded(bool isRounded)
    {
        _style.ValueBuilder.Append($"rounded=" + (isRounded ? "1" : "0") + ";");
        return this;
    }

    public MxStyleBuilder WithAlignment(string alignment)
    {
        _style.ValueBuilder.Append($"align={alignment};");
        return this;
    }

    public MxStyleBuilder WithVerticalAlignment(string alignment)
    {
        _style.ValueBuilder.Append($"verticalAlign={alignment};");
        return this;
    }

    public MxStyleBuilder WithTextWrapping()
    {
        _style.ValueBuilder.Append("whiteSpace=wrap;");
        _style.ValueBuilder.Append("html=1;");
        return this;
    }

    public MxStyleBuilder WithAspect(string aspect)
    {
        _style.ValueBuilder.Append($"aspect={aspect};");
        return this;
    }

    public MxGraphStyle Build()
    {
        _style.Value = _style.ValueBuilder.ToString();
        return _style;
    }
}
