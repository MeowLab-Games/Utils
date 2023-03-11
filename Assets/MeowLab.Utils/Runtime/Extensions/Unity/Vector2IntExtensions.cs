using System;
using System.Linq;
using System.Runtime.CompilerServices;
using MeowLab.Utils;
using UnityEngine;

namespace MeowLab.Utils
{
    public static class Vector2IntExtensions
    {
        //Utils
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2Int WithX(this Vector2Int vec, int x) {
            return new Vector2Int(x, vec.y);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2Int WithY(this Vector2Int vec, int y) {
            return new Vector2Int(vec.x, y);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2Int AddX(this Vector2Int vec, int x) {
            return new Vector2Int(vec.x + x, vec.y);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2Int AddY(this Vector2Int vec, int y) {
            return new Vector2Int(vec.x, vec.y + y);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2Int InvertX(this Vector2Int vec) {
            return new Vector2Int(-vec.x, vec.y);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2Int InvertY(this Vector2Int vec) {
            return new Vector2Int(vec.x, -vec.y);
        }


        public static Vector2Int Invert(this Vector2Int vec) {
            return new Vector2Int(-vec.x, -vec.y);
        }


        //Mathf
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2Int Abs(this Vector2Int v) {
            return new Vector2Int(
                Mathf.Abs(v.x),
                Mathf.Abs(v.y)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Approximately(this Vector2Int v, Vector2Int v2) {
            return Mathf.Approximately(v.x, v2.x)
                   && Mathf.Approximately(v.y, v2.y);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 Ceil(this Vector2Int v) {
            return new Vector2(
                Mathf.Ceil(v.x),
                Mathf.Ceil(v.y)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2Int CeilToInt(this Vector2Int v) {
            return new Vector2Int(
                Mathf.CeilToInt(v.x),
                Mathf.CeilToInt(v.y)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 Clamp(this Vector2Int v, Vector2 min, Vector2 max) {
            return new Vector2(
                Mathf.Clamp(v.x, min.x, max.x),
                Mathf.Clamp(v.y, min.y, max.y)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 Clamp(this Vector2Int v, float min, float max) {
            return new Vector2(
                Mathf.Clamp(v.x, min, max),
                Mathf.Clamp(v.y, min, max)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 Clamp01(this Vector2Int v) {
            return new Vector2(
                Mathf.Clamp01(v.x),
                Mathf.Clamp01(v.y)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2Int Clamp01Int(this Vector2Int v) {
            return new Vector2Int(
                (int)Mathf.Clamp01(v.x),
                (int)Mathf.Clamp01(v.y)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2Int ClosestPowerOfTwo(this Vector2Int v) {
            return new Vector2Int(
                Mathf.ClosestPowerOfTwo(v.x),
                Mathf.ClosestPowerOfTwo(v.y)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 Floor(this Vector2Int v) {
            return new Vector2(
                Mathf.Floor(v.x),
                Mathf.Floor(v.y)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2Int FloorToInt(this Vector2Int v) {
            return new Vector2Int(
                Mathf.FloorToInt(v.x),
                Mathf.FloorToInt(v.y)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 InverseLerp(this Vector2Int v, Vector2 a, Vector2 b) {
            return new Vector2(
                Mathf.InverseLerp(a.x, b.x, v.x),
                Mathf.InverseLerp(a.y, b.y, v.y)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 InverseLerp(this Vector2Int v, float a, float b) {
            return new Vector2(
                Mathf.InverseLerp(a, b, v.x),
                Mathf.InverseLerp(a, b, v.y)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsPowerOfTwo(this Vector2Int v) {
            return Mathf.IsPowerOfTwo(v.x)
                   && Mathf.IsPowerOfTwo(v.y);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 Lerp(this Vector2Int v, Vector2 a, Vector2 b) {
            return new Vector2(
                Mathf.Lerp(a.x, b.x, v.x),
                Mathf.Lerp(a.y, b.y, v.y)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 Lerp(this Vector2Int v, float a, float b) {
            return new Vector2(
                Mathf.Lerp(a, b, v.x),
                Mathf.Lerp(a, b, v.y)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 LerpUnclamped(this Vector2Int v, Vector2 a, Vector2 b) {
            return new Vector2(
                Mathf.LerpUnclamped(a.x, b.x, v.x),
                Mathf.LerpUnclamped(a.y, b.y, v.y)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 LerpUnclamped(this Vector2Int v, float a, float b) {
            return new Vector2(
                Mathf.LerpUnclamped(a, b, v.x),
                Mathf.LerpUnclamped(a, b, v.y)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 Log(this Vector2Int v) {
            return new Vector2(
                Mathf.Log(v.x),
                Mathf.Log(v.y)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 Log(this Vector2Int v, Vector2 p) {
            return new Vector2(
                Mathf.Log(v.x, p.x),
                Mathf.Log(v.y, p.y)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 Log(this Vector2Int v, float p) {
            return new Vector2(
                Mathf.Log(v.x, p),
                Mathf.Log(v.y, p)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 Log10(this Vector2Int v) {
            return new Vector2(
                Mathf.Log10(v.x),
                Mathf.Log10(v.y)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2Int Max(this Vector2Int v, params Vector2Int[] vectors) {
            return new Vector2Int(
                Mathf.Max(vectors.Select(vec => vec.x).Prepend(v.x).ToArray()),
                Mathf.Max(vectors.Select(vec => vec.y).Prepend(v.y).ToArray())
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2Int Max(this Vector2Int v, params int[] values) {
            return new Vector2Int(
                Mathf.Max(values.Select(value => value).Prepend(v.x).ToArray()),
                Mathf.Max(values.Select(value => value).Prepend(v.y).ToArray())
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2Int Min(this Vector2Int v, params Vector2Int[] vectors) {
            return new Vector2Int(
                Mathf.Min(vectors.Select(vec => vec.x).Prepend(v.x).ToArray()),
                Mathf.Min(vectors.Select(vec => vec.y).Prepend(v.y).ToArray())
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2Int Min(this Vector2Int v, params int[] values) {
            return new Vector2Int(
                Mathf.Min(values.Select(value => value).Prepend(v.x).ToArray()),
                Mathf.Min(values.Select(value => value).Prepend(v.y).ToArray())
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 MoveTowards(this Vector2Int v, Vector2 target, float maxDelta) {
            return new Vector2(
                Mathf.MoveTowards(v.x, target.x, maxDelta),
                Mathf.MoveTowards(v.y, target.y, maxDelta)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 MoveTowards(this Vector2Int v, float target, float maxDelta) {
            return new Vector2(
                Mathf.MoveTowards(v.x, target, maxDelta),
                Mathf.MoveTowards(v.y, target, maxDelta)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2Int NextPowerOfTwo(this Vector2Int v) {
            return new Vector2Int(
                Mathf.NextPowerOfTwo(v.x),
                Mathf.NextPowerOfTwo(v.y)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float PerlinNoise(this Vector2Int v) {
            return Mathf.PerlinNoise(v.x, v.y);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 PingPong(this Vector2Int v, Vector2 time) {
            return new Vector2(
                Mathf.PingPong(time.x, v.x),
                Mathf.PingPong(time.y, v.y)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 PingPong(this Vector2Int v, float time) {
            return new Vector2(
                Mathf.PingPong(time, v.x),
                Mathf.PingPong(time, v.y)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 Pow(this Vector2Int v, Vector2 pow) {
            return new Vector2(
                Mathf.Pow(v.x, pow.x),
                Mathf.Pow(v.y, pow.y)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 Pow(this Vector2Int v, float pow) {
            return new Vector2(
                Mathf.Pow(v.x, pow),
                Mathf.Pow(v.y, pow)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 Repeat(this Vector2Int v, Vector2 time) {
            return new Vector2(
                Mathf.Repeat(time.x, v.x),
                Mathf.Repeat(time.y, v.y)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 Repeat(this Vector2Int v, float time) {
            return new Vector2(
                Mathf.Repeat(time, v.x),
                Mathf.Repeat(time, v.y)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 Round(this Vector2Int v) {
            return new Vector2(
                Mathf.Round(v.x),
                Mathf.Round(v.y)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2Int RoundToInt(this Vector2Int v) {
            return new Vector2Int(
                Mathf.RoundToInt(v.x),
                Mathf.RoundToInt(v.y)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2Int Sign(this Vector2Int v) {
            return new Vector2Int(
                v.x.Sign(),
                v.y.Sign()
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 SmoothDamp(this Vector2Int v, Vector2 target, Vector2 time) {
            return new Vector2(
                Mathf.SmoothStep(v.x, target.x, time.x),
                Mathf.SmoothStep(v.y, target.y, time.y)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 SmoothDamp(this Vector2Int v, Vector2 target, float time) {
            return new Vector2(
                Mathf.SmoothStep(v.x, target.x, time),
                Mathf.SmoothStep(v.y, target.y, time)
            );
        }


        //Convert
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 ToVector3(this Vector2Int v) {
            return new Vector3(v.x, v.y);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 ToVector2(this Vector2Int v) {
            return new Vector2(v.x, v.y);
        }


        //Mathematics
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2Int Remainder(this Vector2Int dividend, Vector2Int divider) {
            return new Vector2Int(
                dividend.x % divider.x,
                dividend.y % divider.y
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2Int Divide(this Vector2Int dividend, Vector2Int divider) {
            return new Vector2Int(
                dividend.x / divider.x,
                dividend.y / divider.y
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2Int Multiply(this Vector2Int first, Vector2Int second) {
            return new Vector2Int(
                first.x * second.x,
                first.y * second.y
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2Int Sub(this Vector2Int first, Vector2Int second) {
            return new Vector2Int(
                first.x - second.x,
                first.y - second.y
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2Int SubIf(this Vector2Int first, Vector2Int second, Func<int, int, bool> func) {
            return new Vector2Int(
                first.x - (func.Invoke(first.x, second.x) ? second.x : 0),
                first.y - (func.Invoke(first.y, second.y) ? second.y : 0)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2Int Sum(this Vector2Int first, Vector2Int second) {
            return new Vector2Int(
                first.x + second.x,
                first.y + second.y
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2Int SumIf(this Vector2Int first, Vector2Int second, Func<int, int, bool> func) {
            return new Vector2Int(
                first.x + (func.Invoke(first.x, second.x) ? second.x : 0),
                first.y + (func.Invoke(first.y, second.y) ? second.y : 0)
            );
        }
    }
}