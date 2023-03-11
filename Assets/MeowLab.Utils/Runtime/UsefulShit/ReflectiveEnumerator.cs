using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MeowLab.Utils
{
    public static class ReflectiveEnumerator
    {
        public static IEnumerable<T> GetEnumerableOfType<T>(params object[] constructorArgs) where T : class {
            List<T> objects = new List<T>();
            foreach (Type type in
                     Assembly.GetAssembly(typeof(T)).GetTypes()
                         .Where(myType => myType.IsClass && !myType.IsAbstract && !myType.ContainsGenericParameters && myType.IsSubclassOf(typeof(T)))) {
                objects.Add((T)Activator.CreateInstance(type, constructorArgs));
            }

            return objects;
        }
    }
}