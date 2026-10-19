using UnityEngine;
using UnityEngine.InputSystem;
public class playerMovement : MonoBehaviour
{
    public float origspeed = 200f;
    private float speed;
    public float movementX;
    public float movementY;
    public bool slowFall = false;
    private float killSpeed = 15f;
    private float speedTime = 10f;
    private Rigidbody2D playerObj;
    [SerializeField] public int health = 3;
    [SerializeField] private float origfallDist = 10f;
    public float fallDist;
    private Vector2 preVelocity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fallDist = origfallDist;
        speed = origspeed;
        playerObj = GetComponent<Rigidbody2D>();
    }

    void Die()
    {
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        float targetVelocityX = movementX * speed;
        float targetVelocityY = movementY * speed;
        playerObj.linearVelocity = new Vector2(targetVelocityX, playerObj.linearVelocity.y);
        preVelocity = playerObj.linearVelocity;
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
            playerObj.gravityScale = .5f;
            if (speedTime < 0f)
            {
                speedTime = 10f;
                slowFall = false;
                speed = origspeed;
                playerObj.gravityScale = 1;
            }
        }
    }
    /*

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground") && preVelocity.y < 0 && -preVelocity.y >= killSpeed)
        {
            Die();
        } else if (collision.gameObject.CompareTag("cushion"))
        {
            //playerObj.AddForce(new Vector2(0, 200f));
        }
    }

    */

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
