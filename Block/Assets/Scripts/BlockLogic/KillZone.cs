using System;
using UnityEngine;

namespace BlocksLogic
{
    public class KillZone : MonoBehaviour
    {
        public event Action OnBall;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if(other.transform.GetComponent<BallBehaviour>()!=null)
                OnBall?.Invoke();
        }
    }
}