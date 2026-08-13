# Repository Guidelines

## Project Structure & Module Organization

The root `MaterialSymbols.Maui.slnx` groups production code under `src/` and runnable samples under `examples/`. The NuGet library lives in `src/MaterialSymbols.Maui`; its bundled fonts are in `Resources/Fonts`, while `buildTransitive/MaterialSymbols.Maui.targets` exposes those fonts to consuming MAUI projects. `examples/MaterialSymbols.Maui.Demo` is the cross-platform Shell demo used for integration checks. Detailed consumer and maintainer guides live in `doc/`; upstream generation and provenance live in `eng/`. Generated packages belong in the ignored `artifacts/packages/` directory. There is currently no `tests/` project.

## Build, Test, and Development Commands

Restore tools and dependencies before development:

```powershell
dotnet tool restore
dotnet restore MaterialSymbols.Maui.slnx
```

Build a platform supported by the current host, for example:

```powershell
dotnet build examples/MaterialSymbols.Maui.Demo/MaterialSymbols.Maui.Demo.csproj -f net10.0-windows10.0.19041.0
dotnet build examples/MaterialSymbols.Maui.Demo/MaterialSymbols.Maui.Demo.csproj -f net10.0-android
```

Create the NuGet and symbol packages with:

```powershell
dotnet pack src/MaterialSymbols.Maui/MaterialSymbols.Maui.csproj -c Release
```

## Coding Style & Naming Conventions

Follow `.editorconfig`: UTF-8, LF line endings, four-space C# indentation, two-space XML/JSON indentation, file-scoped namespaces, braces, and `using` directives outside namespaces. Use PascalCase for public types and members and camelCase for parameters and locals. Run `dotnet csharpier format .` before submitting broad formatting changes. Husky runs CSharpier automatically against staged C#, project, props, targets, XML, and config files during pre-commit.

## Generated Assets

Do not manually edit `MaterialSymbol.cs` or bundled font binaries. Follow `eng/UPSTREAM.md` and run `python eng/generate_material_symbols.py --project-root src/MaterialSymbols.Maui` from the repository root. Commit regenerated code, fonts, hashes, and provenance updates together.

## Documentation

Treat `doc/` as part of the product. Update `doc/api-reference.md` for public API or default-value changes, `doc/architecture.md` for runtime flow changes, `doc/packaging.md` for NuGet or CI changes, and `doc/updating-symbols.md` for generator changes. Keep examples executable, relative links valid, and `doc/README.md` navigation current. Update the root README when installation or first-use guidance changes.

## Commit & Pull Request Guidelines

History uses concise imperative subjects such as `Add CI badge to README`; follow that style without mandatory prefixes. Pull requests should explain the user-visible effect, link relevant issues, and list platforms and commands validated. Include screenshots for demo or XAML UI changes and call out package-content or licensing changes explicitly.
