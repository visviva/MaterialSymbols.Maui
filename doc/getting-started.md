# Getting started

## Install and register

Add the package to a .NET MAUI application:

```powershell
dotnet add package MaterialSymbols.Maui
```

Register its six font files while building the app:

```csharp
using MaterialSymbols.Maui;

MauiAppBuilder builder = MauiApp.CreateBuilder();
builder
    .UseMauiApp<App>()
    .UseMaterialSymbols();
```

`UseMaterialSymbols()` registers stable aliases used by every control and image source in the library. Call it once in `MauiProgram.CreateMauiApp` before `builder.Build()`.

## Add the XAML namespace

The assembly maps a URI to the `MaterialSymbols.Maui` CLR namespace:

```xml
xmlns:symbols="http://schemas.materialsymbols.maui/2026/xaml"
```

The URI is an identifier; it is not fetched over the network.

## Use symbols as image sources

`SymbolExtension` works anywhere MAUI accepts an `ImageSource`, including `Image`, `ToolbarItem`, `ShellContent`, and tab icons:

```xml
<ShellContent
    Title="Home"
    Icon="{symbols:Symbol Home, Variant=Rounded, Filled=True}" />

<ToolbarItem
    Text="Search"
    IconImageSource="{symbols:Symbol Search, Size=24}" />

<Image
    HeightRequest="40"
    WidthRequest="40"
    Source="{symbols:Symbol Favorite, Filled=True, Size=40, Color=Crimson}" />
```

`Icon` is the content property, so `{symbols:Symbol Home}` is shorthand for `{symbols:Symbol Icon=Home}`. Defaults are `Outlined`, unfilled, size 24, no explicit color, and font auto-scaling disabled.

## Use the label-based control

`MaterialSymbolIcon` inherits `Label`, so normal label layout, color, effects, triggers, and accessibility APIs remain available:

```xml
<symbols:MaterialSymbolIcon
    Icon="CalendarMonth"
    Variant="Sharp"
    Filled="True"
    FontSize="32"
    TextColor="Blue"
    SemanticProperties.Description="Calendar" />
```

`Icon`, `Variant`, and `Filled` are bindable properties:

```xml
<symbols:MaterialSymbolIcon
    Icon="{Binding CurrentIcon}"
    Filled="{Binding IsSelected}"
    FontSize="28" />
```

Changing any of them immediately recalculates `Text` and `FontFamily`. Do not set those two inherited properties directly on this control because the next symbol-property change overwrites them.

## Create sources in C#

```csharp
FontImageSource source = MaterialSymbolImageSource.Create(
    MaterialSymbol.Settings,
    MaterialSymbolVariant.Rounded,
    filled: true,
    size: 28,
    color: Colors.DarkSlateBlue
);

toolbarItem.IconImageSource = source;
```

For custom rendering, use the lower-level helpers:

```csharp
string glyph = MaterialSymbol.Home.ToGlyph();
string family = MaterialSymbolFonts.GetFontFamily(
    MaterialSymbolVariant.Outlined,
    filled: false
);
```

`MaterialSymbol.None` produces an empty glyph. Some upstream names are aliases and therefore intentionally share a Unicode codepoint.

## Explore the demo

Open `MaterialSymbols.Maui.slnx`, select `MaterialSymbols.Maui.Demo`, and choose a platform target. The demo shows Shell and toolbar images, label-based icon controls, all six styles, and markup-extension images.
