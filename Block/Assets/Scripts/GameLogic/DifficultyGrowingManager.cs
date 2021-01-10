using System;
using BlocksLogic.Pool;
using InputTouchLogic;
using Interfaces;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace GameLogic
{
    [Serializable]
    public class DifficultyGrowingManager
    {
        [SerializeField]
        private AnimationCurve blockSpeed;
        [SerializeField] 
        private float timeBeforeSpeedGrows;
        private GameParams gameParams;
        private float timer;
        private int currentLevel;

        public void Init(GameParams gameParams)
        {
            this.gameParams = gameParams;
            currentLevel = 0;
        }

        public void Timer()
        {
            if (currentLevel>=blockSpeed.length-1)
                return;
            timer += Time.deltaTime;

            if (timer<timeBeforeSpeedGrows)
                return;
            timer = 0;
            currentLevel = Mathf.Clamp(currentLevel, 0, blockSpeed.length - 1);
            currentLevel++;
            GrowingSpeed();
            GrowingBlocksSpawnDelay();
        }

        private void GrowingSpeed()
        {
            gameParams.blockSpeed += blockSpeed[currentLevel].value;
        }

        private void GrowingBlocksSpawnDelay()
        {
            gameParams.spawnDelay -= 0.15f;
        }

    }
}
