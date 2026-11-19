using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Common2D.ColorScheme
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct BGRA : IBGRA<BGRA>
    {
        public static readonly BGRA Black= new BGRA(0, 0, 0, 255);
        public static readonly BGRA Blue = new BGRA(255, 0, 0, 255);
        public static readonly BGRA Green = new BGRA(0, 255, 0, 255);
        public static readonly BGRA Red = new BGRA(0, 0, 255, 255);
        public static readonly BGRA Transparent = new BGRA(0, 0, 0, 0);
        public static readonly BGRA White = new BGRA(255, 255, 255, 255);

        #region base
        private byte b, r, g, a;
       
        public BGRA()
        {
           b = 0;
           g = 0;
           r = 0;
           a = 255;
        }

        public BGRA(byte b, byte g, byte r, byte a)
        {
            this.b = b;
            this.g = g;
            this.r = r;
            this.a = a;
        }

        public void SetFromBytes(byte b, byte g, byte r, byte a)
        {
            this.b = b;
            this.g = g;
            this.r = r;
            this.a = a;
        }

        public void SetFromBytes(ReadOnlySpan<byte> bytes)
        {
            this.b = bytes[0];
            this.g = bytes[1];
            this.r = bytes[2];
            this.a = bytes[3];
        }

        public byte[] ToBGRABytes()
        {
            return new byte[] { b, g, r, a };
        }

        public (byte b, byte g, byte r, byte a) ToBGRABytesTuple()
        {
            return (b, g, r, a);
        }


        #endregion
        public static implicit operator BGRA(Tuple<byte, byte, byte, byte> tuple)
        {
            return new BGRA(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4);
        }
    }
}
