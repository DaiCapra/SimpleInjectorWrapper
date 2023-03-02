using SimpleInjectorWrapper.Runtime.Ioc;
using SimpleInjectorWrapper.Runtime.Reflection.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace SimpleInjectorWrapper.Runtime.Reflection
{
    public static class InjectionManager
    {
        private static readonly BindingFlags BindingFlags;
        private static readonly Dictionary<Type, List<Member>> CacheMembers;

        static InjectionManager()
        {
            CacheMembers = new Dictionary<Type, List<Member>>();
            BindingFlags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;
        }

        public static bool Inject(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var type = obj.GetType();
            if (!CacheMembers.TryGetValue(type, out var members))
            {
                members = GenerateMembers(type);
                CacheMembers[type] = members;
            }

            var container = Installer.Instance;
            if (obj is IContainer c)
            {
                c.Container = container;
            }

            foreach (var member in members)
            {
                var value = member.Get(obj);
                if (value != null)
                {
                    continue;
                }

                try
                {
                    var instance = container.GetInstance(member.Type());
                    member.Set(obj, instance);
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                    return false;
                }
            }

            return true;
        }

        private static List<Member> GenerateMembers(Type type)
        {
            var list = new List<Member>();
            foreach (var field in GetFields(type))
            {
                list.Add(new FieldMember(field));
            }

            foreach (var property in GetProperties(type))
            {
                list.Add(new PropertyMember(property));
            }

            return list;
        }

        private static List<FieldInfo> GetFields(Type type)
        {
            if (type?.BaseType == null)
            {
                return new List<FieldInfo>();
            }

            var fields = type.GetFields(BindingFlags)
                .Concat(type.BaseType.GetFields(BindingFlags))
                .Concat(type.BaseType.GetFields(BindingFlags))
                .Where(t => t.GetCustomAttributes(typeof(InjectAttribute), true).Length > 0)
                .ToList();
            return fields;
        }

        private static List<PropertyInfo> GetProperties(Type type)
        {
            if (type?.BaseType == null)
            {
                return new List<PropertyInfo>();
            }

            var properties = type.GetProperties(BindingFlags)
                .Concat(type.BaseType.GetProperties(BindingFlags))
                .Concat(type.BaseType.GetProperties(BindingFlags))
                .Where(t => t.GetCustomAttributes(typeof(InjectAttribute), true).Length > 0)
                .ToList();

            return properties;
        }
    }
}