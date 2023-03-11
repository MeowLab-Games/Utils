using System;
using System.Linq;
using System.Runtime.CompilerServices;
using MeowLab.Utils;
using UnityEngine;

namespace MeowLab.Utils
{
    public static class Vector3Extensions
    {
        //Utils
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 WithX(this Vector3 vec, float x) {
            return new Vector3(x, vec.y, vec.z);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 WithY(this Vector3 vec, float y) {
            return new Vector3(vec.x, y, vec.z);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 WithZ(this Vector3 vec, float z) {
            return new Vector3(vec.x, vec.y, z);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 AddX(this Vector3 vec, float x) {
            return new Vector3(vec.x + x, vec.y, vec.z);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 AddY(this Vector3 vec, float y) {
            return new Vector3(vec.x, vec.y + y, vec.z);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 AddZ(this Vector3 vec, float z) {
            return new Vector3(vec.x, vec.y, vec.z + z);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 InvertX(this Vector3 vec) {
            return new Vector3(-vec.x, vec.y, vec.z);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 InvertY(this Vector3 vec) {
            return new Vector3(vec.x, -vec.y, vec.z);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 InvertZ(this Vector3 vec) {
            return new Vector3(vec.x, vec.y, -vec.z);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Invert(this Vector3 vec) {
            return new Vector3(-vec.x, -vec.y, -vec.z);
        }


        //Mathf
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Abs(this Vector3 v) {
            return new Vector3(
                Mathf.Abs(v.x),
                Mathf.Abs(v.y),
                Mathf.Abs(v.z)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Approximately(this Vector3 v, Vector3 v2) {
            return Mathf.Approximately(v.x, v2.x)
                   && Mathf.Approximately(v.y, v2.y)
                   && Mathf.Approximately(v.y, v2.z);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Ceil(this Vector3 v) {
            return new Vector3(
                Mathf.Ceil(v.x),
                Mathf.Ceil(v.y),
                Mathf.Ceil(v.z)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3Int CeilToInt(this Vector3 v) {
            return new Vector3Int(
                Mathf.CeilToInt(v.x),
                Mathf.CeilToInt(v.y),
                Mathf.CeilToInt(v.z)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Clamp(this Vector3 v, Vector3 min, Vector3 max) {
            return new Vector3(
                Mathf.Clamp(v.x, min.x, max.x),
                Mathf.Clamp(v.y, min.y, max.y),
                Mathf.Clamp(v.z, min.z, max.z)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Clamp(this Vector3 v, float min, float max) {
            return new Vector3(
                Mathf.Clamp(v.x, min, max),
                Mathf.Clamp(v.y, min, max),
                Mathf.Clamp(v.z, min, max)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Clamp01(this Vector3 v) {
            return new Vector3(
                Mathf.Clamp01(v.x),
                Mathf.Clamp01(v.y),
                Mathf.Clamp01(v.z)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3Int Clamp01Int(this Vector3 v) {
            return new Vector3Int(
                (int)Mathf.Clamp01(v.x),
                (int)Mathf.Clamp01(v.y),
                (int)Mathf.Clamp01(v.z)
            );
        }


        // [MethodImpl(MethodImplOptions.AggressiveInlining)]
        // public static Vector3 ClosestPowerOfTwo(this Vector3 v)
        // {
        //     return new Vector3(
        //Mathf.ClosestPowerOfTwo(v.x),
        //Mathf.ClosestPowerOfTwo(v.y)
        //);
        // }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Floor(this Vector3 v) {
            return new Vector3(
                Mathf.Floor(v.x),
                Mathf.Floor(v.y),
                Mathf.Floor(v.z)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3Int FloorToInt(this Vector3 v) {
            return new Vector3Int(
                Mathf.FloorToInt(v.x),
                Mathf.FloorToInt(v.y),
                Mathf.FloorToInt(v.z)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 InverseLerp(this Vector3 v, Vector3 a, Vector3 b) {
            return new Vector3(
                Mathf.InverseLerp(a.x, b.x, v.x),
                Mathf.InverseLerp(a.y, b.y, v.y),
                Mathf.InverseLerp(a.z, b.z, v.z)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 InverseLerp(this Vector3 v, float a, float b) {
            return new Vector3(
                Mathf.InverseLerp(a, b, v.x),
                Mathf.InverseLerp(a, b, v.y),
                Mathf.InverseLerp(a, b, v.z)
            );
        }


        //
        // [MethodImpl(MethodImplOptions.AggressiveInlining)]
        // public static Vector3 IsPowerOfTwo(this Vector3 v)
        // {
        //     return new Vector3(
        //Mathf.IsPowerOfTwo(v.x),
        //Mathf.IsPowerOfTwo(v.y)
        //);
        // }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Lerp(this Vector3 v, Vector3 a, Vector3 b) {
            return new Vector3(
                Mathf.Lerp(a.x, b.x, v.x),
                Mathf.Lerp(a.y, b.y, v.y),
                Mathf.Lerp(a.z, b.z, v.z)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Lerp(this Vector3 v, float a, float b) {
            return new Vector3(
                Mathf.Lerp(a, b, v.x),
                Mathf.Lerp(a, b, v.y),
                Mathf.Lerp(a, b, v.z)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 LerpUnclamped(this Vector3 v, Vector3 a, Vector3 b) {
            return new Vector3(
                Mathf.LerpUnclamped(a.x, b.x, v.x),
                Mathf.LerpUnclamped(a.y, b.y, v.y),
                Mathf.LerpUnclamped(a.z, b.z, v.z)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 LerpUnclamped(this Vector3 v, float a, float b) {
            return new Vector3(
                Mathf.LerpUnclamped(a, b, v.x),
                Mathf.LerpUnclamped(a, b, v.y),
                Mathf.LerpUnclamped(a, b, v.z)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Log(this Vector3 v) {
            return new Vector3(
                Mathf.Log(v.x),
                Mathf.Log(v.y),
                Mathf.Log(v.z)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Log(this Vector3 v, Vector3 p) {
            return new Vector3(
                Mathf.Log(v.x, p.x),
                Mathf.Log(v.y, p.y),
                Mathf.Log(v.z, p.z)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Log(this Vector3 v, float p) {
            return new Vector3(
                Mathf.Log(v.x, p),
                Mathf.Log(v.y, p),
                Mathf.Log(v.z, p)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Log10(this Vector3 v) {
            return new Vector3(
                Mathf.Log10(v.x),
                Mathf.Log10(v.y),
                Mathf.Log10(v.z)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Max(this Vector3 v, params Vector3[] vectors) {
            return new Vector3(
                Mathf.Max(vectors.Select(vec => vec.x).Prepend(v.x).ToArray()),
                Mathf.Max(vectors.Select(vec => vec.y).Prepend(v.y).ToArray()),
                Mathf.Max(vectors.Select(vec => vec.z).Prepend(v.z).ToArray())
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Max(this Vector3 v, params float[] values) {
            return new Vector3(
                Mathf.Max(values.Select(value => value).Prepend(v.x).ToArray()),
                Mathf.Max(values.Select(value => value).Prepend(v.y).ToArray()),
                Mathf.Max(values.Select(value => value).Prepend(v.z).ToArray())
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Min(this Vector3 v, params Vector3[] vectors) {
            return new Vector3(
                Mathf.Min(vectors.Select(vec => vec.x).Prepend(v.x).ToArray()),
                Mathf.Min(vectors.Select(vec => vec.y).Prepend(v.y).ToArray()),
                Mathf.Min(vectors.Select(vec => vec.z).Prepend(v.z).ToArray())
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Min(this Vector3 v, params float[] values) {
            return new Vector3(
                Mathf.Min(values.Select(value => value).Prepend(v.x).ToArray()),
                Mathf.Min(values.Select(value => value).Prepend(v.y).ToArray()),
                Mathf.Min(values.Select(value => value).Prepend(v.z).ToArray())
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 MoveTowards(this Vector3 v, Vector3 target, float maxDelta) {
            return new Vector3(
                Mathf.MoveTowards(v.x, target.x, maxDelta),
                Mathf.MoveTowards(v.y, target.y, maxDelta),
                Mathf.MoveTowards(v.z, target.z, maxDelta)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 MoveTowards(this Vector3 v, float target, float maxDelta) {
            return new Vector3(
                Mathf.MoveTowards(v.x, target, maxDelta),
                Mathf.MoveTowards(v.y, target, maxDelta),
                Mathf.MoveTowards(v.z, target, maxDelta)
            );
        }


        // [MethodImpl(MethodImplOptions.AggressiveInlining)]
        // public static Vector3 NextPowerOfTwo(this Vector3 v)
        // {
        //     return new Vector3(
        //Mathf.NextPowerOfTwo(v.x),
        //Mathf.NextPowerOfTwo(v.y)
        //);
        // }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float PerlinNoise(this Vector3 v) {
            return Mathf.PerlinNoise(v.x, v.y);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 PingPong(this Vector3 v, Vector3 time) {
            return new Vector3(
                Mathf.PingPong(time.x, v.x),
                Mathf.PingPong(time.y, v.y),
                Mathf.PingPong(time.z, v.z)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 PingPong(this Vector3 v, float time) {
            return new Vector3(
                Mathf.PingPong(time, v.x),
                Mathf.PingPong(time, v.y),
                Mathf.PingPong(time, v.z)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Pow(this Vector3 v, Vector3 time) {
            return new Vector3(
                Mathf.Pow(v.x, time.x),
                Mathf.Pow(v.y, time.y),
                Mathf.Pow(v.y, time.z)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Pow(this Vector3 v, float pow) {
            return new Vector3(
                Mathf.Pow(v.x, pow),
                Mathf.Pow(v.y, pow),
                Mathf.Pow(v.z, pow)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Repeat(this Vector3 v, Vector3 time) {
            return new Vector3(
                Mathf.Repeat(time.x, v.x),
                Mathf.Repeat(time.y, v.y),
                Mathf.Repeat(time.z, v.z)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Repeat(this Vector3 v, float time) {
            return new Vector3(
                Mathf.Repeat(time, v.x),
                Mathf.Repeat(time, v.y),
                Mathf.Repeat(time, v.z)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Round(this Vector3 v) {
            return new Vector3(
                Mathf.Round(v.x),
                Mathf.Round(v.y),
                Mathf.Round(v.z)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3Int RoundToInt(this Vector3 v) {
            return new Vector3Int(
                Mathf.RoundToInt(v.x),
                Mathf.RoundToInt(v.y),
                Mathf.RoundToInt(v.z)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Sign(this Vector3 v) {
            return new Vector3(
                v.x.Sign(),
                v.y.Sign(),
                v.z.Sign()
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 SmoothDamp(this Vector3 v, Vector3 target, Vector3 time) {
            return new Vector3(
                Mathf.SmoothStep(v.x, target.x, time.x),
                Mathf.SmoothStep(v.y, target.y, time.y),
                Mathf.SmoothStep(v.z, target.z, time.z)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 SmoothDamp(this Vector3 v, Vector3 target, float time) {
            return new Vector3(
                Mathf.SmoothStep(v.x, target.x, time),
                Mathf.SmoothStep(v.y, target.y, time),
                Mathf.SmoothStep(v.z, target.z, time)
            );
        }


        //Convert
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3Int ToVector3Int(this Vector3 v) {
            return new Vector3Int((int)v.x, (int)v.y, (int)v.z);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2Int ToVector2Int(this Vector3 v) {
            return new Vector2Int((int)v.x, (int)v.y);
        }


        //Mathematics
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 Remainder(this Vector3 dividend, Vector3 divider) {
            return new Vector3(
                dividend.x % divider.x,
                dividend.y % divider.y,
                dividend.z % divider.z
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Divide(this Vector3 dividend, Vector3 divider) {
            return new Vector3(
                dividend.x / divider.x,
                dividend.y / divider.y,
                dividend.z / divider.z
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Multiply(this Vector3 first, Vector3 second) {
            return new Vector3(
                first.x * second.x,
                first.y * second.y,
                first.z * second.z
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Sub(this Vector3 first, Vector3 second) {
            return new Vector3(
                first.x - second.x,
                first.y - second.y,
                first.z - second.z
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 SubIf(this Vector3 first, Vector3 second, Func<float, float, bool> func) {
            return new Vector3(
                first.x - (func.Invoke(first.x, second.x) ? second.x : 0),
                first.y - (func.Invoke(first.y, second.y) ? second.y : 0),
                first.z - (func.Invoke(first.z, second.z) ? second.z : 0)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Sum(this Vector3 first, Vector3 second) {
            return new Vector3(
                first.x + second.x,
                first.y + second.y,
                first.z + second.z
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 SumIf(this Vector3 first, Vector3 second, Func<float, float, bool> func) {
            return new Vector3(
                first.x + (func.Invoke(first.x, second.x) ? second.x : 0),
                first.y + (func.Invoke(first.y, second.y) ? second.y : 0),
                first.z + (func.Invoke(first.z, second.z) ? second.z : 0)
            );
        }
    }
}