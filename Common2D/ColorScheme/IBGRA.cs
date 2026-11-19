namespace Common2D.ColorScheme
{
    public interface IBGRA<TInheritor> : IColorScheme<TInheritor> where TInheritor : struct, IBGRA<TInheritor>
    {
    }
}