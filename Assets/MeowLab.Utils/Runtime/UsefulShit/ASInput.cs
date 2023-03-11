using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace MeowLab.Utils
{
    public static class ASInput
    {
      public static Camera Cam {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => MainCameraContainer.I.Cam;
        }

        public static bool IsPointerOverUIObject = false;

        public static Vector2 ScreenPosition {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => Input.mousePosition;
        }

        public static Vector2 ViewPortPosition {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => Cam.ScreenToViewportPoint(ScreenPosition);
        }

        public static Vector2 PrettyViewPortPosition {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => Cam.ScreenToViewportPoint(ScreenPosition) * new Vector2(1f, (float)Screen.height / Screen.width);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsTouchDown(bool overUI = true) {
            return Input.GetMouseButtonDown(0) && (!IsPointerOverUIObject || overUI);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TouchDown(out Vector2 position, bool overUI = true) {
            position = ScreenPosition;
            return Input.GetMouseButtonDown(0) && (!IsPointerOverUIObject || overUI);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TouchDown(ref bool result, ref Vector2 position, bool overUI = true) {
            if (Input.GetMouseButtonDown(0) && (!IsPointerOverUIObject || overUI)) {
                position = ScreenPosition;
                return true;
            }

            return false;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TouchDownViewPort(out Vector2 position, bool overUI = true) {
            position = Cam.ScreenToViewportPoint(ScreenPosition);
            return Input.GetMouseButtonDown(0) && (!IsPointerOverUIObject || overUI);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsTouchUp(bool overUI = true) {
            return Input.GetMouseButtonUp(0) && (!IsPointerOverUIObject || overUI);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TouchUp(out Vector2 position, bool overUI = true) {
            position = ScreenPosition;
            return Input.GetMouseButtonUp(0) && (!IsPointerOverUIObject || overUI);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TouchUp(ref bool result, ref Vector2 position, bool overUI = true) {
            if (Input.GetMouseButtonUp(0) && (!IsPointerOverUIObject || overUI)) {
                position = ScreenPosition;
                return true;
            }

            return false;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TouchUpViewPort(out Vector2 position, bool overUI = true) {
            position = Cam.ScreenToViewportPoint(ScreenPosition);
            return Input.GetMouseButtonUp(0) && (!IsPointerOverUIObject || overUI);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsTouch(bool overUI = true) {
            return Input.GetMouseButton(0) && (!IsPointerOverUIObject || overUI);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Touch(out Vector2 position, bool overUI = true) {
            position = ScreenPosition;
            return Input.GetMouseButton(0) && (!IsPointerOverUIObject || overUI);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Touch(ref bool result, ref Vector2 position, bool overUI = true) {
            if (Input.GetMouseButton(0) && (!IsPointerOverUIObject || overUI)) {
                position = ScreenPosition;
                return true;
            }

            return false;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TouchViewPort(out Vector2 position, bool overUI = true) {
            position = Cam.ScreenToViewportPoint(ScreenPosition);
            return Input.GetMouseButton(0) && (!IsPointerOverUIObject || overUI);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async UniTask<Vector2> TouchDownAsync(bool overUI = true) {
            Vector2 position = default;
            await UniTask.WaitUntil(() => TouchDown(out position, overUI));
            return position;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async UniTask<Vector2> TouchUpAsync(bool overUI = true) {
            Vector2 position = default;
            await UniTask.WaitUntil(() => TouchUp(out position, overUI));
            return position;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async UniTask<Vector2> TouchAsync(Func<Vector2, bool> func, bool overUI = true) {
            Vector2 position = default;
            while (Touch(out position, overUI) && func.Invoke(position)) {
                await UniTask.Yield();
            }

            return position;
        }
    }
}