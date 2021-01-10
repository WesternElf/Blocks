using System;
using BlocksLogic.Pool;
using GameLogic;
using InputTouchLogic;
using Particles;
using UnityEngine;

namespace BlocksLogic
{
    public class BlockBehaviour : MonoBehaviour
    {
        [SerializeField] private KillZone killZone;
        [SerializeField] private DestroyZone destroyZone;
        private ScreenSize screenSize;
        private ParticleSpawner particleSpawner;
        private GameParams gameParams;
        private float downBorder;

        public event Action OnBlockKilledPlayer;

        public void Init(ScreenSize screenSize, ParticleSpawner particleSpawner, GameParams gameParams)
        {
            killZone.OnBallKilled += () =>
            {
                OnBlockKilledPlayer?.Invoke();
            };
            
            destroyZone.OnBlockDestroyed += AddParticle;
            this.screenSize = screenSize;
            this.particleSpawner = particleSpawner;
            this.gameParams = gameParams;
        }

        private void AddParticle()
        {
            particleSpawner.SpawnObject(this);
            gameObject.GetComponent<PoolableObject>().ReturnToPool();
        }

        private void Update()
        {
            var verticalPos = transform.position;
            if (verticalPos.y<=-screenSize.ScreenBorders.y-transform.localScale.y/2)
                gameObject.GetComponent<PoolableObject>().ReturnToPool();
            transform.position += Vector3.down * (gameParams.blockSpeed * Time.deltaTime);
        }
        
        private void OnDisable()
        {
            destroyZone.OnBlockDestroyed -= AddParticle;
        }
    }
}