using UnityEngine;

namespace MeowLab.Utils
{
    public static class FloatExtensions
    {
        public static float Sign(this float value) {
            if (value == 0) return 0;
            return Mathf.Sign(value);
        }


        public static string ToPercentStringFrom01(this float value) {
            return Mathf.FloorToInt(Mathf.Clamp01(value) * 100f).ToString("P0");
        }
    }
}