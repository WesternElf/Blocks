using System;
using BallLogic;
using UnityEngine;

namespace BlocksLogic
{
    public class KillZone : MonoBehaviour
    {
        public event Action OnBallKilled;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if(other.transform.GetComponent<BallBehaviour>()!=null)
                OnBallKilled?.Invoke();
        }
    }
}