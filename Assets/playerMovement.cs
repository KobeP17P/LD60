using UnityEngine;
using UnityEngine.InputSystem;
public class playerMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        float XmoveDistance = movementX * Time.fixedDeltaTime * speed;
        float YmoveDistance = movementY * Time.fixedDeltaTime * speed;
        transform.position = new Vector2(transform.position.x + XmoveDistance, transform.position.y + YmoveDistance);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMove(InputValue value)
    {
        Vector2 inputVector = value.Get<Vector2>();
        movementX = inputVector.x;
        movementY = inputVector.y;
    }
}
