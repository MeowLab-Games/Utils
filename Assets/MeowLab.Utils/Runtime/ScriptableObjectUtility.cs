using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace MeowLab.Utils
{
    public static class ScriptableObjectUtility
    {
#if UNITY_EDITOR

        private static List<Object> _cache = new List<Object>();


        public static T[] GetAllInstances<T>() where T : ScriptableObject {
            var guids = UnityEditor.AssetDatabase.FindAssets($"t:{typeof(T).Name}");
            var a = new T[guids.Length];
            for (var i = 0; i < guids.Length; i++) {
                var path = UnityEditor.AssetDatabase.GUIDToAssetPath(guids[i]);
                a[i] = UnityEditor.AssetDatabase.LoadAssetAtPath<T>(path);
            }

            return a;
        }


        public static T GetInstance<T>() where T : ScriptableObject {
            var guids = UnityEditor.AssetDatabase.FindAssets($"t:{typeof(T).Name}");
            if (guids.Length > 1) {
                Debug.LogError($"{typeof(T)} instances more than 1");
            }

            if (guids.Length > 0) {
                var path = UnityEditor.AssetDatabase.GUIDToAssetPath(guids[0]);
                return UnityEditor.AssetDatabase.LoadAssetAtPath<T>(path);
            }

            return default;
        }


        public static ScriptableObject GetInstance(Type type)  {
            _cache.Clear();

            var guids = UnityEditor.AssetDatabase.FindAssets($"t:{type}");
            foreach (var guid in guids) {
                var path = UnityEditor.AssetDatabase.GUIDToAssetPath(guid);
                var obj = UnityEditor.AssetDatabase.LoadAssetAtPath<Object>(path);
                var objType = obj.GetType();
                if (objType.IsSubclassOf(type)) {
                    _cache.Add(obj);
                }
            }
           

            if (_cache.Count > 1) {
                Debug.LogError($"{type.Name} instances more than 1. Instances count: {_cache.Count}");
            }

            if (_cache.Count > 0) {
                return _cache[0] as ScriptableObject;
            }

            return default;
        }
        //
        //
        // public static ScriptableObject GetGenericInstance<T>(Type genericParameter) where T : ScriptableObject {
        //     _cache.Clear();
        //
        //     var guids = UnityEditor.AssetDatabase.FindAssets($"t:{typeof(T)}");
        //     var generic = 
        //     foreach (var guid in guids) {
        //         var path = AssetDatabase.GUIDToAssetPath(guid);
        //         var obj = AssetDatabase.LoadAssetAtPath<T>(path);
        //         if (obj!= null) {
        //             Debug.Log(obj.name);
        //             _cache.Add(obj);
        //         }
        //     }
        //
        //     if (_cache.Count > 1) {
        //         Debug.LogError($"{typeof(T).Name}<{genericParameter.Name}> instances more than 1. Instances count: {_cache.Count}");
        //     }
        //
        //     if (_cache.Count > 0) {
        //         return _cache[0] as ScriptableObject;
        //     }
        //
        //     return default;
        // }


        public static T New<T>(string directory, string name) where T : ScriptableObject {
            var so = ScriptableObject.CreateInstance<T>();
            CreateAsset(so, directory, name);
            return so;
        }


        public static void CreateAsset(Object obj, string directory, string name) {
            if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);
            AssetDatabase.CreateAsset(obj, Path.Combine(directory, name));
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
#endif
    }
}