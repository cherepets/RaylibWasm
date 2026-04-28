import { dotnet } from './_framework/dotnet.js'

const { getAssemblyExports, getConfig, runMain } = await dotnet
    .withDiagnosticTracing(false)
    .create();

const config = getConfig();
const exports = await getAssemblyExports(config.mainAssemblyName);

const canvas = document.getElementById('canvas');
dotnet.instance.Module['canvas'] = canvas;

function mainLoop() {
    canvas.style.width = window.innerWidth + "px";
    canvas.style.height = window.innerHeight + "px";
    exports.RaylibWasm.Application.UpdateFrame(
        window.innerWidth,
        window.innerHeight,
        window.devicePixelRatio || 1);
    window.requestAnimationFrame(mainLoop);
}

await runMain();
window.requestAnimationFrame(mainLoop);