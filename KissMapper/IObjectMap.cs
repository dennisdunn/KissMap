namespace KissMap
{
    public interface IObjectMap<TSrc, TDst>
    {
        void CopyTo(TSrc src, TDst dst);
        TDst CreateFrom(TSrc src);
        void Register(string prop);
        void Register(string srcProp, string dstProp);
        void Register(string srcProp, Action<TDst, object> writer);
        void Register(Func<TSrc, object> reader, string dstPropname);
        void Register(Func<TSrc, object> reader, Action<TDst, object> writer);
    }
}