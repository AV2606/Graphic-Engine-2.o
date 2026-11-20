

using Common2D.ColorScheme;

namespace Common2D
{
    public static class PixelMap
    {
        public static PixelMap<BGRA> GetBGRAPixelMap()
        {
            return new PixelMap<BGRA>();
        }
    }
    public class PixelMap<TColorScheme> where TColorScheme : struct, IColorScheme<TColorScheme>, IColorDefaults<TColorScheme> //where TColorScheme : struct, IColorScheme<TColorScheme>
    {


        public int Width { get; } = 800;
        public int Height { get; } = 800;

        private Pixel<TColorScheme>[] pixels;
        private int Index2D(int row, int column) => row * Width + column;

        internal PixelMap()
        {
            pixels = new Pixel<TColorScheme>[Height * Width];

            Array.Fill(pixels, new Pixel<TColorScheme>(TColorScheme.White));  
        }

        public void SetPixel(int width, int height, Pixel<TColorScheme> pixel)
        {
            if (width < 0 || width >= Width || height < 0 || height >= Height)
                return;
            int index = (height * Width + width) * 4;
           pixels[height * Width + width] = pixel;
        }
        public void SetPixel(int width, int height, TColorScheme color)
        {
            if (width < 0 || width >= Width || height < 0 || height >= Height)
                return;
            int index = (height * Width + width) * 4;
            pixels[Index2D(height, width)] = new Pixel<TColorScheme>(color);
        }

        public byte[] GetPixels()
        {
            return pixels.SelectMany(p=>p.ToBGRABytes()).ToArray();
        }  
    }
}
