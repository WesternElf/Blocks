using System;
using BlocksLogic;
using InputTouchLogic;
using UnityEngine;
using UnityEngine.Serialization;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] 
    private InputTouchController inputTouchController;
    [SerializeField]
    private BallBehaviour ballBehaviour;
    [SerializeField] 
    private PointsToSpawn pointsToSpawn;

    private ScreenSize screenSize;

    private void Awake()
    {
        CreateServices();
        
        inputTouchController.Init(screenSize);
        ballBehaviour.Init(screenSize, inputTouchController);
        pointsToSpawn.Init(screenSize);
    }

    private void CreateServices()
    {
        var screenCenter = Screen.width/2;
        screenSize = new ScreenSize(screenCenter);
    }
}
