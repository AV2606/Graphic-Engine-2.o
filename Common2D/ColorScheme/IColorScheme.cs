using System;
using System.Collections.Generic;
using System.Text;

namespace Common2D.ColorScheme
{
    public interface IColorScheme<TInheritor> where TInheritor : struct, IColorScheme<TInheritor>
    {
        static readonly TInheritor Black;
        static readonly TInheritor Blue;
        static readonly TInheritor Green;
        static readonly TInheritor Red;
        static readonly TInheritor Transparent;
        static readonly TInheritor White;

        abstract void SetFromBytes(byte b, byte g, byte r, byte a);
        abstract void SetFromBytes(ReadOnlySpan<byte> bytes);
        abstract byte[] ToBGRABytes();
        abstract (byte b, byte g, byte r, byte a) ToBGRABytesTuple();
    }
}
