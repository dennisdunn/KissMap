using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KissMap
{
    public class PropertyWriteMap<TSrc, TDst> : IPropertyMap<TSrc, TDst>
    {
        private PropertyInfo _propertyInfo;
        private Action<TDst, object> _propertyWriter;

        public PropertyWriteMap(string propertyName, Action<TDst, object> propertyWriter)
        {
            _propertyInfo = typeof(TSrc).GetProperty(propertyName);
            _propertyWriter = propertyWriter;
        }

        public void Apply(TSrc src, TDst dst)
        {
            var value = _propertyInfo.GetValue(src, null);

            _propertyWriter(dst, value);
        }
    }
}
