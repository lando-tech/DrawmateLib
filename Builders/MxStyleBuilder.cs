using DrawmateLib.MxGraphModels;
using DrawmateLib.Styles;

namespace DrawmateLib.Builders;

public class MxStyleBuilder
{
    private readonly MxGraphStyle _style = new();

    public MxStyleBuilder Create()
    {
        _style.ValueBuilder.Clear();
        return this;
    }

    public MxStyleBuilder TextBox()
    {
        _style.ValueBuilder.Append($"{MxStyleConstants.Shapes.Text};");
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
        _style.ValueBuilder.Append(isRounded ? $"{MxStyleConstants.Shapes.Rounded};" : "rounded=0;");
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

    public MxStyleBuilder WithCommonAttributes()
    {
        _style.ValueBuilder.Append($"{MxStyleConstants.Common.WhiteSpaceWrap};");
        _style.ValueBuilder.Append($"{MxStyleConstants.Common.Html};");
        return this;
    }

    public MxStyleBuilder WithAspect(string aspect)
    {
        _style.ValueBuilder.Append($"aspect={aspect};");
        return this;
    }

    public MxStyleBuilder Rectangle()
    {
        _style.ValueBuilder.Append($"{MxStyleConstants.Shapes.Sharp};");
        return this;
    }

    public MxStyleBuilder Ellipse()
    {
        _style.ValueBuilder.Append($"{MxStyleConstants.Shapes.Ellipse};");
        return this;
    }

    public MxStyleBuilder Rhombus()
    {
        _style.ValueBuilder.Append($"{MxStyleConstants.Shapes.Rhombus};");
        return this;
    }

    public MxStyleBuilder Triangle()
    {
        _style.ValueBuilder.Append($"{MxStyleConstants.Shapes.Triangle};");
        return this;
    }

    public MxStyleBuilder WithShape(string shape)
    {
        _style.ValueBuilder.Append($"shape={shape};");
        return this;
    }

    public MxGraphStyle Build(bool withCommonAttributes)
    {
        if (withCommonAttributes)
        {
            WithCommonAttributes();
        }
        _style.Value = _style.ValueBuilder.ToString();
        return _style;
    }
}
