#if UNITY_EDITOR
using UnityEditor;
using UnityEngine.UIElements;

namespace MeowLab.Utils
{
    public static class VisualElementExtensions
    {
        public static VisualElement ExpandHorizontal(this VisualElement element) {
            element.style.marginLeft = -15f;
            element.style.marginRight = -5f;
            return element;
        }


        public static VisualElement SetWidthAsLabel(this VisualElement element) {
            element.style.minWidth = EditorGUIUtility.labelWidth + EditorGUIUtility.fieldWidth * 0.5f + 6f;
            element.style.maxWidth = EditorGUIUtility.labelWidth + EditorGUIUtility.fieldWidth * 0.5f + 6f;
            return element;
        }


        public static VisualElement SetWidth(this VisualElement element, float width) {
            element.style.minWidth = width;
            element.style.maxWidth = width;
            return element;
        }


        public static VisualElement WithLabel(this VisualElement element, string text) {
            var root = new VisualElement();
            var label = new Label(text);

            root.style.flexDirection = FlexDirection.Row;
            label.style.flexBasis = 0;
            label.style.flexGrow = 1;
            label.style.marginLeft = 3;
            label.style.marginTop = 3;
            element.style.flexBasis = 0;
            element.style.flexGrow = 1;


            root.Add(label.SetWidthAsLabel());
            root.Add(element);
            return root;
        }
    }
}
#endif