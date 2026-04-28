# RaylibWasm

.Net 10 WebAsssembly starter project using raylib-cs nuget based on https://github.com/Kiriller12/RaylibWasm.

## KEY IMPROVEMENTS
- Added IIS Express to launchSettings.json to be able to run it from Visual Studio by hitting F5
- Made canvas occupy the whole page and dpi aware (text is not blurry on High DPI displays anymore)
- Few extra properties in .csproj for things I consider recommended and things that can reduce bundle size
- Changed TargetFramework to net10.0-browser to avoid CA1416: This call site is reachable on all platforms. 'JSExportAttribute' is only supported on: 'browser'.

## Setup

You must have .Net 10 installed before start.

Then install wasm toolset:

```
dotnet workload install wasm-tools
```

## Build

> [!WARNING]
> Do not use Visual Studio publication, it may cause some strange errors!

Just call this command from the root directory of the solution:
```
dotnet publish -c Release
```

## Run

You could use whatever web-server you want to serve published files.

OR

You could also use `dotnet serve` for this purpose:

If it's not installed, you need to install it with this command:
```
dotnet tool install --global dotnet-serve
```

And then just call this command to start web server for your build:
```
dotnet serve --mime .wasm=application/wasm --mime .js=text/javascript --mime .json=application/json --directory RaylibWasm\bin\Release\net10.0-browser\browser-wasm\AppBundle\
```

While server is running you can use publish command to update your files without any need to restart server.

## Notes

This project includes webassembly build of raylib native 5.5 (`raylib.a` file), because it is not included with raylib-cs nuget.

Raylib-cs may still have some webassembly compatibility issues that have been mentioned [here](https://github.com/stanoddly/DotnetRaylibWasm/issues/11) and [here](https://github.com/stanoddly/DotnetRaylibWasm/issues/4).

This project is not perfect, so I would welcome your suggestions and PR requests.

## Thanks

- to [Kiriller12](https://github.com/Kiriller12) for his awesome project template
- to [Ray](https://github.com/raysan5) and all [raylib](https://github.com/raysan5/raylib) contributors for such a wonderful lib
- to [ChrisDill](https://github.com/ChrisDill) for [raylib C# bindings](https://github.com/ChrisDill/Raylib-cs)
- to [stanoddly](https://github.com/stanoddly) for dotnet webassembly [example project](https://github.com/stanoddly/DotnetRaylibWasm)
