using UnityEngine;

namespace MeowLab.Utils
{
#if ODIN_INSPECTOR
        public abstract class SingleScript<T> : SerializedMonoBehaviour where T : SingleScript<T>
#else
    public abstract class SingleScript<T> : MonoBehaviour where T : SingleScript<T>
#endif
    {
        private static T _instance;

        public static T I {
            get {
#if UNITY_EDITOR
                if (!Application.isPlaying && !Exists) {
                    _instance = FindObjectOfType<T>();
                }
#endif
                return _instance;
            }
        }

        public static bool Exists => _instance != null;


        public virtual void Awake() {
            if (!Exists) {
                _instance = this as T;
            }
        }


        public virtual void OnDestroy() {
            _instance = null;
        }
    }
}