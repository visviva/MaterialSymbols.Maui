namespace MaterialSymbols.Maui;

public static class MaterialSymbolsBuilderExtensions
{
    /// <summary>Registers all Material Symbols font variants with a MAUI application.</summary>
    public static MauiAppBuilder UseMaterialSymbols(this MauiAppBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.ConfigureFonts(fonts =>
        {
            foreach ((string file, string alias) in MaterialSymbolFonts.All)
            {
                fonts.AddFont(file, alias);
            }
        });

        return builder;
    }
}
