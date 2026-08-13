# NuGet packaging

## Project metadata

`src/MaterialSymbols.Maui/MaterialSymbols.Maui.csproj` is an SDK-style, packable `net10.0` library. `dotnet pack` produces a primary `.nupkg` and a `.snupkg` because `IncludeSymbols` is enabled and `SymbolPackageFormat` is `snupkg`.

Build a local package from the repository root:

```powershell
dotnet restore src/MaterialSymbols.Maui/MaterialSymbols.Maui.csproj
dotnet pack src/MaterialSymbols.Maui/MaterialSymbols.Maui.csproj -c Release
```

The default output is `artifacts/packages/`. Override a release version without editing the project:

```powershell
dotnet pack src/MaterialSymbols.Maui/MaterialSymbols.Maui.csproj `
    -c Release `
    -p:Version=0.2.0 `
    -o artifacts/packages
```

## Package layout

```text
lib/net10.0/
  MaterialSymbols.Maui.dll
  MaterialSymbols.Maui.xml
buildTransitive/
  MaterialSymbols.Maui.targets
  Fonts/
    MaterialSymbolsOutlined-Regular.ttf
    MaterialSymbolsOutlinedFilled-Regular.ttf
    MaterialSymbolsRounded-Regular.ttf
    MaterialSymbolsRoundedFilled-Regular.ttf
    MaterialSymbolsSharp-Regular.ttf
    MaterialSymbolsSharpFilled-Regular.ttf
README.md
LICENSE
THIRD-PARTY-NOTICES.md
licenses/Apache-2.0.txt
```

The project uses explicit `PackagePath` values so font and target files land at exactly these paths. Keep the target filename equal to the package ID; NuGet automatically imports matching `.props` and `.targets` files from `buildTransitive` and propagates them through transitive package references.

## Consumer integration

The imported target is conditional on `$(UseMaui) == true`. Each `MauiFont` points to `$(MSBuildThisFileDirectory)Fonts/...`, which resolves inside the restored package on every operating system. The aliases must remain synchronized with `MaterialSymbolFonts` and `UseMaterialSymbols()`.

When changing a filename or alias, update all of these together:

1. `Resources/Fonts/`
2. `buildTransitive/MaterialSymbols.Maui.targets`
3. internal filenames and public aliases in `MaterialSymbolFonts`
4. generation logic and documentation
5. the demo's linked font items if its layout changes

## Validate before publishing

At minimum:

1. Build the library and affected demo targets.
2. Run `dotnet pack` and confirm there are no NuGet warnings.
3. Inspect the archive, for example with `tar -tf artifacts/packages/*.nupkg`.
4. Verify all six fonts and the single root `buildTransitive/MaterialSymbols.Maui.targets` entry.
5. Restore and build a MAUI app against the produced package when package integration changes.

## Release workflow

`.github/workflows/release.yml` runs on semantic `v*.*.*` tags or manual dispatch. It derives the package version by removing a leading `v`, packs on Ubuntu, uploads both artifacts, and uses NuGet trusted publishing. `NuGet/login@v1` exchanges GitHub's OIDC token for a short-lived API key; no permanent NuGet key is stored. The job must retain `id-token: write`, use the `production` environment, and keep the filename `release.yml` because those values are part of the nuget.org policy.

Pushing the primary `.nupkg` also publishes the adjacent `.snupkg` to NuGet's symbol server.
