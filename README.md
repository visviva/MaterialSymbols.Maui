<p align="center">
  <img
    src="assets/materialsymbols-maui-banner.svg"
    alt="MaterialSymbols.Maui — Modern Google Material Symbols for .NET MAUI"
    width="100%"
  />
</p>

[![CI](https://github.com/visviva/MaterialSymbols.Maui/actions/workflows/ci.yml/badge.svg?branch=main)](https://github.com/visviva/MaterialSymbols.Maui/actions/workflows/ci.yml)
[![NuGet](https://img.shields.io/nuget/v/MaterialSymbols.Maui.svg)](https://www.nuget.org/packages/MaterialSymbols.Maui)

# MaterialSymbols.Maui

Modern Google Material Symbols for .NET MAUI with named XAML and C# APIs. The package includes
Outlined, Rounded, and Sharp designs, each in outlined and filled form. It is available from
[NuGet.org](https://www.nuget.org/packages/MaterialSymbols.Maui).

See the
[documentation](https://github.com/visviva/MaterialSymbols.Maui/blob/main/doc/README.md) for
detailed usage, API, architecture, packaging, and maintenance guides.

## Installation

```powershell
dotnet add package MaterialSymbols.Maui --version 1.0.0
```

Or add the package reference directly to your MAUI project:

```xml
<PackageReference Include="MaterialSymbols.Maui" Version="1.0.0" />
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

The
[`examples/MaterialSymbols.Maui.Demo`](https://github.com/visviva/MaterialSymbols.Maui/tree/main/examples/MaterialSymbols.Maui.Demo)
app demonstrates symbols in a Shell app bar and on its main page. Open `MaterialSymbols.Maui.slnx`
in Visual Studio and set the demo as the startup project.

## Licensing

The library follows the license included in this package. Google Material Symbols and the generated
font instances are distributed under Apache License 2.0; see `THIRD-PARTY-NOTICES.md` and
`licenses/Apache-2.0.txt`. This project is not affiliated with or endorsed by Google.
