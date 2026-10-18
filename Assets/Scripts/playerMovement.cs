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
    [SerializeField] public int health = 3;
    [SerializeField] private float origfallDist = 10f;
    public float fallDist;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fallDist = origfallDist;
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
        fallDist -= Time.deltaTime;
        Debug.Log(fallDist);
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

    void OnCollisionEnter2D(Collision2D other)
    {
        // if the other's game object is a platform,
        // and the height fallen exceeds the fall distance,
        // take damage
        if (other != null && other.gameObject.CompareTag("platform")){
            Debug.Log("Player hit a platform");
            if (fallDist <= 0f)
            {
                health -= 1;
                Debug.Log("Ouch");
                fallDist = origfallDist;
            }
        }
    }
}
