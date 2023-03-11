using System;
using UnityEngine;

namespace MeowLab.Utils
{
    public static class GizmosUtility
    {
        public static void DrawPlane(Plane plane) {
            var normal = plane.normal;
            var size = normal.magnitude * 5;
            var origin = -normal.normalized * plane.distance;

            var left = Vector3.Cross(normal, Vector3.up).normalized;
            var up = Vector3.Cross(left, normal).normalized;

            if (Mathf.Approximately(left.sqrMagnitude, 0f)) {
                left = Vector3.left;
                up = Vector3.forward;
            }

            Gizmos.DrawLine(origin + up * size + left * size, origin + up * size - left * size);
            Gizmos.DrawLine(origin + up * size - left * size, origin - up * size - left * size);
            Gizmos.DrawLine(origin - up * size - left * size, origin - up * size + left * size);
            Gizmos.DrawLine(origin - up * size + left * size, origin + up * size + left * size);
        }
    }



    public readonly struct GizmosColorScope : IDisposable
    {
        private readonly Color _color;


        public GizmosColorScope(Color color) {
            _color = Gizmos.color;
            Gizmos.color = color;
        }


        public void Dispose() {
            Gizmos.color = _color;
        }
    }
}