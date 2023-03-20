using System.Runtime.CompilerServices;
using UnityEngine;

namespace MeowLab.Utils
{
    public static class ObjectExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T AsDontDestroyable<T>(T obj) where T : Object {
            Object.DontDestroyOnLoad(obj);
            return obj;
        }
    }
}