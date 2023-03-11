using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace MeowLab.Utils
{
    public static class BoolVectorExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsAll(this bool2 value) => value.x && value.y;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsAll(this bool3 value) => value.x && value.y && value.z;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsAll(this bool4 value) => value.x && value.y && value.z && value.w;
    }
}