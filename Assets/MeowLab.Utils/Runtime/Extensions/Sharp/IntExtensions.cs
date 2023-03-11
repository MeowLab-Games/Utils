using UnityEngine;

namespace MeowLab.Utils
{
    public static class IntExtensions
    {
        public static int Sign(this int value) {
            if (value == 0) return 0;
            return (int)Mathf.Sign(value);
        }
    }
}