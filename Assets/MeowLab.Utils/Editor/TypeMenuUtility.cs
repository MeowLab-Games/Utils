using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;

namespace MeowLab.Utils.Editor
{
    public static class TypeMenuUtility
    {
        public const string NullDisplayName = "<null>";


        public static string[] GetSplittedTypePath(Type type) {
            if (type == null)
                return new[] { NullDisplayName };
            int splitIndex = type.FullName.LastIndexOf('.');
            if (splitIndex >= 0) {
                return new string[] { type.FullName.Substring(0, splitIndex), type.FullName.Substring(splitIndex + 1) };
            }
            else {
                return new string[] { type.Name };
            }
        }


        public static IEnumerable<Type> OrderByType(this IEnumerable<Type> source) {
            return source.OrderBy(type => {
                if (type == null) {
                    return -999;
                }

                return 0;
            });
        }


        public static string GetTypeName(Type type) {
            return type == null ? NullDisplayName : ObjectNames.NicifyVariableName(type.Name);
        }
    }
}