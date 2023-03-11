using System.Runtime.CompilerServices;
using UnityEngine;

namespace MeowLab.Utils
{
    public static class RaycastUtility
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Point(Ray ray, RaycastHit hit, float distance) {
            return hit.collider == null ? ray.GetPoint(distance) : hit.point;
        }
    }
}