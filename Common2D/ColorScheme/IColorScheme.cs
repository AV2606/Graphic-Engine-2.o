using System;
using System.Collections.Generic;
using System.Text;

namespace Common2D.ColorScheme
{
    public interface IColorScheme<TInheritor> where TInheritor : struct, IColorScheme<TInheritor>, IColorDefaults<TInheritor>
    {
        abstract void SetFromBytes(byte b, byte g, byte r, byte a);
        abstract void SetFromBytes(ReadOnlySpan<byte> bytes);
        abstract byte[] ToBGRABytes();
        abstract (byte b, byte g, byte r, byte a) ToBGRABytesTuple();
    }
}
