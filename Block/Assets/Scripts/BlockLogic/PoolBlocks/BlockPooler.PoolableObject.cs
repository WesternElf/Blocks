using UnityEngine;

namespace BlocksLogic.Pool
{
    public class PoolableObject : MonoBehaviour
    {
        private BlockPooler pool;

        public void SetPool(BlockPooler pool)
        {
            this.pool = pool;
        }

        public void ReturnToPool()
        {
            pool.ReturnObject(gameObject);
        }
    }
}
