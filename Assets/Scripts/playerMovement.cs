using UnityEngine;
using UnityEngine.InputSystem;
public class playerMovement : MonoBehaviour
{
    [SerializeField] float gravity = -9.81f;
    public float origspeed = 200f;
    private float speed;
    public float movementX;
    public float movementY;
    public bool slowFall = false;
    private float speedTime = 10f;
    private Rigidbody2D playerObj;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = origspeed;
        playerObj = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float XmoveDistance = movementX * Time.fixedDeltaTime * speed;
        float YmoveDistance = movementY * Time.fixedDeltaTime * speed;
        playerObj.linearVelocity = new Vector2(XmoveDistance, YmoveDistance);
    }

    // Update is called once per frame
    void Update()
    {
        if (slowFall)
        {
            speed = 40f;
            speedTime -= Time.deltaTime;
            if(speedTime < 0f)
            {
                speedTime = 10f;
                slowFall = false;
                speed = origspeed;
            }
        }
    }

    void OnMove(InputValue value)
    {
        Vector2 inputVector = value.Get<Vector2>();
        movementX = inputVector.x;
        movementY = inputVector.y;
    }
}
