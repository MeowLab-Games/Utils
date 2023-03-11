using System;
using UnityEngine;

namespace MeowLab.Utils
{
    public static class TransformExtensions
    {
        public static void LookAtByAxis(this Transform t, Vector3 point, Vector3 axis) {
            var distanceToPlane = Vector3.Dot(axis, point - t.position);
            var pointOnPlane = point - axis * distanceToPlane;
            t.LookAt(pointOnPlane, axis);
        }


        public static void SetSize(this RectTransform rect, RectTransform.Axis axis, float size) {
            var sizeDelta = rect.sizeDelta;
            var min = rect.offsetMin;
            var max = rect.offsetMax;
            var minAnchored = rect.anchorMin;
            var maxAnchored = rect.anchorMax;
            switch (axis) {
                case RectTransform.Axis.Horizontal:
                    if (min.x < max.x) {
                        min.x = -size;
                    }

                    min.x = -size * 0.5f;
                    max.x = size * 0.5f;
                    // else if (min.x < max.x)
                    // {
                    //     min.x = size - max.x ;
                    // }


                    break;

                case RectTransform.Axis.Vertical:
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(axis), axis, null);
            }

            rect.offsetMin = min;
            rect.offsetMax = max;

            // int index = (int)axis;
            // ref var local = ref sizeDelta;
            // local[index] = size;
            // rect.sizeDelta = sizeDelta;
            // rect.SetSizeWithCurrentAnchors(axis, size);
        }
    }
}