using UnityEngine;


namespace MeowLab.Utils
{
    public static class Lerp
    {
        public static (Vector3, Quaternion) ArcWithRotation(Vector3 start, Vector3 end, float height, float t) {
            var center = (start + end) * 0.5f;
            var pos = Vector3.LerpUnclamped(start, end, t);
            pos.y += (4 * height) * (1f - t) * t;

            var rhs = Vector3.Cross(start - end, Vector3.up);
            var direction = Vector3.Cross(center - pos, rhs).normalized;

            return (pos, Quaternion.LookRotation(direction));
        }
    }
}