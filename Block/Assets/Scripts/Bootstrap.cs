using BlocksLogic.Pool;
using InputTouchLogic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] 
    private InputTouchController inputTouchController;
    [SerializeField]
    private BallBehaviour ballBehaviour;
    [SerializeField] 
    private BlockSpawner blockSpawner;
    
    private ScreenSize screenSize;

    private void Awake()
    {
        CreateServices();
        
        inputTouchController.Init(screenSize);
        ballBehaviour.Init(screenSize, inputTouchController);
        blockSpawner.Init(screenSize);
    }

    private void CreateServices()
    {
        var screenCenter = Screen.width/2;
        screenSize = new ScreenSize(screenCenter);
    }
}
