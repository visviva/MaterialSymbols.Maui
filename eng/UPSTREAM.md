# Upstream assets

The generated fonts and `MaterialSymbol.cs` come from Google's
[`material-design-icons`](https://github.com/google/material-design-icons) repository at commit
`50f0603134ce7b70b2d71b686cc13e8b57ccb74c`.

`generate_material_symbols.py` downloads the three official Material Symbols variable fonts and
the official codepoint list, verifies their SHA-256 hashes, and produces fixed instances with:

- optical size: 24
- weight: 400
- grade: 0
- fill: 0 or 1

Install the pinned requirements and run the generator from the repository root:

```powershell
python -m pip install -r eng/requirements.txt
python eng/generate_material_symbols.py --project-root src/MaterialSymbols.Maui
```

Google's fonts and generated derivatives are licensed under Apache License 2.0.

## Generated font hashes

The checked-in fixed fonts have these SHA-256 hashes:

| Font | SHA-256 |
| --- | --- |
| `MaterialSymbolsOutlined-Regular.ttf` | `3d7924cb8bf0463e67be0d107acfe5e94016e629b322f0de5f029ee6dd4c92f3` |
| `MaterialSymbolsOutlinedFilled-Regular.ttf` | `42c51a7b649e06b4b1991bebcfcc3c6b926c32a3375d9104724451a214e8ebe3` |
| `MaterialSymbolsRounded-Regular.ttf` | `9031560fa9d50e5019b9b3aaa688cfeddacb199e074a70d31310f4ebd742d1f7` |
| `MaterialSymbolsRoundedFilled-Regular.ttf` | `64327b0d0b601f1ec4094948ce670429f7e58c6a592381602584661ef7124920` |
| `MaterialSymbolsSharp-Regular.ttf` | `48aa5c4e24b3c502fa8befd404c7ba572a575744a139742cb79feb29adb7a38d` |
| `MaterialSymbolsSharpFilled-Regular.ttf` | `fb137913da7eb089d5145326e71dbd81544f7a629fabfc110b24048c59f85a7f` |
