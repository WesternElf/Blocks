using System.Security.Cryptography;
using InputTouchLogic;
using Interfaces;
using UnityEngine;

namespace BlocksLogic
{
    public class BlockBehaviour : MonoBehaviour, IDestructable
    {
        [SerializeField] private float boxMovementSpeed = 2f;
        private ScreenSize screenSize;
        private float downBorder;

        public void Init(ScreenSize screenSize)
        {
            this.screenSize = screenSize;
            Debug.Log(screenSize.ScreenBorders.y);
        }
        private void Update()
        {
            var verticalPos = transform.position;
            if (verticalPos.y<=-screenSize.ScreenBorders.y+transform.localScale.y/2)
                Destroy(gameObject);
            transform.position += Vector3.down * (boxMovementSpeed * Time.deltaTime);
        }
    }
}