namespace Common2D
{
    public class PixelMap
    {
        public int Width { get; } = 800;
        public int Height { get; } = 800;

        private byte[] pixels;

        public PixelMap()
        {
            pixels =  new byte[Height * Width * 4];

            for(int i = 0; i < pixels.Length; i += 4)
            {
                pixels[i] = 255;     // R
                pixels[i + 1] = 255; // G
                pixels[i + 2] = 0; // B
                pixels[i + 3] = 255; // A
            }
        }

        public byte[] GetPixels()
        {
            return pixels;
        }
    }
}
