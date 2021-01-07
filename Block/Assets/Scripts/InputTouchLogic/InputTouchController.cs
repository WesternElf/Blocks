using System;
using Interfaces;
using UnityEngine;

namespace InputTouchLogic
{
    public class InputTouchController : MonoBehaviour, IClickable, IInitiable<ScreenSize>
    {
        private ScreenSize screenSize;
        private int screenScaleFactor;
        
        public event Action<int> OnPressed;
        public event Action OnReleased;
        public event Action OnHold;

        public int ScreenScaleFactor => screenScaleFactor;

        public void Init(ScreenSize screenSize)
        {
            this.screenSize = screenSize;
            
            screenSize.StageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,0));
            Debug.Log(screenSize.StageDimensions.x);
        }

        private void FixedUpdate()
        {
            if (Input.touchCount<=0)
                return;
            
            var touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                screenScaleFactor = touch.position.x >= screenSize.ScreenCenter ? 1 : -1;
                OnPressed?.Invoke(screenScaleFactor);
                Debug.Log(touch.position.x < screenSize.ScreenCenter ? "Left" : "Right");
            }


            if (Input.GetMouseButton(0))
            {
                screenScaleFactor = Input.mousePosition.x >= screenSize.ScreenCenter ? 1 : -1;
                OnPressed?.Invoke(screenScaleFactor);
            }
        }
    }
}