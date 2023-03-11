namespace MeowLab.Utils
{
    public class NSSingleton<T> where T : NSSingleton<T>, new()
    {
        private static T _instance;

        public static T I => _instance ??= new T();


        public static void SetInstance(T newInstance) {
            _instance = newInstance;
        }


        public virtual void Dispose() {
            _instance = null;
        }
    }
}