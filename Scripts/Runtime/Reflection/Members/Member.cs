using System;
using System.Reflection;

namespace SimpleInjectorWrapper.Scripts.Runtime.Reflection.Members
{
    public abstract class Member
    {
        public static Member Create(object member)
        {
            return member switch
            {
                FieldInfo fi => new FieldMember(fi),
                PropertyInfo pi => new PropertyMember(pi),
                _ => null
            };
        }

        public abstract object Get(object source);

        public abstract T GetCustomAttribute<T>() where T : Attribute;

        public abstract string Name();

        public abstract void Set(object source, object value);

        public abstract Type Type();
    }
}