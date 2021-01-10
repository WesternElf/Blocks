using System.Collections;
using BlocksLogic;
using BlocksLogic.Pool;
using UnityEngine;

namespace Particles
{
    public class Particle : MonoBehaviour
    {
        private ParticleSystem[] particleSystems;

        private void Awake()
        {
            particleSystems = GetComponentsInChildren<ParticleSystem>();
        }

        private void OnEnable()
        {
            foreach (var ps in particleSystems)
            {
                ps.Play();
            }

            StartCoroutine(DisableParticles());
        }

        private IEnumerator DisableParticles()
        {
            yield return new WaitForSeconds(1.5f);
            GetComponent<PoolableObject>().ReturnToPool();
        }

        public void SetColor(BlockBehaviour blockBehaviour)
        {
            foreach (var ps in particleSystems)
            {
                var main = ps.main;
                main.startColor = blockBehaviour.GetComponent<SpriteRenderer>().color;
            }
        }
    }
}

