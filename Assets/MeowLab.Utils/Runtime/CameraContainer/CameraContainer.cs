using System.Runtime.CompilerServices;
using UnityEngine;

namespace MeowLab.Utils
{
    public abstract class CameraContainer<T> : SingleScript<T> where T : SingleScript<T>
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private DepthTextureMode _depthTextureMode = DepthTextureMode.None;

        public Camera Cam {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _camera;
        }


        public override void Awake() {
            base.Awake();
            _camera.depthTextureMode = _depthTextureMode;
        }


#if UNITY_EDITOR
        private void Reset() {
            _camera = GetComponent<Camera>();
        }
#endif
    }
}