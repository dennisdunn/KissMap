using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KissMap
{
    public class PropertyMap<TSrc, TDst> : IPropertyMap<TSrc, TDst>
    {
        private PropertyInfo _srcPropertyInfo;
        private PropertyInfo _dstPropertyInfo;

        public PropertyMap(string srcPropName, string dstPropname)
        {
            _srcPropertyInfo = typeof(TSrc).GetProperty(srcPropName);
            _dstPropertyInfo = typeof(TDst).GetProperty(dstPropname);
        }

        public void Apply(TSrc src, TDst dst)
        {
            var value = _srcPropertyInfo.GetValue(src, null);

            value = Convert.ChangeType(value, _dstPropertyInfo.PropertyType);

            _dstPropertyInfo.SetValue(dst, value, null);
        }
    }
}
