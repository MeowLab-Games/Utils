using System.Collections.Generic;

namespace MeowLab.Utils
{
    public interface IWeighted
    {
        int Weight { get; }
    }



    public static class RandomUtility
    {
        public static int WeightedChoiceIndex(IReadOnlyList<float> list) {
            if (list.Count == 0) return -1;


            var totalWeight = 0f;
            foreach (var value in list) totalWeight += value;
            var choice = UnityEngine.Random.value * totalWeight;
            var sum = 0f;

            for (var index = 0; index < list.Count; index++) {
                var obj = list[index];
                for (var i = sum; i < obj + sum; i++) {
                    if (i >= choice) {
                        return index;
                    }
                }

                sum += obj;
            }

            return 0;
        }


        public static T WeightedChoose<T>(IReadOnlyList<T> list) where T : IWeighted {
            if (list.Count == 0) return default(T);

            var totalWeight = 0f;
            foreach (var w in list) totalWeight += w.Weight;
            var choice = UnityEngine.Random.value * totalWeight;
            var sum = 0;

            foreach (var obj in list) {
                for (var i = sum; i < obj.Weight + sum; i++) {
                    if (i >= choice) {
                        return obj;
                    }
                }

                sum += obj.Weight;
            }

            return list[0];
        }


        public static T Random<T>(IReadOnlyList<T> list) {
            var length = list.Count;
            return length > 0 ? list[UnityEngine.Random.Range(0, length)] : default;
        }
    }
}