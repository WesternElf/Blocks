using BlocksLogic.Pool;
using InputTouchLogic;
using Interfaces;
using UnityEngine;

namespace BlocksLogic
{
    public class BlockBehaviour : MonoBehaviour, IDestructable
    {
        [SerializeField] private GameObject frut;
        [SerializeField] private KillZone _killZone;
        [SerializeField] private KillZone _destroyZone;
        [SerializeField] private float boxMovementSpeed = 2f;
        private ScreenSize screenSize;
        private float downBorder;

        public void Init(ScreenSize screenSize)
        {
            _killZone.OnBall += () =>
            {
              //  Debug.Log("Killed");
            };
            
            _destroyZone.OnBall += AddParticle;
            this.screenSize = screenSize;
        }

        private void AddParticle()
        {
            _destroyZone.OnBall -= AddParticle;
            Instantiate(frut, transform.position, Quaternion.identity).GetComponent<Particle>().SetColor(
                GetComponent<SpriteRenderer>().color);
            gameObject.GetComponent<PoolableObject>().ReturnToPool();
        }

        private void Update()
        {
            var verticalPos = transform.position;
            if (verticalPos.y<=-screenSize.ScreenBorders.y-transform.localScale.y/2)
                gameObject.GetComponent<PoolableObject>().ReturnToPool();
            transform.position += Vector3.down * (boxMovementSpeed * Time.deltaTime);
        }
    }
}