using System;
using System.Linq;
using System.Runtime.CompilerServices;
using MeowLab.Utils;
using UnityEngine;

namespace MeowLab.Utils
{
    public static class Vector3IntExtensions
    {
        //Utils
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3Int WithX(this Vector3Int vec, int x) {
            return new Vector3Int(x, vec.y, vec.z);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3Int WithY(this Vector3Int vec, int y) {
            return new Vector3Int(vec.x, y, vec.z);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3Int WithZ(this Vector3Int vec, int z) {
            return new Vector3Int(vec.x, vec.y, z);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3Int AddX(this Vector3Int vec, int x) {
            return new Vector3Int(vec.x + x, vec.y, vec.z);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3Int AddY(this Vector3Int vec, int y) {
            return new Vector3Int(vec.x, vec.y + y, vec.z);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3Int AddZ(this Vector3Int vec, int z) {
            return new Vector3Int(vec.x, vec.y, vec.z + z);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3Int InvertX(this Vector3Int vec) {
            return new Vector3Int(-vec.x, vec.y, vec.z);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3Int InvertY(this Vector3Int vec) {
            return new Vector3Int(vec.x, -vec.y, vec.z);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3Int InvertZ(this Vector3Int vec) {
            return new Vector3Int(vec.x, vec.y, -vec.z);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3Int Invert(this Vector3Int vec) {
            return new Vector3Int(-vec.x, -vec.y, -vec.z);
        }


        //Mathf
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3Int Abs(this Vector3Int v) {
            return new Vector3Int(
                Mathf.Abs(v.x),
                Mathf.Abs(v.y),
                Mathf.Abs(v.z)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Approximately(this Vector3Int v, Vector3Int v2) {
            return Mathf.Approximately(v.x, v2.x)
                   && Mathf.Approximately(v.y, v2.y)
                   && Mathf.Approximately(v.z, v2.z);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Ceil(this Vector3Int v) {
            return new Vector3(
                Mathf.Ceil(v.x),
                Mathf.Ceil(v.y),
                Mathf.Ceil(v.z)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3Int CeilToInt(this Vector3Int v) {
            return new Vector3Int(
                Mathf.CeilToInt(v.x),
                Mathf.CeilToInt(v.y),
                Mathf.CeilToInt(v.z)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Clamp(this Vector3Int v, Vector3 min, Vector3 max) {
            return new Vector3(
                Mathf.Clamp(v.x, min.x, max.x),
                Mathf.Clamp(v.y, min.y, max.y),
                Mathf.Clamp(v.z, min.z, max.z)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Clamp(this Vector3Int v, float min, float max) {
            return new Vector3(
                Mathf.Clamp(v.x, min, max),
                Mathf.Clamp(v.y, min, max),
                Mathf.Clamp(v.z, min, max)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Clamp01(this Vector3Int v) {
            return new Vector3(
                Mathf.Clamp01(v.x),
                Mathf.Clamp01(v.y),
                Mathf.Clamp01(v.z)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3Int Clamp01Int(this Vector3Int v) {
            return new Vector3Int(
                (int)Mathf.Clamp01(v.x),
                (int)Mathf.Clamp01(v.y),
                (int)Mathf.Clamp01(v.z)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3Int ClosestPowerOfTwo(this Vector3Int v) {
            return new Vector3Int(
                Mathf.ClosestPowerOfTwo(v.x),
                Mathf.ClosestPowerOfTwo(v.y),
                Mathf.ClosestPowerOfTwo(v.z)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Floor(this Vector3Int v) {
            return new Vector3(
                Mathf.Floor(v.x),
                Mathf.Floor(v.y),
                Mathf.Floor(v.z)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3Int FloorToInt(this Vector3Int v) {
            return new Vector3Int(
                Mathf.FloorToInt(v.x),
                Mathf.FloorToInt(v.y),
                Mathf.FloorToInt(v.z)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 InverseLerp(this Vector3Int v, Vector3 a, Vector3 b) {
            return new Vector3(
                Mathf.InverseLerp(a.x, b.x, v.x),
                Mathf.InverseLerp(a.y, b.y, v.y),
                Mathf.InverseLerp(a.z, b.z, v.z)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 InverseLerp(this Vector3Int v, float a, float b) {
            return new Vector3(
                Mathf.InverseLerp(a, b, v.x),
                Mathf.InverseLerp(a, b, v.y),
                Mathf.InverseLerp(a, b, v.z)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsPowerOfTwo(this Vector3Int v) {
            return Mathf.IsPowerOfTwo(v.x)
                   && Mathf.IsPowerOfTwo(v.y)
                   && Mathf.IsPowerOfTwo(v.z);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Lerp(this Vector3Int v, Vector3 a, Vector3 b) {
            return new Vector3(
                Mathf.Lerp(a.x, b.x, v.x),
                Mathf.Lerp(a.y, b.y, v.y),
                Mathf.Lerp(a.z, b.z, v.z)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Lerp(this Vector3Int v, float a, float b) {
            return new Vector3(
                Mathf.Lerp(a, b, v.x),
                Mathf.Lerp(a, b, v.y),
                Mathf.Lerp(a, b, v.z)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 LerpUnclamped(this Vector3Int v, Vector3 a, Vector3 b) {
            return new Vector3(
                Mathf.LerpUnclamped(a.x, b.x, v.x),
                Mathf.LerpUnclamped(a.y, b.y, v.y),
                Mathf.LerpUnclamped(a.z, b.z, v.z)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 LerpUnclamped(this Vector3Int v, float a, float b) {
            return new Vector3(
                Mathf.LerpUnclamped(a, b, v.x),
                Mathf.LerpUnclamped(a, b, v.y),
                Mathf.LerpUnclamped(a, b, v.z)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Log(this Vector3Int v) {
            return new Vector3(
                Mathf.Log(v.x),
                Mathf.Log(v.y),
                Mathf.Log(v.z)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Log(this Vector3Int v, Vector3 p) {
            return new Vector3(
                Mathf.Log(v.x, p.x),
                Mathf.Log(v.y, p.y),
                Mathf.Log(v.z, p.z)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Log(this Vector3Int v, float p) {
            return new Vector3(
                Mathf.Log(v.x, p),
                Mathf.Log(v.y, p),
                Mathf.Log(v.z, p)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Log10(this Vector3Int v) {
            return new Vector3(
                Mathf.Log10(v.x),
                Mathf.Log10(v.y),
                Mathf.Log10(v.z)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3Int Max(this Vector3Int v, params Vector3Int[] vectors) {
            return new Vector3Int(
                Mathf.Max(vectors.Select(vec => vec.x).Prepend(v.x).ToArray()),
                Mathf.Max(vectors.Select(vec => vec.y).Prepend(v.y).ToArray()),
                Mathf.Max(vectors.Select(vec => vec.z).Prepend(v.z).ToArray())
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3Int Max(this Vector3Int v, params int[] values) {
            return new Vector3Int(
                Mathf.Max(values.Select(value => value).Prepend(v.x).ToArray()),
                Mathf.Max(values.Select(value => value).Prepend(v.y).ToArray()),
                Mathf.Max(values.Select(value => value).Prepend(v.z).ToArray())
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3Int Min(this Vector3Int v, params Vector3Int[] vectors) {
            return new Vector3Int(
                Mathf.Min(vectors.Select(vec => vec.x).Prepend(v.x).ToArray()),
                Mathf.Min(vectors.Select(vec => vec.y).Prepend(v.y).ToArray()),
                Mathf.Min(vectors.Select(vec => vec.z).Prepend(v.z).ToArray())
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3Int Min(this Vector3Int v, params int[] values) {
            return new Vector3Int(
                Mathf.Min(values.Select(value => value).Prepend(v.x).ToArray()),
                Mathf.Min(values.Select(value => value).Prepend(v.y).ToArray()),
                Mathf.Min(values.Select(value => value).Prepend(v.z).ToArray())
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 MoveTowards(this Vector3Int v, Vector3 target, float maxDelta) {
            return new Vector3(
                Mathf.MoveTowards(v.x, target.x, maxDelta),
                Mathf.MoveTowards(v.y, target.y, maxDelta),
                Mathf.MoveTowards(v.z, target.z, maxDelta)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 MoveTowards(this Vector3Int v, float target, float maxDelta) {
            return new Vector3(
                Mathf.MoveTowards(v.x, target, maxDelta),
                Mathf.MoveTowards(v.y, target, maxDelta),
                Mathf.MoveTowards(v.z, target, maxDelta)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3Int NextPowerOfTwo(this Vector3Int v) {
            return new Vector3Int(
                Mathf.NextPowerOfTwo(v.x),
                Mathf.NextPowerOfTwo(v.y),
                Mathf.NextPowerOfTwo(v.z)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float PerlinNoise(this Vector3Int v) {
            return Mathf.PerlinNoise(v.x, v.y);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 PingPong(this Vector3Int v, Vector3 time) {
            return new Vector3(
                Mathf.PingPong(time.x, v.x),
                Mathf.PingPong(time.y, v.y),
                Mathf.PingPong(time.z, v.z)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 PingPong(this Vector3Int v, float time) {
            return new Vector3(
                Mathf.PingPong(time, v.x),
                Mathf.PingPong(time, v.y),
                Mathf.PingPong(time, v.z)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Pow(this Vector3Int v, Vector3 pow) {
            return new Vector3(
                Mathf.Pow(v.x, pow.x),
                Mathf.Pow(v.y, pow.y),
                Mathf.Pow(v.z, pow.z)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Pow(this Vector3Int v, float pow) {
            return new Vector3(
                Mathf.Pow(v.x, pow),
                Mathf.Pow(v.y, pow),
                Mathf.Pow(v.z, pow)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Repeat(this Vector3Int v, Vector3 time) {
            return new Vector3(
                Mathf.Repeat(time.x, v.x),
                Mathf.Repeat(time.y, v.y),
                Mathf.Repeat(time.z, v.z)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Repeat(this Vector3Int v, float time) {
            return new Vector3(
                Mathf.Repeat(time, v.x),
                Mathf.Repeat(time, v.y),
                Mathf.Repeat(time, v.z)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Round(this Vector3Int v) {
            return new Vector3(
                Mathf.Round(v.x),
                Mathf.Round(v.y),
                Mathf.Round(v.z)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3Int RoundToInt(this Vector3Int v) {
            return new Vector3Int(
                Mathf.RoundToInt(v.x),
                Mathf.RoundToInt(v.y),
                Mathf.RoundToInt(v.z)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3Int Sign(this Vector3Int v) {
            return new Vector3Int(
                v.x.Sign(),
                v.y.Sign(),
                v.z.Sign()
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 SmoothDamp(this Vector3Int v, Vector3 target, Vector3 time) {
            return new Vector3(
                Mathf.SmoothStep(v.x, target.x, time.x),
                Mathf.SmoothStep(v.y, target.y, time.y),
                Mathf.SmoothStep(v.z, target.z, time.z)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 SmoothDamp(this Vector3Int v, Vector3 target, float time) {
            return new Vector3(
                Mathf.SmoothStep(v.x, target.x, time),
                Mathf.SmoothStep(v.y, target.y, time),
                Mathf.SmoothStep(v.z, target.z, time)
            );
        }


        //Convert
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 ToVector3(this Vector3Int v) {
            return new Vector3(v.x, v.y, v.z);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 ToVector2(this Vector3Int v) {
            return new Vector2(v.x, v.y);
        }


        //Mathematics
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3Int Remainder(this Vector3Int dividend, Vector3Int divider) {
            return new Vector3Int(
                dividend.x % divider.x,
                dividend.y % divider.y,
                dividend.z % divider.z
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3Int Divide(this Vector3Int dividend, Vector3Int divider) {
            return new Vector3Int(
                dividend.x / divider.x,
                dividend.y / divider.y,
                dividend.z / divider.z
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3Int Multiply(this Vector3Int first, Vector3Int second) {
            return new Vector3Int(
                first.x * second.x,
                first.y * second.y,
                first.z * second.z
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3Int Sub(this Vector3Int first, Vector3Int second) {
            return new Vector3Int(
                first.x - second.x,
                first.y - second.y,
                first.z - second.z
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3Int SubIf(this Vector3Int first, Vector3Int second, Func<int, int, bool> func) {
            return new Vector3Int(
                first.x - (func.Invoke(first.x, second.x) ? second.x : 0),
                first.y - (func.Invoke(first.y, second.y) ? second.y : 0),
                first.z - (func.Invoke(first.z, second.z) ? second.z : 0)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3Int Sum(this Vector3Int first, Vector3Int second) {
            return new Vector3Int(
                first.x + second.x,
                first.y + second.y,
                first.z + second.z
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3Int SumIf(this Vector3Int first, Vector3Int second, Func<int, int, bool> func) {
            return new Vector3Int(
                first.x + (func.Invoke(first.x, second.x) ? second.x : 0),
                first.y + (func.Invoke(first.y, second.y) ? second.y : 0),
                first.z + (func.Invoke(first.z, second.z) ? second.z : 0)
            );
        }
    }
}