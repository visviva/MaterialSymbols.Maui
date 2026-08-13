# Updating Material Symbols

The generated enum and font files are pinned to a specific commit in Google's `material-design-icons` repository. `eng/UPSTREAM.md` records that commit and the generated font hashes; `eng/generate_material_symbols.py` contains the source URLs and expected download hashes.

## Prerequisites

- Python 3
- The pinned packages in `eng/requirements.txt`
- Network access to `raw.githubusercontent.com`

From the repository root:

```powershell
python -m pip install -r eng/requirements.txt
python eng/generate_material_symbols.py `
    --project-root src/MaterialSymbols.Maui
```

The explicit project root is required because generated assets live inside the nested library project.

## Generation pipeline

The script performs these steps in a temporary directory:

1. Downloads the Outlined, Rounded, and Sharp variable fonts plus the Outlined codepoint list from the pinned upstream commit.
2. Verifies every download against a hard-coded SHA-256 hash before processing it.
3. Instantiates each variable font twice with `FILL=0` and `FILL=1`, while fixing `GRAD=0`, `opsz=24`, and `wght=400`.
4. Rewrites font name records so every output family and PostScript name is unique.
5. Rejects an output if it still contains an `fvar` table or lacks an expected codepoint.
6. Converts upstream names into C# identifiers and rejects identifier collisions.
7. Writes six `.ttf` files and `MaterialSymbol.cs` using LF line endings.

Downloads are temporary; only validated derived assets are written into the project.

## Name conversion

Upstream names are split on non-alphanumeric characters and then into alphabetic and numeric segments. Alphabetic segments are capitalized and concatenated. An identifier beginning with a digit receives the `Icon` prefix:

| Upstream | C# |
| --- | --- |
| `calendar_month` | `CalendarMonth` |
| `10k` | `Icon10K` |
| `1x_mobiledata` | `Icon1XMobiledata` |

The original upstream name remains as an end-of-line comment in the generated enum.

## Updating the upstream pin

To move to a newer Google revision:

1. Review upstream licensing and changes.
2. Change `UPSTREAM_COMMIT` in the generator.
3. Download the four declared inputs, calculate their SHA-256 values, and update `ASSETS`.
4. Run the generator with the nested project root.
5. Update the commit and all generated font hashes in `eng/UPSTREAM.md`.
6. Review enum additions, removals, renamed identifiers, aliases, and codepoint changes as API changes.
7. Build the demo on affected platforms and pack the NuGet artifact.

Never bypass a hash mismatch. It indicates that the URL, upstream pin, or downloaded content differs from what was reviewed.

## Review checklist

- `MaterialSymbol.cs` retains its generated header and contains no identifier collisions.
- Exactly six static fonts exist and none contains a variable `fvar` table.
- `MaterialSymbolFonts`, package targets, and filenames still agree.
- `eng/UPSTREAM.md`, third-party notices, and package licensing remain accurate.
- API and architecture documentation reflects any generation or naming changes.
