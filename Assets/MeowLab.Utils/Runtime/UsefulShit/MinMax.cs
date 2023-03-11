using System;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
#endif

namespace MeowLab.Utils
{
    [System.Serializable]
    public struct MinMaxInt
    {
        public int Min;
        public int Max;

        [NonSerialized] public int Value;


        public int Shuffle() {
            Value = UnityEngine.Random.Range(Min, Max);
            return Value;
        }


        public int Next() => UnityEngine.Random.Range(Min, Max);
        public int FloorEvaluate(float t) => Mathf.FloorToInt(Mathf.LerpUnclamped(Min, Max, t));
        public int RoundEvaluate(float t) => Mathf.RoundToInt(Mathf.LerpUnclamped(Min, Max, t));
    }



    [System.Serializable]
    public struct MinMaxFloat
    {
        public float Min;
        public float Max;

        [NonSerialized] public float Value;


        public float Shuffle() {
            Value = UnityEngine.Random.Range(Min, Max);
            return Value;
        }


        public float Next() => UnityEngine.Random.Range(Min, Max);
        public float Evaluate(float t) => Mathf.LerpUnclamped(Min, Max, t);
    }



#if UNITY_EDITOR
    public class MinMaxPropertyDrawer<TField> : PropertyDrawer where TField : VisualElement, IBindable, new()
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property) {
            var root = new VisualElement();

            var label = new Label(property.displayName);
            label.style.alignSelf = Align.Center;


            var min = new VisualElement();
            var max = new VisualElement();
            min.style.flexDirection = FlexDirection.Row;
            max.style.flexDirection = FlexDirection.Row;
            min.style.flexGrow = 1;
            max.style.flexGrow = 1;

            var minLabel = new Label("Min");
            var maxLabel = new Label("Max");
            minLabel.style.alignSelf = Align.Center;
            maxLabel.style.alignSelf = Align.Center;

            var minValue = new TField();
            var maxValue = new TField();
            minValue.style.flexGrow = 1;
            maxValue.style.flexGrow = 1;
            minValue.BindProperty(property.FindPropertyRelative("Min"));
            maxValue.BindProperty(property.FindPropertyRelative("Max"));


            min.Add(minLabel);
            min.Add(minValue);
            max.Add(maxLabel);
            max.Add(maxValue);

            root.Add(label);
            root.Add(min);
            root.Add(max);

            root.style.flexDirection = FlexDirection.Row;
            return root;
        }
    }



    [CustomPropertyDrawer(typeof(MinMaxFloat))]
    public class MinMaxFloatPropertyDrawer : MinMaxPropertyDrawer<FloatField>
    {
    }



    [CustomPropertyDrawer(typeof(MinMaxInt))]
    public class MinMaxIntPropertyDrawer : MinMaxPropertyDrawer<IntegerField>
    {
    }
#endif
}