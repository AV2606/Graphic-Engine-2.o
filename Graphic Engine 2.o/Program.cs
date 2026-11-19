using Graphic_Engine_2.o.Basic;
using Silk.NET.OpenGL;
using Silk.NET.Windowing;

namespace Graphic_Engine_2.o
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PixelImage pixelImage = new PixelImage();

            // Create window settings
            var options = WindowOptions.Default;
            options.Size = new Silk.NET.Maths.Vector2D<int>(800, 600);
            options.Title = "Pixel Renderer";

            // Create window
            IWindow window = Window.Create(options);

            // Initialize OpenGL when the window is loaded
            window.Load += () =>
            {
                GL gl = GL.GetApi(window);

                // Create texture
                uint texture = gl.GenTexture();

                gl.BindTexture(
                    TextureTarget.Texture2D,
                    texture
                );

                // Pixel filtering
                gl.TexParameter(
                    TextureTarget.Texture2D,
                    TextureParameterName.TextureMinFilter,
                    (int)GLEnum.Nearest
                );

                gl.TexParameter(
                    TextureTarget.Texture2D,
                    TextureParameterName.TextureMagFilter,
                    (int)GLEnum.Nearest
                );

                // Upload image
                unsafe
                {
                    fixed (byte* ptr = pixelImage.GetPixels())
                    {
                        gl.TexImage2D(
                        TextureTarget.Texture2D,
                        0,
                        InternalFormat.Rgba8,
                        (uint)pixelImage.Width,
                        (uint)pixelImage.Height,
                        0,
                        PixelFormat.Rgba,
                        PixelType.UnsignedByte,
                        ptr
                    );
                    }

                }

                window.Render += deltaTime =>
                {
                    gl.ClearColor(1.0f, 0.0f, 0.0f, 1.0f);
                    gl.Clear(ClearBufferMask.ColorBufferBit);
                };
            };

           

            // Start window loop
            window.Run();

            
        }
    }
}
