using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KissMap
{
    public class PropertyReadMap<TSrc, TDst> : IPropertyMap<TSrc, TDst>
    {
        private Func<TSrc, object> _propertyReader;
        private PropertyInfo _propertyInfo;

        public PropertyReadMap(Func<TSrc, object> propertyReader, string propertyName)
        {
            _propertyReader = propertyReader;
            _propertyInfo = typeof(TDst).GetProperty(propertyName);
        }

        public void Apply(TSrc src, TDst dst)
        {
            var value = _propertyReader(src);

            value = Convert.ChangeType(value, _propertyInfo.PropertyType);

            _propertyInfo.SetValue(dst, value, null);
        }
    }
}
