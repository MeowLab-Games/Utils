using UnityEngine;

namespace MeowLab.Utils
{
    public class SSingletonContainer : MonoBehaviour
    {
        private static GameObject _container;


        protected static T AddSingleton<T>() where T : MonoBehaviour {
            if (_container == null) {
                _container = new GameObject("SSingletonContainer");
                if (Application.isPlaying)
                    DontDestroyOnLoad(_container);
            }

            return _container.AddComponent<T>();
        }


        public virtual void OnDestroy() {
            _container = null;
        }
    }
}