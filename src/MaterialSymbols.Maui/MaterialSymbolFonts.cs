namespace MaterialSymbols.Maui;

/// <summary>Font aliases and file names bundled by the package.</summary>
public static class MaterialSymbolFonts
{
    public const string Outlined = "MaterialSymbolsOutlined";
    public const string OutlinedFilled = "MaterialSymbolsOutlinedFilled";
    public const string Rounded = "MaterialSymbolsRounded";
    public const string RoundedFilled = "MaterialSymbolsRoundedFilled";
    public const string Sharp = "MaterialSymbolsSharp";
    public const string SharpFilled = "MaterialSymbolsSharpFilled";

    internal const string OutlinedFile = "MaterialSymbolsOutlined-Regular.ttf";
    internal const string OutlinedFilledFile = "MaterialSymbolsOutlinedFilled-Regular.ttf";
    internal const string RoundedFile = "MaterialSymbolsRounded-Regular.ttf";
    internal const string RoundedFilledFile = "MaterialSymbolsRoundedFilled-Regular.ttf";
    internal const string SharpFile = "MaterialSymbolsSharp-Regular.ttf";
    internal const string SharpFilledFile = "MaterialSymbolsSharpFilled-Regular.ttf";

    public static string GetFontFamily(MaterialSymbolVariant variant, bool filled = false)
    {
        return (variant, filled) switch
        {
            (MaterialSymbolVariant.Outlined, false) => Outlined,
            (MaterialSymbolVariant.Outlined, true) => OutlinedFilled,
            (MaterialSymbolVariant.Rounded, false) => Rounded,
            (MaterialSymbolVariant.Rounded, true) => RoundedFilled,
            (MaterialSymbolVariant.Sharp, false) => Sharp,
            (MaterialSymbolVariant.Sharp, true) => SharpFilled,
            _ => throw new ArgumentOutOfRangeException(nameof(variant), variant, null),
        };
    }

    internal static IEnumerable<(string File, string Alias)> All
    {
        get
        {
            yield return (OutlinedFile, Outlined);
            yield return (OutlinedFilledFile, OutlinedFilled);
            yield return (RoundedFile, Rounded);
            yield return (RoundedFilledFile, RoundedFilled);
            yield return (SharpFile, Sharp);
            yield return (SharpFilledFile, SharpFilled);
        }
    }
}
