using System;
using System.Reflection;

namespace SimpleInjectorWrapper.Scripts.Runtime.Reflection.Members
{
    public class PropertyMember : Member
    {
        private readonly PropertyInfo _propertyInfo;

        public PropertyMember(PropertyInfo propertyInfo)
        {
            _propertyInfo = propertyInfo;
        }

        public override object Get(object source)
        {
            return _propertyInfo.GetValue(source);
        }

        public override T GetCustomAttribute<T>()
        {
            return _propertyInfo.GetCustomAttribute<T>();
        }

        public override string Name()
        {
            return _propertyInfo.Name;
        }

        public override void Set(object source, object value)
        {
            _propertyInfo.SetValue(source, value);
        }

        public override Type Type()
        {
            return _propertyInfo.PropertyType;
        }
    }
}