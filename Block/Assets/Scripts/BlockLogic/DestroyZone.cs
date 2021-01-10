using System;
using BallLogic;
using UnityEngine;

namespace BlocksLogic
{
    public class DestroyZone : MonoBehaviour
    {
        public event Action OnBlockDestroyed;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.transform.GetComponent<BallBehaviour>() != null)
                OnBlockDestroyed?.Invoke();
        }
    }
}