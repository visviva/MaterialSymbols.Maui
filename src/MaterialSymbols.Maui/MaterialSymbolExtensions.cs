namespace MaterialSymbols.Maui;

public static class MaterialSymbolExtensions
{
    /// <summary>Returns the Unicode glyph represented by a symbol.</summary>
    public static string ToGlyph(this MaterialSymbol symbol)
    {
        int codePoint = (int)symbol;
        return codePoint == 0 ? string.Empty : char.ConvertFromUtf32(codePoint);
    }
}
