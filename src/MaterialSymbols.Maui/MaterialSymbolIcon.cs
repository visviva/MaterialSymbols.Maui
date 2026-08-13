namespace MaterialSymbols.Maui;

/// <summary>A label-based control that displays a named Material Symbol.</summary>
public sealed class MaterialSymbolIcon : Label
{
    public static readonly BindableProperty IconProperty = BindableProperty.Create(
        nameof(Icon),
        typeof(MaterialSymbol),
        typeof(MaterialSymbolIcon),
        MaterialSymbol.None,
        propertyChanged: OnSymbolPropertyChanged
    );

    public static readonly BindableProperty VariantProperty = BindableProperty.Create(
        nameof(Variant),
        typeof(MaterialSymbolVariant),
        typeof(MaterialSymbolIcon),
        MaterialSymbolVariant.Outlined,
        propertyChanged: OnSymbolPropertyChanged
    );

    public static readonly BindableProperty FilledProperty = BindableProperty.Create(
        nameof(Filled),
        typeof(bool),
        typeof(MaterialSymbolIcon),
        false,
        propertyChanged: OnSymbolPropertyChanged
    );

    public MaterialSymbolIcon()
    {
        FontAutoScalingEnabled = false;
        HorizontalTextAlignment = TextAlignment.Center;
        VerticalTextAlignment = TextAlignment.Center;
        UpdateSymbol();
    }

    public MaterialSymbol Icon
    {
        get => (MaterialSymbol)GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }

    public MaterialSymbolVariant Variant
    {
        get => (MaterialSymbolVariant)GetValue(VariantProperty);
        set => SetValue(VariantProperty, value);
    }

    public bool Filled
    {
        get => (bool)GetValue(FilledProperty);
        set => SetValue(FilledProperty, value);
    }

    private static void OnSymbolPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        ((MaterialSymbolIcon)bindable).UpdateSymbol();
    }

    private void UpdateSymbol()
    {
        Text = Icon.ToGlyph();
        FontFamily = MaterialSymbolFonts.GetFontFamily(Variant, Filled);
    }
}
