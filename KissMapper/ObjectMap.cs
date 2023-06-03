using System.Reflection;
using System.Reflection.PortableExecutable;

namespace KissMap
{
    public class ObjectMap<TSrc, TDst> : IObjectMap<TSrc, TDst>
    {
        private IEnumerable<IPropertyMap<TSrc, TDst>> _propertyMaps = new List<IPropertyMap<TSrc, TDst>>();
        public void Register(string prop)
        {
            Register(prop, prop);
        }
        public void Register(string srcProp, string dstProp)
        {
            _propertyMaps = _propertyMaps.Append(new PropertyMap<TSrc, TDst>(srcProp, dstProp));
        }
        public void Register(Func<TSrc, object> reader, string dstPropname)
        {
            _propertyMaps = _propertyMaps.Append(new PropertyReadMap<TSrc, TDst>(reader, dstPropname));
        }
        public void Register(Func<TSrc, object> reader, Action<TDst, object> writer)
        {
            _propertyMaps = _propertyMaps.Append(new PropertyReadWriteMap<TSrc, TDst>(reader, writer));
        }
        public void Register(string srcProp, Action<TDst, object> writer)
        {
            _propertyMaps = _propertyMaps.Append(new PropertyWriteMap<TSrc, TDst>(srcProp, writer));
        }

        public object CopyTo(TSrc src, TDst dst)
        {
            foreach (var prop in _propertyMaps)
            {
                prop.Apply(src, dst);
            }
            return dst;
        }

        public TDst CreateFrom(TSrc src)
        {
            TDst dst = Activator.CreateInstance<TDst>();
            foreach (var prop in _propertyMaps)
            {
                prop.Apply(src, dst);
            }
            return dst;
        }
    }
}