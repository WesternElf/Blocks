using InputTouchLogic;
using Interfaces;
using UnityEngine;

namespace BlocksLogic
{
    public class PointsToSpawn
    {
        private ScreenSize screenSize;
        private int paddingVale = 20;
        private int marginValue = 40;

        public PointsToSpawn(ScreenSize screenSize)
        {
            this.screenSize = screenSize;
            //GetPointsToSpawnTransforms();
        }

        public Vector2 GetPointsToSpawnTransforms(int blockCount)
        {
            var fullScreenSize = screenSize.ScreenBorders.x *2;
            
            var padding = fullScreenSize / paddingVale;
            var margin = fullScreenSize / marginValue;

            var blockNum = Random.Range(0, blockCount);

            var blockSize = (fullScreenSize - padding * 2 - (blockCount - 1) * margin) / blockCount;
            
                var newPointPosition = new Vector2(
                    Camera.main.transform.position.x - screenSize.ScreenBorders.x 
                    + blockSize / 2 
                    + blockNum * blockSize
                    + padding
                    + margin * blockNum,
                    screenSize.ScreenBorders.y + 0.75f
                );
//                Debug.Log(newPointPosition.x);
                //var newBlock = Instantiate(prefab, newPointPosition, Quaternion.identity);
                // var blockScale = newBlock.transform.localScale;
                // blockScale.x = blockSize;
                // newBlock.transform.localScale = blockScale;
                //
                // newBlock.GetComponent<BlockBehaviour>().Init(screenSize);

                return newPointPosition;
        }
        
    }
}