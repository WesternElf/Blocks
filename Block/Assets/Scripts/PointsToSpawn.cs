using InputTouchLogic;
using Interfaces;
using UnityEngine;

namespace BlocksLogic
{
    public class PointsToSpawn : MonoBehaviour,  IInitiable<ScreenSize>
    {
        [SerializeField] 
        private int spawnPointsCount;
        [SerializeField] 
        private GameObject prefab;
        private ScreenSize screenSize;
        private int paddingVale = 20;
        private int marginValue = 40;

        public void Init(ScreenSize screenSize)
        {
            this.screenSize = screenSize;
            GetPointsToSpawnTransforms();
        }

        private void GetPointsToSpawnTransforms()
        {
            var fullScreenSize = screenSize.ScreenBorders.x *2;
            
            var padding = fullScreenSize / paddingVale;
            var margin = fullScreenSize / marginValue;

            var blockSize = (fullScreenSize - padding * 2 - (spawnPointsCount - 1) * margin) / spawnPointsCount;

            for (int i = 0; i < spawnPointsCount; i++)
            {
                var newPointPosition = new Vector2(
                    Camera.main.transform.position.x - screenSize.ScreenBorders.x 
                    + blockSize / 2 
                    + i * blockSize
                    + padding
                    + margin * i,
                    screenSize.ScreenBorders.y - 0.75f
                );
                Debug.Log(newPointPosition.x);
                var newBlock = Instantiate(prefab, newPointPosition, Quaternion.identity);
                var blockScale = newBlock.transform.localScale;
                blockScale.x = blockSize;
                newBlock.transform.localScale = blockScale;

                newBlock.GetComponent<BlockBehaviour>().Init(screenSize);
            }
        }
        
    }
}