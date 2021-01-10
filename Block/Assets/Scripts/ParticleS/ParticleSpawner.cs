using BlocksLogic;
using BlocksLogic.Pool;
using UnityEngine;

namespace Particles
{
    public class ParticleSpawner : MonoBehaviour
    {
        [SerializeField] 
        private GameObject particlePrefab;
        [SerializeField] 
        private int initialAmount;
        private ObjectPooler pool;

        public void Init()
        {
            pool = new ObjectPooler(particlePrefab, initialAmount);
        }

        public void SpawnObject(BlockBehaviour block)
        {
            var newParticle = pool.GetObject();
            newParticle.transform.position = block.transform.position;
        
            newParticle.GetComponent<Particle>().SetColor(block);
        
            newParticle.SetActive(true);
        }
    }
}
