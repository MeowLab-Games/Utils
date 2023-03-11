#if DOTween || DOTweenPro
using DG.Tweening;
using DG.Tweening.Core;
using UnityEngine;


namespace MeowLab.SDK
{
    public static class DoTweenExtensions
    {
        public static Tweener DOBlendableAnchorPos(this RectTransform target, Vector2 endValue, float duration, bool snapping = false)
        {
            endValue = endValue - target.anchoredPosition;
            var to = Vector2.zero;
            return DOTween.To(() => to, x =>
                {
                    var diff = x - to;
                    to = x;
                    target.anchoredPosition += diff;
                }, endValue, duration)
                .Blendable()
                .SetOptions(snapping)
                .SetTarget(target);
        }


        public static Tweener DoOffsetMinMax(this RectTransform target, Vector2 min, Vector2 max, float duration)
        {
            var to = 0f;
            var minStart = target.offsetMin;
            var maxStart = target.offsetMax;
            return DOTween.To(() => to, t =>
            {
                to = t;
                target.offsetMin = Vector2.LerpUnclamped(minStart, min, t);
                target.offsetMax = Vector2.LerpUnclamped(maxStart, max, t);
            }, 1f, duration);
        }


        public static Tweener DoMaterialColor(this Renderer renderer, string propertyName, Color color, float duration)
        {
            var materialPropertyBlock = new MaterialPropertyBlock();
            var name = Shader.PropertyToID(propertyName);
            renderer.GetPropertyBlock(materialPropertyBlock);

            var startColor = materialPropertyBlock.GetColor(name);

            return DOVirtual.Color(startColor, color, duration, c =>
            {
                materialPropertyBlock.SetColor(name, c);
                renderer.SetPropertyBlock(materialPropertyBlock);
            });
        }


        public static Tweener DoMaterialFloat(this Renderer renderer, string propertyName, float value, float duration)
        {
            var materialPropertyBlock = new MaterialPropertyBlock();
            var name = Shader.PropertyToID(propertyName);
            renderer.GetPropertyBlock(materialPropertyBlock);

            var startValue = materialPropertyBlock.GetFloat(name);

            return DOVirtual.Float(startValue, value, duration, c =>
            {
                materialPropertyBlock.SetFloat(name, c);
                renderer.SetPropertyBlock(materialPropertyBlock);
            });
        }


        // //------------------------------------------------------------------------------------------------------------------------------------------------------
        // //Extensions for settings component
        // public static TweenerCore<Vector3, Vector3, VectorOptions> DOScale(this Transform t, Vector3TweenSettings settings)
        // {
        //     return t.DOScale(settings.value, settings.duration).SetEase(settings.ease).SetDelay(settings.delay);
        // }
        //
        //
        // public static TweenerCore<Vector3, Vector3, VectorOptions> DOScale(this Transform t, Vector3 endValue, TweenSettings settings)
        // {
        //     return t.DOScale(endValue, settings.duration).SetEase(settings.ease).SetDelay(settings.delay);
        // }
        //
        //
        // public static Tweener DOBlendableScaleBy(this Transform t, Vector3TweenSettings settings)
        // {
        //     return t.DOBlendableScaleBy(settings.value, settings.duration).SetEase(settings.ease).SetDelay(settings.delay);
        // }
        //
        //
        // public static TweenerCore<Vector3, Vector3, VectorOptions> DOMove(this Transform t, Vector3TweenSettings settings)
        // {
        //     return DOMove(t, settings.value, settings);
        // }
        //
        //
        // public static TweenerCore<Vector3, Vector3, VectorOptions> DOMove(this Transform t, Vector3 endPoint, TweenSettings settings)
        // {
        //     var tween = t.DOMove(endPoint, settings.duration)
        //         .SetDelay(settings.delay);
        //
        //     if (settings.ease == Ease.INTERNAL_Custom)
        //         tween.SetEase(settings.curve);
        //     else
        //         tween.SetEase(settings.ease);
        //
        //     return tween;
        // }
        //
        //
        // public static Tweener DOBlendableMoveBy(this Transform t, Vector3TweenSettings settings)
        // {
        //     return t.DOBlendableMoveBy(settings.value, settings.duration).SetEase(settings.ease).SetDelay(settings.delay);
        // }
        //
        //
        // public static TweenerCore<Vector3, Vector3, VectorOptions> DOLocalMove(this Transform t, Vector3TweenSettings settings)
        // {
        //     return t.DOLocalMove(settings.value, settings.duration).SetEase(settings.ease).SetDelay(settings.delay);
        // }
        //
        //
        // public static Tweener DOBlendableLocalMoveBy(this Transform t, Vector3TweenSettings settings)
        // {
        //     return t.DOBlendableLocalMoveBy(settings.value, settings.duration).SetEase(settings.ease).SetDelay(settings.delay);
        // }
        //
        //
        // public static TweenerCore<Quaternion, Vector3, QuaternionOptions> DOLocalRotate(this Transform t, Vector3TweenSettings settings)
        // {
        //     return t.DOLocalRotate(settings.value, settings.duration).SetEase(settings.ease).SetDelay(settings.delay);
        // }
        //
        //
        // public static Tweener DOBlendableLocalRotateBy(this Transform t, Vector3TweenSettings settings)
        // {
        //     return t.DOBlendableLocalRotateBy(settings.value, settings.duration).SetEase(settings.ease).SetDelay(settings.delay);
        // }
    }
}
#endif