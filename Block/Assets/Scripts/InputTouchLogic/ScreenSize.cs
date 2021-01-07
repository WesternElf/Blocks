using UnityEngine;

namespace  InputTouchLogic
{
    public class ScreenSize
    {
        public float ScreenCenter { get; set; }
        public Vector3 StageDimensions { get; set; }

        public ScreenSize(float screenCenter)
        {
            ScreenCenter = screenCenter;
        }
    }
}

