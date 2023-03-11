using System.IO;
using UnityEngine;

namespace MeowLab.Utils
{
    public abstract class ResourceSingleton<T> : ScriptableObject where T : ScriptableObject
    {
        private static T instance;
        // protected const string AssetPath = "Assets/Resources/Singletones";

        public static T I {
            get {
                if (ReferenceEquals(instance, null)) {
                    Load();
                }

                return instance;
            }
        }


        public static void Load() {
            var path = Path.Combine(typeof(T).Name);
            instance = Resources.Load<T>(path);

#if UNITY_EDITOR
            if (instance == null) {
                instance = ScriptableObjectUtility.New<T>(Path.Combine("Assets", "Resources"), $"{typeof(T).Name}.asset");
            }
#endif
            var inst = instance as ResourceSingleton<T>;
            if (inst != null) {
                inst.OnInstanceLoaded();
            }
        }


        // public static async UniTask LoadAsync()
        // {
        //     var path = Path.Combine("Singletones", typeof(T).Name);
        //     instance = (T) await Resources.LoadAsync<T>(path);
        //
        //     var inst = instance as ResourceSingleton<T>;
        //     if (inst != null)
        //     {
        //         inst.OnInstanceLoaded();
        //     }
        // }

//
// #if UNITY_EDITOR
//         static void CreateAsset()
//         {
//             instance = CreateInstance<T>();
//             var path = Path.Combine(AssetPath, typeof(T).Name + ".asset");
//             path = AssetDatabase.GenerateUniqueAssetPath(path);
//             AssetDatabase.CreateAsset(instance, path);
//
//             AssetDatabase.SaveAssets();
//             AssetDatabase.Refresh();
//             EditorUtility.FocusProjectWindow();
//             Selection.activeObject = instance;
//         }
// #endif


        protected virtual void OnInstanceLoaded() {
        }
    }
}