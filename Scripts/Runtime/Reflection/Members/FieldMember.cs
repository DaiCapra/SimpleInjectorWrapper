using System;
using System.Reflection;

namespace SimpleInjectorWrapper.Runtime.Reflection.Members
{
    public class FieldMember : Member
    {
        private readonly FieldInfo _fieldInfo;

        public FieldMember(FieldInfo fieldInfo)
        {
            _fieldInfo = fieldInfo;
        }

        public override object Get(object source)
        {
            return _fieldInfo.GetValue(source);
        }

        public override T GetCustomAttribute<T>()
        {
            return _fieldInfo.GetCustomAttribute<T>();
        }

        public override string Name()
        {
            return _fieldInfo.Name;
        }

        public override void Set(object source, object value)
        {
            _fieldInfo.SetValue(source, value);
        }

        public override Type Type()
        {
            return _fieldInfo.FieldType;
        }
    }
}