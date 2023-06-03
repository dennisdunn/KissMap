using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KissMap
{
    public class PropertyReadWriteMap<TSrc, TDst> : IPropertyMap<TSrc, TDst>
    {
        private Func<TSrc, object>? _propertyReader;
        private Action<TDst, object>? _propertyWriter;
    
        public PropertyReadWriteMap(Func<TSrc, object> propertyReader, Action<TDst, object> propertyWriter)
        {
            _propertyReader = propertyReader;
            _propertyWriter = propertyWriter;
        }

        public void Apply(TSrc src, TDst dst)
        {
            var value = _propertyReader(src);

            _propertyWriter(dst, value);
        }
    }
}
