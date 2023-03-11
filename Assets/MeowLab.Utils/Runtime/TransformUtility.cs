using System.Runtime.CompilerServices;
using UnityEngine;

namespace MeowLab.Utils
{
    public static class TransformUtility
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void RotateAround(Transform transform, Vector3 pivotPoint, Vector3 axis, float angle) {
            RotateAround(transform, pivotPoint, Quaternion.AngleAxis(angle, axis));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void RotateAround(Transform transform, Vector3 pivotPoint, Quaternion rot) {
            transform.position = rot * (transform.position - pivotPoint) + pivotPoint;
            transform.rotation = rot * transform.rotation;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (Vector3, Quaternion) RotateAround(Vector3 tPosition, Quaternion tRotation, Vector3 pivotPoint, Vector3 axis, float angle) {
            var rot = Quaternion.AngleAxis(angle, axis);
            return RotateAround(tPosition, tRotation, pivotPoint, rot);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (Vector3, Quaternion) RotateAround(Vector3 tPosition, Quaternion tRotation, Vector3 pivotPoint, Quaternion rot) {
            return (rot * (tPosition - pivotPoint) + pivotPoint, rot * tRotation);
        }
    }
}