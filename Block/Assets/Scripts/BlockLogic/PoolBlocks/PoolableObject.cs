using UnityEngine;

namespace BlocksLogic.Pool
{
    public class PoolableObject : MonoBehaviour
    {
        private ObjectPooler pool;

        public void SetPool(ObjectPooler pool)
        {
            this.pool = pool;
        }

        public void ReturnToPool()
        {
            pool.ReturnObject(gameObject);
        }
    }
}
