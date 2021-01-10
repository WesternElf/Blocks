using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameLogic
{
    public class GameOverManager : MonoBehaviour
    {
        public event Action OnRestartGame;
        [SerializeField] private Canvas gameOverPanel;
        [SerializeField] private Button restartGameButton;

        public void Init()
        {
            restartGameButton.onClick.AddListener(RestartGame);
        }

        public void GameOver()
        {
            Time.timeScale = 0;
            gameOverPanel.enabled = true;
        }

        private void RestartGame()
        {
            Time.timeScale = 1;
            gameOverPanel.enabled = false;
            OnRestartGame?.Invoke();
        }
    }
}