using UnityEngine;

namespace MeowLab.Utils
{
    public class SSingleton<T> : SSingletonContainer where T : MonoBehaviour
    {
        private static T _instance;

        public static bool Existing => _instance != null;

        public static T I {
            get {
                if (_instance == null) {
                    _instance = AddSingleton<T>();
                }

                return _instance;
            }
        }


        public override void OnDestroy() {
            base.OnDestroy();
            _instance = null;
        }
    }
}