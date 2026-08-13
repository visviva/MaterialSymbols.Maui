namespace MaterialSymbols.Maui;

/// <summary>Creates a <see cref="FontImageSource"/> from a named Material Symbol in XAML.</summary>
[ContentProperty(nameof(Icon))]
public sealed class SymbolExtension : IMarkupExtension<ImageSource>
{
    public SymbolExtension() { }

    public SymbolExtension(MaterialSymbol icon)
    {
        Icon = icon;
    }

    public MaterialSymbol Icon { get; set; }

    public MaterialSymbolVariant Variant { get; set; } = MaterialSymbolVariant.Outlined;

    public bool Filled { get; set; }

    public double Size { get; set; } = 24;

    public Color? Color { get; set; }

    public bool FontAutoScalingEnabled { get; set; }

    public ImageSource ProvideValue(IServiceProvider serviceProvider)
    {
        return MaterialSymbolImageSource.Create(Icon, Variant, Filled, Size, Color, FontAutoScalingEnabled);
    }

    object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider) => ProvideValue(serviceProvider);
}
