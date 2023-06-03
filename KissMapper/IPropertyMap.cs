namespace KissMap
{
    public interface IPropertyMap<TSrc, TDst>
    {
        void Apply(TSrc src, TDst dst);
    }
}