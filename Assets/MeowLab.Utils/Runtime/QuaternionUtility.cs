using UnityEngine;

namespace MeowLab.Utils
{
    public static class QuaternionUtility
    {
        public static Quaternion SmoothDamp(Quaternion rot, Quaternion target, ref Quaternion deriv, float time) {
            if (Time.deltaTime < Mathf.Epsilon) return rot;

            var dot = Quaternion.Dot(rot, target);
            var multi = dot > 0f ? 1f : -1f;
            target.x *= multi;
            target.y *= multi;
            target.z *= multi;
            target.w *= multi;

            var result = new Vector4(
                Mathf.SmoothDamp(rot.x, target.x, ref deriv.x, time),
                Mathf.SmoothDamp(rot.y, target.y, ref deriv.y, time),
                Mathf.SmoothDamp(rot.z, target.z, ref deriv.z, time),
                Mathf.SmoothDamp(rot.w, target.w, ref deriv.w, time)
            ).normalized;


            var derivError = Vector4.Project(new Vector4(deriv.x, deriv.y, deriv.z, deriv.w), result);
            deriv.x -= derivError.x;
            deriv.y -= derivError.y;
            deriv.z -= derivError.z;
            deriv.w -= derivError.w;

            return new Quaternion(result.x, result.y, result.z, result.w);
        }


        public static Quaternion SmoothDamp(Quaternion rot, Quaternion target, ref Quaternion deriv, float time, float maxSpeed) {
            if (Time.deltaTime < Mathf.Epsilon) return rot;

            var dot = Quaternion.Dot(rot, target);
            var multi = dot > 0f ? 1f : -1f;
            target.x *= multi;
            target.y *= multi;
            target.z *= multi;
            target.w *= multi;

            var result = new Vector4(
                Mathf.SmoothDamp(rot.x, target.x, ref deriv.x, time, maxSpeed),
                Mathf.SmoothDamp(rot.y, target.y, ref deriv.y, time, maxSpeed),
                Mathf.SmoothDamp(rot.z, target.z, ref deriv.z, time, maxSpeed),
                Mathf.SmoothDamp(rot.w, target.w, ref deriv.w, time, maxSpeed)
            ).normalized;


            var derivError = Vector4.Project(new Vector4(deriv.x, deriv.y, deriv.z, deriv.w), result);
            deriv.x -= derivError.x;
            deriv.y -= derivError.y;
            deriv.z -= derivError.z;
            deriv.w -= derivError.w;

            return new Quaternion(result.x, result.y, result.z, result.w);
        }


        public static Quaternion SmoothDamp(Quaternion rot, Quaternion target, ref Quaternion deriv, float time, float maxSpeed, float deltaTime) {
            if (deltaTime < Mathf.Epsilon) return rot;

            var dot = Quaternion.Dot(rot, target);
            var multi = dot > 0f ? 1f : -1f;
            target.x *= multi;
            target.y *= multi;
            target.z *= multi;
            target.w *= multi;

            var result = new Vector4(
                Mathf.SmoothDamp(rot.x, target.x, ref deriv.x, time, maxSpeed, deltaTime),
                Mathf.SmoothDamp(rot.y, target.y, ref deriv.y, time, maxSpeed, deltaTime),
                Mathf.SmoothDamp(rot.z, target.z, ref deriv.z, time, maxSpeed, deltaTime),
                Mathf.SmoothDamp(rot.w, target.w, ref deriv.w, time, maxSpeed, deltaTime)
            ).normalized;


            var derivError = Vector4.Project(new Vector4(deriv.x, deriv.y, deriv.z, deriv.w), result);
            deriv.x -= derivError.x;
            deriv.y -= derivError.y;
            deriv.z -= derivError.z;
            deriv.w -= derivError.w;

            return new Quaternion(result.x, result.y, result.z, result.w);
        }


        public static Quaternion LookAtByAxis(Vector3 tPosition, Vector3 point, Vector3 axis) {
            var distanceToPlane = Vector3.Dot(axis, point - tPosition);
            var pointOnPlane = point - axis * distanceToPlane;
            var lookDirection = (pointOnPlane - tPosition).normalized;
            return Quaternion.LookRotation(lookDirection);
        }


        public static Quaternion LookAtByLocalAxis(Transform transform, Vector3 point, Vector3 localAxis) {
            // var localAxis = transform.InverseTransformDirection(axis);
            var localPoint = transform.InverseTransformPoint(point);
            var distanceToPlane = Vector3.Dot(localAxis, localPoint - transform.localPosition);
            var pointOnPlane = localPoint - localAxis * distanceToPlane;
            var lookDirection = (pointOnPlane - transform.localPosition).normalized;
            return Quaternion.LookRotation(lookDirection);
        }
    }
}