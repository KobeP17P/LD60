using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] public Transform player;
    [SerializeField] public playerMovement playerScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Upon collision with the player, destroy this game object
    // and give the desired effect (ex. jetpack should slow fall speed)
    void OnCollisionEnter2D(Collision2D other)
    {
        // if the other's game object is a player,
        // and this object's game object is a jetpack,
        // then change the fall speed of the player
        Debug.Log("Hit something solid: ");
        if (other != null && other.gameObject.CompareTag("player") && this.gameObject.CompareTag("jetpack")){
            playerScript.slowFall = true;
            playerScript.fallDist += 10f;
        }
        Destroy(transform.gameObject);
    }
}
