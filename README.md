[![CI](https://github.com/visviva/MaterialSymbols.Maui/actions/workflows/ci.yml/badge.svg?branch=main)](https://github.com/visviva/MaterialSymbols.Maui/actions/workflows/ci.yml)
# MaterialSymbols.Maui

Modern Google Material Symbols for .NET MAUI with named XAML and C# APIs. The package includes
Outlined, Rounded, and Sharp designs, each in outlined and filled form.

## Installation

```powershell
dotnet add package MaterialSymbols.Maui
```

Register the fonts in `MauiProgram.cs`:

```csharp
using MaterialSymbols.Maui;

builder
    .UseMauiApp<App>()
    .UseMaterialSymbols();
```

## XAML

Add the namespace:

```xml
xmlns:symbols="http://schemas.materialsymbols.maui/2026/xaml"
```

Use a named symbol anywhere an `ImageSource` is accepted:

```xml
<ShellContent
    Title="Home"
    Icon="{symbols:Symbol Home}"
    ContentTemplate="{DataTemplate views:HomePage}" />

<Image Source="{symbols:Symbol Settings, Variant=Rounded, Filled=True, Size=28}" />
```

Or use the label-based control:

```xml
<symbols:MaterialSymbolIcon
    Icon="CalendarMonth"
    Variant="Sharp"
    Filled="True"
    FontSize="32"
    TextColor="Blue" />
```

## C#

```csharp
var source = MaterialSymbolImageSource.Create(
    MaterialSymbol.Home,
    MaterialSymbolVariant.Rounded,
    filled: true,
    size: 24,
    color: Colors.Black
);
```

## Design variants

The upstream fonts are variable fonts. For predictable cross-platform MAUI rendering, this package
ships fixed instances at optical size 24, weight 400, grade 0, and fill 0 or 1. Runtime control of
variable font axes is intentionally outside the initial package API.

## Demo

The [`examples/MaterialSymbols.Maui.Demo`](examples/MaterialSymbols.Maui.Demo) app demonstrates
symbols in a Shell app bar and on its main page. Open `MaterialSymbols.Maui.slnx` in Visual Studio
and set the demo as the startup project.

## Licensing

The library follows the license included in this package. Google Material Symbols and the generated
font instances are distributed under Apache License 2.0; see `THIRD-PARTY-NOTICES.md` and
`licenses/Apache-2.0.txt`. This project is not affiliated with or endorsed by Google.
