using System;
using System.Collections;
using GameLogic;
using InputTouchLogic;
using Interfaces;
using Particles;
using UnityEngine;
using Random = UnityEngine.Random;

namespace BlocksLogic.Pool
{
    public class BlockSpawner : MonoBehaviour, IInitiable<ScreenSize, ParticleSpawner>
    {
        [SerializeField] 
        private DifficultyGrowingManager difficultyGrowingManager;
        [SerializeField] 
        private BlockParams blockParams;
        private PointsToSpawn pointsToSpawn;
        private ScreenSize screenSize;
        private Transform randomPoint;
        private ObjectPooler pool;
        private ParticleSpawner particleSpawner;
        private GameParams gameParams;
        
        public event Action OnGameOver;

        public void Init(ScreenSize screenSize, ParticleSpawner particleSpawner)
        {
            this.screenSize = screenSize;
            this.particleSpawner = particleSpawner;
          
            InitGameParams();
            
            pointsToSpawn = new PointsToSpawn(screenSize);
            pool = new ObjectPooler(blockParams.blockPrefab, blockParams.blocksCount);

            StartCoroutine(BlocksSpawner());
        }

        private void Update()
        {
            difficultyGrowingManager.Timer();
        }

        private IEnumerator BlocksSpawner()
        {
            while (true)
            {
                SpawnBlock(pool);
                yield return new WaitForSeconds(
                    gameParams.spawnDelay
                );
            }

        }
        
        public void InitGameParams()
        {
            gameParams = new GameParams {blockSpeed = 2f, spawnDelay = 2f};
            difficultyGrowingManager.Init(gameParams);
        }

        private void SpawnBlock(ObjectPooler objectPooler)
        {
            var pooledObject = objectPooler.GetObject();
            var randomPoint = pointsToSpawn.GetPointsToSpawnTransforms(blockParams.blocksCount);

            pooledObject.transform.position = randomPoint;

            var block = pooledObject.GetComponent<BlockBehaviour>();
            block.Init(screenSize, particleSpawner, gameParams);
            block.OnBlockKilledPlayer += () => OnGameOver?.Invoke();
            SetRandomColor(pooledObject);
            pooledObject.SetActive(true);
        }

        private void SetRandomColor(GameObject blockObject)
        {
            var color = blockObject.GetComponent<SpriteRenderer>().color;
            color = blockParams.blockColors[Random.Range(0, blockParams.blockColors.Length-1)];
            color.a = 1;
            blockObject.GetComponent<SpriteRenderer>().color = color;
        }

        public void ClearPool()
        {
            var blocks = FindObjectsOfType<PoolableObject>();

            foreach (var block in blocks)
            {
                if (block.gameObject.activeInHierarchy)
                {
                    block.ReturnToPool();
                }
            }
        }
    }

    [Serializable]
    public class BlockParams
    {
        public Color[] blockColors;
        public GameObject blockPrefab;
        public int blocksCount;
    }
}