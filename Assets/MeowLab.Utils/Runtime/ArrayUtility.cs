using System;

namespace MeowLab.Utils
{
    public static class ArrayUtility
    {
        public static T[] ConcatArrays<T>(params T[][] args) {
            if (args == null)
                throw new ArgumentNullException();

            var offset = 0;
            var newLength = 0;
            foreach (var arg in args) {
                newLength += arg.Length;
            }

            var newArray = new T[newLength];
            foreach (var arr in args) {
                Array.Copy(arr, 0, newArray, offset, arr.Length);
                offset += arr.Length;
            }

            return newArray;
        }
    }
}