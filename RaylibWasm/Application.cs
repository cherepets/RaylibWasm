using Raylib_cs;
using System.Numerics;
using System.Runtime.InteropServices.JavaScript;

namespace RaylibWasm
{
    public partial class Application
    {
        private static Texture2D logo;
        
        /// <summary>
        /// Application entry point
        /// </summary>
        public static void Main()
        {
            Raylib.InitWindow(1, 1, "RaylibWasm");
            Raylib.SetTargetFPS(60);
            
            logo = Raylib.LoadTexture("Resources/raylib_logo.png");
        }

        /// <summary>
        /// Updates frame
        /// </summary>
        /// <param name="width">Virtual window width</param>
        /// <param name="height">Virtual window height</param>
        /// <param name="devicePixelRatio">Ratio of the resolution in device pixels to virtual pixels</param>
        [JSExport]
        public static void UpdateFrame(int width, int height, float devicePixelRatio)
        {
            var deviceWidth = (int)(width * devicePixelRatio);
            var deviceHeight = (int)(height * devicePixelRatio);

            if (deviceWidth != Raylib.GetScreenWidth() || deviceHeight != Raylib.GetScreenHeight())
            {
                Raylib.SetWindowSize(deviceWidth, deviceHeight);
            }

            var scalingCamera = new Camera2D
            {
                Offset = Vector2.Zero,
                Target = Vector2.Zero,
                Rotation = 0.0f,
                Zoom = devicePixelRatio
            };

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.White);

            Raylib.BeginMode2D(scalingCamera);

            Raylib.DrawFPS(4, 4);
            Raylib.DrawText("All systems operational!", 4, 32, 20, Color.Maroon);
            
            Raylib.DrawTexture(logo, 4, 64, Color.White);

            Raylib.EndMode2D();

            Raylib.EndDrawing();
        }
    }
}
