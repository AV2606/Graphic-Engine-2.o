using System;
using System.Collections.Generic;
using System.Text;

namespace Common2D.ColorScheme
{
    public interface IColorDefaults<TInheritor> where TInheritor : struct, IColorDefaults<TInheritor>
    {
        static abstract TInheritor Black { get; }
        static abstract TInheritor Blue { get; }
        static abstract TInheritor Green { get; }
        static abstract TInheritor Red { get; }
        static abstract TInheritor Transparent { get; }
        static abstract TInheritor White { get; }
    }
}
