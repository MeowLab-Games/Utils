using System.Linq;
using UnityEditor;
using UnityEngine;

namespace MeowLab.Utils.Editor
{
    public static class HotkeyActions
    {
        [MenuItem("MeowLab/QuickAction/ResetTransform")]
        public static void ResetTransform() {
            var transforms = Selection.objects.OfType<GameObject>().Select(go => go.transform).ToArray();
            Undo.RecordObjects(transforms, "ResetTransform");
            foreach (var t in transforms) {
                t.localPosition = Vector3.zero;
                t.localRotation = Quaternion.identity;
                t.localScale = Vector3.one;
                if (t is RectTransform rectTransform) {
                    rectTransform.anchorMin = Vector2.zero;
                    rectTransform.anchorMax = Vector2.one;
                    rectTransform.offsetMin = Vector2.zero;
                    rectTransform.offsetMax = Vector2.zero;
                    rectTransform.pivot = Vector2.one * 0.5f;
                }
            }
        }


        [MenuItem("MeowLab/QuickAction/AnchorsToCorners")]
        public static void AnchorsToCorners() {
            if (Selection.transforms == null || Selection.transforms.Length == 0) {
                return;
            }

            Undo.IncrementCurrentGroup();
            Undo.SetCurrentGroupName("AnchorsToCorners");
            var undoGroup = Undo.GetCurrentGroup();

            foreach (Transform transform in Selection.transforms) {
                RectTransform t = transform as RectTransform;
                Undo.RecordObject(t, "AnchorsToCorners");
                RectTransform pt = Selection.activeTransform.parent as RectTransform;

                if (t == null || pt == null) return;

                Vector2 newAnchorsMin = new Vector2(t.anchorMin.x + t.offsetMin.x / pt.rect.width,
                    t.anchorMin.y + t.offsetMin.y / pt.rect.height);
                Vector2 newAnchorsMax = new Vector2(t.anchorMax.x + t.offsetMax.x / pt.rect.width,
                    t.anchorMax.y + t.offsetMax.y / pt.rect.height);

                t.anchorMin = newAnchorsMin;
                t.anchorMax = newAnchorsMax;
                t.offsetMin = t.offsetMax = new Vector2(0, 0);
            }

            Undo.CollapseUndoOperations(undoGroup);
        }


        [MenuItem("MeowLab/QuickAction/CornersToAnchors")]
        public static void CornersToAnchors() {
            if (Selection.transforms == null || Selection.transforms.Length == 0) {
                return;
            }

            Undo.IncrementCurrentGroup();
            Undo.SetCurrentGroupName("CornersToAnchors");
            var undoGroup = Undo.GetCurrentGroup();

            foreach (Transform transform in Selection.transforms) {
                RectTransform t = transform as RectTransform;
                Undo.RecordObject(t, "CornersToAnchors");

                if (t == null) return;

                t.offsetMin = t.offsetMax = new Vector2(0, 0);
            }

            Undo.CollapseUndoOperations(undoGroup);
        }
    }
}