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
    private float killSpeed = 15f;
    private float speedTime = 10f;
    private Rigidbody2D playerObj;
    private Vector2 preVelocity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = origspeed;
        playerObj = GetComponent<Rigidbody2D>();
    }

    void Die()
    {
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        float XmoveDistance = movementX * Time.fixedDeltaTime * speed;
        float YmoveDistance = movementY * Time.fixedDeltaTime * speed;
        playerObj.linearVelocityX = XmoveDistance;
        preVelocity = playerObj.linearVelocity;
    }

    // Update is called once per frame
    void Update()
    {
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

    void OnMove(InputValue value)
    {
        Vector2 inputVector = value.Get<Vector2>();
        movementX = inputVector.x;
        movementY = inputVector.y;
    }
}
