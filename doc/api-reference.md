# API reference

All public APIs are in the `MaterialSymbols.Maui` namespace.

## `MaterialSymbol`

```csharp
public enum MaterialSymbol
```

A generated enum whose integer values are Google Material Symbols Unicode codepoints. `None` is zero and represents no icon. The current generated set contains 4,268 named entries; aliases can share a codepoint.

Names are converted from upstream snake-case names to PascalCase. Names beginning with a number receive an `Icon` prefix, for example `10k` becomes `Icon10K`. Use IDE completion or search `MaterialSymbol.cs` to discover a member. Do not edit this enum manually; see [Updating Material Symbols](updating-symbols.md).

## `MaterialSymbolVariant`

```csharp
public enum MaterialSymbolVariant
{
    Outlined,
    Rounded,
    Sharp,
}
```

Selects a shape family. Filled state is separate because each shape supports both unfilled and filled files.

## `MaterialSymbolExtensions`

### `ToGlyph`

```csharp
public static string ToGlyph(this MaterialSymbol symbol)
```

Converts the enum's Unicode scalar value with `char.ConvertFromUtf32`. This correctly supports symbols outside the Basic Multilingual Plane. Returns `string.Empty` for `MaterialSymbol.None`.

## `MaterialSymbolFonts`

Exposes the runtime aliases for the bundled files:

| Constant | Value |
| --- | --- |
| `Outlined` | `MaterialSymbolsOutlined` |
| `OutlinedFilled` | `MaterialSymbolsOutlinedFilled` |
| `Rounded` | `MaterialSymbolsRounded` |
| `RoundedFilled` | `MaterialSymbolsRoundedFilled` |
| `Sharp` | `MaterialSymbolsSharp` |
| `SharpFilled` | `MaterialSymbolsSharpFilled` |

### `GetFontFamily`

```csharp
public static string GetFontFamily(
    MaterialSymbolVariant variant,
    bool filled = false
)
```

Returns the alias for a `(variant, filled)` pair. It throws `ArgumentOutOfRangeException` if passed an undefined `MaterialSymbolVariant` value.

## `MaterialSymbolsBuilderExtensions`

### `UseMaterialSymbols`

```csharp
public static MauiAppBuilder UseMaterialSymbols(this MauiAppBuilder builder)
```

Adds all six font file/alias pairs through `ConfigureFonts` and returns the same builder for fluent chaining. It throws `ArgumentNullException` when `builder` is null.

## `MaterialSymbolImageSource`

### `Create`

```csharp
public static FontImageSource Create(
    MaterialSymbol icon,
    MaterialSymbolVariant variant = MaterialSymbolVariant.Outlined,
    bool filled = false,
    double size = 24,
    Color? color = null,
    bool fontAutoScalingEnabled = false
)
```

Creates a new `FontImageSource`. It sets `Glyph`, `FontFamily`, `Size`, and `FontAutoScalingEnabled`; it only assigns `Color` when a non-null value is supplied.

## `SymbolExtension`

```csharp
public sealed class SymbolExtension : IMarkupExtension<ImageSource>
```

XAML markup extension backed by `MaterialSymbolImageSource.Create`.

| Property | Type | Default | Purpose |
| --- | --- | --- | --- |
| `Icon` | `MaterialSymbol` | `None` | Named glyph; also the content property |
| `Variant` | `MaterialSymbolVariant` | `Outlined` | Shape family |
| `Filled` | `bool` | `false` | Selects the filled font |
| `Size` | `double` | `24` | Font image size |
| `Color` | `Color?` | `null` | Optional explicit color |
| `FontAutoScalingEnabled` | `bool` | `false` | Allows OS text scaling when enabled |

It provides both parameterless and `SymbolExtension(MaterialSymbol icon)` constructors. `ProvideValue(IServiceProvider)` returns an `ImageSource`; the service provider is currently not used.

## `MaterialSymbolIcon`

```csharp
public sealed class MaterialSymbolIcon : Label
```

A centered label specialized for symbols. It adds three bindable properties:

| Property | Type | Default |
| --- | --- | --- |
| `Icon` | `MaterialSymbol` | `None` |
| `Variant` | `MaterialSymbolVariant` | `Outlined` |
| `Filled` | `bool` | `false` |

The constructor disables font auto-scaling and centers text horizontally and vertically. A shared property-changed callback converts `Icon` to a glyph and selects the correct font alias. All other visual behavior comes from `Label`, including `FontSize`, `TextColor`, binding, styles, and semantic properties.
