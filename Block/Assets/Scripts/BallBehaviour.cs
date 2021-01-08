using InputTouchLogic;
using Interfaces;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    [SerializeField] private float ballMovementSpeed;
    private ScreenSize screenSize;
    private CircleCollider2D collider;
    private float colliderRadius;
    private float leftBorder, rightBorder;

    public void Init(ScreenSize screenSize, IClickable inputClick)
    {
        inputClick.OnPressed += MoveBall;
        this.screenSize = screenSize;
        
        collider = GetComponent<CircleCollider2D>();
        InitMoveBorders();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var block = other.GetComponent<IDestructable>();
        if (block==null) return;
    }

    private void InitMoveBorders()
    {
        colliderRadius = collider.radius;
        
        leftBorder = -screenSize.ScreenBorders.x + colliderRadius;
        rightBorder = screenSize.ScreenBorders.x - colliderRadius;
    }

    private void MoveBall(int screenPositionScale)
    {
        var ballPosition = transform.position;
        var ballTranslation = Vector3.right * screenPositionScale * ballMovementSpeed * Time.deltaTime;
        
        ballPosition.x += ballTranslation.x;
        
        var newPosX = Mathf.Clamp(ballPosition.x, leftBorder, rightBorder);
        
        transform.position = new Vector3(newPosX, ballPosition.y, ballPosition.z);
    }
}

