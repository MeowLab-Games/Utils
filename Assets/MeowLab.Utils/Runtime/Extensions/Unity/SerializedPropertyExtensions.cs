#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using UnityEditor;

namespace MeowLab.Utils
{
    public static class SerializedPropertyExtensions
    {
        private static Regex ArrayIndexCapturePattern = new Regex(@"\[(\d*)\]");


        public static object GetTarget(this SerializedProperty prop) {
            var propertyNames = prop.propertyPath.Split('.');
            object target = prop.serializedObject.targetObject;
            var isNextPropertyArrayIndex = false;
            for (var i = 0; i < propertyNames.Length && target != null; ++i) {
                string propName = propertyNames[i];
                if (propName == "Array") {
                    isNextPropertyArrayIndex = true;
                }
                else if (isNextPropertyArrayIndex) {
                    isNextPropertyArrayIndex = false;
                    int arrayIndex = ParseArrayIndex(propName);
                    object[] targetAsArray = (object[])target;
                    target = targetAsArray[arrayIndex];
                }
                else {
                    target = GetField(target, propName);
                }
            }

            return target;
        }


        private static object GetField(object target, string name, Type targetType = null) {
            if (targetType == null) {
                targetType = target.GetType();
            }

            var fi = targetType.GetField(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (fi != null) {
                return fi.GetValue(target);
            }

            // If not found, search in parent
            if (targetType.BaseType != null) {
                return GetField(target, name, targetType.BaseType);
            }

            return null;
        }


        private static int ParseArrayIndex(string propName) {
            var match = ArrayIndexCapturePattern.Match(propName);
            if (!match.Success) {
                throw new Exception($"Invalid array index parsing in {propName}");
            }

            return int.Parse(match.Groups[1].Value);
        }


        public static IEnumerable<SerializedProperty> GetChildren(this SerializedProperty property) {
            property = property.Copy();
            var nextElement = property.Copy();
            bool hasNextElement = nextElement.NextVisible(false);
            if (!hasNextElement) {
                nextElement = null;
            }

            while (property.NextVisible(true)) {
                if ((SerializedProperty.EqualContents(property, nextElement))) {
                    yield break;
                }

                yield return property;
                //
                // bool hasNext = property.NextVisible(false);
                // if (!hasNext)
                // {
                //     break;
                // }
            }
        }


        public static IEnumerable<SerializedProperty> GetDirectChildren(this SerializedProperty parent) {
            parent = parent.Copy();
            int dots = parent.propertyPath.Count(c => c == '.');
            foreach (SerializedProperty inner in parent) {
                bool isDirectChild = inner.propertyPath.Count(c => c == '.') == dots + 1;
                if (isDirectChild)
                    yield return inner;
            }
        }


        public static object GetValue(this UnityEditor.SerializedProperty property) {
            object obj = property.serializedObject.targetObject;

            FieldInfo field = null;
            foreach (var path in property.propertyPath.Split('.')) {
                var type = obj.GetType();
                field = type.GetField(path);
                obj = field.GetValue(obj);
            }

            return obj;
        }


        // Sets value from SerializedProperty - even if value is nested
        public static void SetValue(this UnityEditor.SerializedProperty property, object val) {
            object obj = property.serializedObject.targetObject;

            List<KeyValuePair<FieldInfo, object>> list = new List<KeyValuePair<FieldInfo, object>>();

            FieldInfo field = null;
            foreach (var path in property.propertyPath.Split('.')) {
                var type = obj.GetType();
                field = type.GetField(path);
                list.Add(new KeyValuePair<FieldInfo, object>(field, obj));
                obj = field.GetValue(obj);
            }

            // Now set values of all objects, from child to parent
            for (int i = list.Count - 1; i >= 0; --i) {
                list[i].Key.SetValue(list[i].Value, val);
                // New 'val' object will be parent of current 'val' object
                val = list[i].Value;
            }
        }


        public static object SetManagedReference(this SerializedProperty property, Type type) {
            object obj = (type != null) ? Activator.CreateInstance(type) : null;
            property.managedReferenceValue = obj;
            return obj;
        }
        //
        //
        // public static Type GetType(string typeName) {
        //     int splitIndex = typeName.IndexOf(' ');
        //     var assembly = Assembly.Load(typeName.Substring(0, splitIndex));
        //     return assembly.GetType(typeName.Substring(splitIndex + 1));
        // }


        public static Type ExtractType(this SerializedProperty property) {
            var typeName = property.managedReferenceFullTypename;
            if (string.IsNullOrEmpty(typeName)) {
                return null;
            }

            var splitFieldTypename = typeName.Split(' ');
            var assemblyName = splitFieldTypename[0];
            var subStringTypeName = splitFieldTypename[1];
            var assembly = Assembly.Load(assemblyName);
            var targetType = assembly.GetType(subStringTypeName);
            return targetType;
        }
    }
}
#endif