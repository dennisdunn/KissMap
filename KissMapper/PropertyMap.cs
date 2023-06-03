using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KissMap
{
    public class PropertyMap<TSrc, TDst>
    {
        private PropertyInfo? _srcProperty;
        private PropertyInfo? _dstProperty;
        private Func<TSrc, object>? _reader;
        private Action<TDst, object>? _writer;

        public PropertyMap(string srcPropName, string dstPropname)
        {
            _srcProperty = typeof(TSrc).GetProperty(srcPropName);
            _dstProperty = typeof(TDst).GetProperty(dstPropname);
        }

        public PropertyMap(Func<TSrc, object> reader, string dstPropname)
        {
            _reader = reader;
            _dstProperty = typeof(TDst).GetProperty(dstPropname);
        }

        public PropertyMap(string srcPropName, Action<TDst, object> writer)
        {
            _srcProperty = typeof(TSrc).GetProperty(srcPropName);
            _writer = writer;
        }

        public PropertyMap(Func<TSrc, object> reader, Action<TDst, object> writer)
        {
            _reader = reader;
            _writer = writer;
        }
        public void Apply(TSrc src, TDst dst)
        {
            var value = Read(src);

            value = Convert.ChangeType(value, _dstProperty.PropertyType);

            Write(dst, value);
        }

        private object Read(TSrc src)
        {
            return _reader == null
                ? _srcProperty.GetValue(src, null)
                : _reader(src);

        }
        private void Write(TDst dst, object value)
        {
            if (_writer == null)
            {
                _dstProperty.SetValue(dst, value, null);
            }
            else
            {
                _writer(dst, value);
            }
        }
    }
}
