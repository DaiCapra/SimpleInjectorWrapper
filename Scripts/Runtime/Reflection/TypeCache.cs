using System;
using System.Collections.Generic;
using System.Reflection;

namespace SimpleInjectorWrapper.Runtime.Reflection
{
    public class TypeCache
    {
        public Dictionary<Type, List<FieldInfo>> fieldMap;
        public Dictionary<Type, List<PropertyInfo>> propertyMap;

        public TypeCache()
        {
            fieldMap = new Dictionary<Type, List<FieldInfo>>();
            propertyMap = new Dictionary<Type, List<PropertyInfo>>();
        }
    }
}