using BallLogic;
using BlocksLogic.Pool;
using GameLogic;
using InputTouchLogic;
using Particles;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] 
    private InputTouchController inputTouchController;
    [SerializeField]
    private BallBehaviour ballBehaviour;
    [SerializeField] 
    private BlockSpawner blockSpawner;
    [SerializeField] 
    private ParticleSpawner particleSpawner;
    [SerializeField] 
    private GameOverManager gameOverManager;
    
    private ScreenSize screenSize;

    private void Awake()
    {
        CreateServices();
        
        inputTouchController.Init(screenSize);
        particleSpawner.Init();
        ballBehaviour.Init(screenSize, inputTouchController);
        blockSpawner.Init(screenSize, particleSpawner);
        gameOverManager.Init();
    }

    private void CreateServices()
    {
        var screenCenter = Screen.width/2;
        screenSize = new ScreenSize(screenCenter);
        blockSpawner.OnGameOver += StartGameOver;
        gameOverManager.OnRestartGame += RestartTheGame;
    }

    private void StartGameOver()
    {
        gameOverManager.GameOver();
        blockSpawner.ClearPool();
        blockSpawner.InitGameParams();
    }

    private void RestartTheGame()
    {
        
        ballBehaviour.InitPlayer();
    }
}
