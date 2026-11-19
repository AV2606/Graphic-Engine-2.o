

using Common2D.ColorScheme;

namespace Common2D
{
    public class PixelMap
    {


        public int Width { get; } = 800;
        public int Height { get; } = 800;

        private Pixel<BGRA, BGRA>[] pixels;
        private int Index2D(int row, int column) => row * Width + column;

        public PixelMap()
        {
            pixels = new Pixel<BGRA, BGRA>[Height* Width];

            for(int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    pixels[Index2D(i, j)] = new Pixel<BGRA, BGRA>(BGRA.Red);
                }
            }

            for (int i = 0; i < Height; i++)
            {
                SetPixel(0, i,BGRA.Black);
                SetPixel(1, i, BGRA.Black);

            }
        }

        public void SetPixel(int width, int height, Pixel<BGRA, BGRA> pixel)
        {
            if (width < 0 || width >= Width || height < 0 || height >= Height)
                return;
            int index = (height * Width + width) * 4;
           pixels[height * Width + width] = pixel;
        }
        public void SetPixel(int width, int height, BGRA color)
        {
            if (width < 0 || width >= Width || height < 0 || height >= Height)
                return;
            int index = (height * Width + width) * 4;
            pixels[Index2D(height, width)] = new Pixel<BGRA, BGRA>(color);
        }

        public byte[] GetPixels()
        {
            return pixels.SelectMany(p=>p.ToBGRABytes()).ToArray();
        }
    }
}
