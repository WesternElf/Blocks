using System.Collections;
using InputTouchLogic;
using Interfaces;
using UnityEngine;

namespace BlocksLogic.Pool
{
    public class BlockSpawner : MonoBehaviour, IInitiable<ScreenSize>
    {
        [SerializeField] 
        private Color[] colors;
        [SerializeField] 
        private GameObject blockPrefab;
        [SerializeField] 
        private int blocksCount;
        [SerializeField]
        private float spawnDelay;
        private PointsToSpawn pointsToSpawn;
        private ScreenSize screenSize;
        private Transform randomPoint;
        private BlockPooler pool;

        public void Init(ScreenSize screenSize)
        {
            this.screenSize = screenSize;
            
            pointsToSpawn = new PointsToSpawn(screenSize);
            pool = new BlockPooler(blockPrefab, blocksCount);

            StartCoroutine(BlocksSpawner());
        }

        private IEnumerator BlocksSpawner()
        {
            while (true)
            {
                SpawnBlock(pool);
                yield return new WaitForSeconds(
                    spawnDelay
                       //0.5f + Mathf.Abs(Mathf.Sin(Time.time))
                       // 0.5f + Mathf.PerlinNoise(Time.time, 0.0f)
                    );
            }

        }

        private void SpawnBlock(BlockPooler blockPooler)
        {
            var pooledObject = blockPooler.GetObject();
            var randomPoint = pointsToSpawn.GetPointsToSpawnTransforms(blocksCount);

            pooledObject.transform.position = randomPoint;
            
            pooledObject.GetComponent<BlockBehaviour>().Init(screenSize);

            SetRandomColor(pooledObject);
            pooledObject.SetActive(true);
        }

        private void SetRandomColor(GameObject blockObject)
        {
            var color = blockObject.GetComponent<SpriteRenderer>().color;
            color = colors[Random.Range(0, colors.Length-1)];
            color.a = 1;
            blockObject.GetComponent<SpriteRenderer>().color = color;
        }
       
        public void ClearPool()
        {
            PoolableObject[] blocks = FindObjectsOfType<PoolableObject>();

            foreach (var block in blocks)
            {
                if (block.gameObject.activeInHierarchy)
                {
                    block.ReturnToPool();
                }
            }
        }
    }
}