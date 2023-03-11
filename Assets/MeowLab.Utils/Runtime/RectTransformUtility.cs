using UnityEngine;

namespace MeowLab.Utils
{
    public static class RectTransformUtility
    {
        public static Vector3 ClampLocalPosition(RectTransform parentRect, Vector3 pos, RectOffset offset) {
            var rect = parentRect.rect;
            var halfW = rect.width * 0.5f;
            var halfH = rect.height * 0.5f;
            pos.x = Mathf.Clamp(pos.x, -halfW + offset.left, halfW - offset.right);
            pos.y = Mathf.Clamp(pos.y, -halfH + offset.bottom, halfH - offset.top);
            return pos;
        }
    }
}