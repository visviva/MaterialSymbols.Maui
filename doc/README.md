# MaterialSymbols.Maui documentation

MaterialSymbols.Maui packages Google Material Symbols as named, strongly typed APIs for .NET MAUI. Start with the usage guide if you are consuming the NuGet package. Use the architecture and maintenance guides when changing the library itself.

## Guides

- [Getting started](getting-started.md) — installation, registration, XAML, C#, binding, and common UI scenarios.
- [API reference](api-reference.md) — every public type, member, default value, and behavior.
- [Architecture](architecture.md) — how a symbol travels from an enum value to a rendered glyph.
- [NuGet packaging](packaging.md) — package layout, `buildTransitive`, font delivery, packing, and release behavior.
- [Updating Material Symbols](updating-symbols.md) — reproducible generation of the enum and six static fonts.

## Supported variants

The package contains three shape families, each in unfilled and filled form:

| `MaterialSymbolVariant` | Unfilled alias | Filled alias |
| --- | --- | --- |
| `Outlined` | `MaterialSymbolsOutlined` | `MaterialSymbolsOutlinedFilled` |
| `Rounded` | `MaterialSymbolsRounded` | `MaterialSymbolsRoundedFilled` |
| `Sharp` | `MaterialSymbolsSharp` | `MaterialSymbolsSharpFilled` |

All six files are fixed instances of Google's variable fonts at optical size 24, weight 400, grade 0, and fill 0 or 1. The `Size` or `FontSize` API scales that fixed instance; it does not change a variable-font axis.

## Repository map

```text
src/MaterialSymbols.Maui/             Library and NuGet package
  Resources/Fonts/                    Six generated static fonts
  buildTransitive/                    Consumer build integration
examples/MaterialSymbols.Maui.Demo/   Runnable Shell example
eng/                                  Upstream generator and provenance
doc/                                  Contributor and consumer documentation
```

The library currently targets `net10.0`. The demo validates Android, iOS, Mac Catalyst, and Windows consumption.
