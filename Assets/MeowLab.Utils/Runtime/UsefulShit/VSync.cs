using UnityEngine;

namespace MeowLab.SDK
{
    public static class VSync
    {
//Use ONLY when your game can maintain 60 fps. If not, use SetVsync0_60FPS or SetVsync0_120FPS, because your game will drop less frames then.
        public static void SetVsync1() {
            QualitySettings.vSyncCount = 1;
            Application.targetFrameRate = -1;
        }


//Use if you barely get 40 fps. It feels definitely better to have 30 consistent evenly spaced frames than 40 frames with varying delays between them.
        public static void SetVsync2() {
            QualitySettings.vSyncCount = 2;
            Application.targetFrameRate = -1;
        }


//Does whatever the platform does
        public static void SetVsync0_Default() {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = -1;
        }


//Try this if you don't reach 60fps, it will look better than SetVsync1
        public static void SetVsync0_60FPS() {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 60;
        }


//Try this if you don't reach 60fps, it might look even better than SetVsync0_60FPS. It looks like less frames are dropped, i have no explanation, just try it yourself.
        public static void SetVsync0_120FPS() {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 120;
        }
    }
}