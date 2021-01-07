using System;
using InputTouchLogic;
using UnityEngine;
using UnityEngine.Serialization;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] 
    private InputTouchController inputTouchController;
    [FormerlySerializedAs("ballMovement")] [SerializeField]
    private BallBehaviour ballBehaviour;

    private ScreenSize screenSize;

    private void Awake()
    {
        CreateServices();
        
        inputTouchController.Init(screenSize);
        ballBehaviour.Init(screenSize, inputTouchController);
    }

    private void CreateServices()
    {
        var screenCenter = Screen.width/2;
        screenSize = new ScreenSize(screenCenter);
    }
}
