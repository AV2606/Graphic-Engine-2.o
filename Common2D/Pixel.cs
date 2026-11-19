using Common2D.ColorScheme;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common2D
{
    public struct Pixel<TColorScheme,TImplementor> : IColorScheme<Pixel<TColorScheme,TImplementor>> where TColorScheme : IColorScheme<TImplementor> where TImplementor : struct, TColorScheme
    {
        private TColorScheme color;

        public Pixel(TColorScheme color)
        {
            this.color = color;
        }

        public Pixel<TColorScheme, TImplementor> SetColor(TColorScheme color)
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
            color = (TColorScheme)Activator.CreateInstance(typeof(TImplementor))!;
            color.SetFromBytes(b, g, r, a);
        }

        public void SetFromBytes(ReadOnlySpan<byte> bytes)
        {
            color = (TColorScheme)Activator.CreateInstance(typeof(TImplementor))!;
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
