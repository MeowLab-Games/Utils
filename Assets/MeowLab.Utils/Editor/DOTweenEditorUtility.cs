#if DOTween || DOTweenPro
using System;
using DG.DOTweenEditor;
using DG.Tweening;
using UnityEngine;

namespace MeowLab.Utils.Editor
{
    public static class DOTweenEditorUtility
    {
        public static Tween RunInEditor(Func<Tween> tweenFunc) {
            var tween = tweenFunc?.Invoke();
            if (!Application.isPlaying) {
                DOTweenEditorPreview.Stop();
                tween.SetUpdate(UpdateType.Manual);
                DOTweenEditorPreview.PrepareTweenForPreview(tween);
                DOTweenEditorPreview.Start();
            }

            return tween;
        }
    }
}
#endif