namespace Common2D.ColorScheme
{
    public interface IBGRA<TInheritor> : IColorDefaults<TInheritor>, IColorScheme<TInheritor> where TInheritor : struct, IBGRA<TInheritor>
    {
    }
}