namespace MaterialSymbols.Maui;

/// <summary>Creates MAUI image sources from named Material Symbols.</summary>
public static class MaterialSymbolImageSource
{
    public static FontImageSource Create(
        MaterialSymbol icon,
        MaterialSymbolVariant variant = MaterialSymbolVariant.Outlined,
        bool filled = false,
        double size = 24,
        Color? color = null,
        bool fontAutoScalingEnabled = false
    )
    {
        var source = new FontImageSource
        {
            Glyph = icon.ToGlyph(),
            FontFamily = MaterialSymbolFonts.GetFontFamily(variant, filled),
            Size = size,
            FontAutoScalingEnabled = fontAutoScalingEnabled,
        };

        if (color is not null)
        {
            source.Color = color;
        }

        return source;
    }
}
