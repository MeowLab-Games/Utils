using UnityEngine;

namespace MeowLab.Utils
{
    public static class D
    {
        public static void Log(string str) {
            Debug.Log(str);
        }


        public static void LogError(string str) {
            Debug.LogError(str);
        }
    }
}