using Common2D.ColorScheme;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Common2D
{
    [DebuggerDisplay("color:({color})")]
    public struct Pixel<TColorScheme> : IColorDefaults<Pixel<TColorScheme>>, IColorScheme<Pixel<TColorScheme>> where TColorScheme: struct, IColorScheme<TColorScheme>, IColorDefaults<TColorScheme>
    {
        private TColorScheme color;

        public static Pixel<TColorScheme> Black => new Pixel<TColorScheme>(TColorScheme.Black);

        public static Pixel<TColorScheme> Blue => new Pixel<TColorScheme>(TColorScheme.Blue);

        public static Pixel<TColorScheme> Green => new Pixel<TColorScheme>(TColorScheme.Green);

        public static Pixel<TColorScheme> Red => new Pixel<TColorScheme>(TColorScheme.Red);

        public static Pixel<TColorScheme> Transparent => new Pixel<TColorScheme>(TColorScheme.Transparent);

        public static Pixel<TColorScheme> White => new Pixel<TColorScheme>(TColorScheme.White);

        public Pixel(TColorScheme color)
        {
            this.color = color;
        }

        public Pixel<TColorScheme> SetColor(TColorScheme color)
        {
            this.color = color;
            return this;
        }

        public TColorScheme GetColor()
        {
            return color;
        }

        public void SetFromBytes(byte b, byte g, byte r, byte a)
        {
            color = TColorScheme.Black;
            color.SetFromBytes(b, g, r, a);
        }

        public void SetFromBytes(ReadOnlySpan<byte> bytes)
        {
            color = TColorScheme.Black;
            color.SetFromBytes(bytes);
        }

        public byte[] ToBGRABytes()
        {
           return color.ToBGRABytes();
        }

        public (byte b, byte g, byte r, byte a) ToBGRABytesTuple()
        {
           return color.ToBGRABytesTuple();
        }
    }
}
