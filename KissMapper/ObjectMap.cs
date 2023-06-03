using System.Reflection;

namespace KissMap
{
      public class PropertyMap
    {
        private string _srcProp;
        private string _dstProp;

        public PropertyMap(string srcKey, string dstKey)
        {
            _srcProp = srcKey;
            _dstProp = dstKey;
        }
        public void Apply(object src, object dst)
        {
            var srcProp = src.GetType().GetProperty(_srcProp);
            var dstProp = dst.GetType().GetProperty(_dstProp);

            var value = srcProp.GetValue(src, null);
            value = Convert.ChangeType(value, dstProp.PropertyType);

            dstProp.SetValue(dst, value, null);
        }
    }
    public class ObjectMap
    {
        private IEnumerable<PropertyMap> _propertyMaps = new List<PropertyMap>();
        public void Register(string prop)
        {
            Register(prop, prop);
        }
        public void Register(string srcProp, string dstProp)
        {
            _propertyMaps = _propertyMaps.Append(new PropertyMap(srcProp, dstProp));
        }

        public object CopyTo(object src, object dst)
        {
            foreach (var prop in _propertyMaps)
            {
                prop.Apply(src, dst);
            }
            return dst;
        }

        public TDst Create<TDst>(object src)
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