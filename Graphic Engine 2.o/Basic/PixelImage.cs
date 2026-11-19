using System;
using System.Collections.Generic;
using System.Text;

namespace Graphic_Engine_2.o.Basic
{
    public class PixelImage
    {
        private byte[] pixels;


        public int Width { get; } = 400;
        public int Height { get; } = 400;

        public PixelImage()
        {
            pixels = new byte[Width * Height * 4];
            for(int i=0; i<pixels.Length; i++)
            {
                pixels[i] = 255;
            }
            //for (int i = 0; i < pixels.Length; i+=4)
            //{
            //    pixels[i] = 120;// Red
            //    pixels[i + 1] = 60;// Green
            //    pixels[i + 2] = 30;// Blue
            //    pixels[i + 3] = 30;// Alpha
            //}
        }

        public byte[] GetPixels()
        {
            return pixels;
        }
    }
}
