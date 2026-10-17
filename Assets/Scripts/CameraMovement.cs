using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Player object, or the object to follow
    [SerializeField] private Transform player;
    [SerializeField] private Vector2 offset = new Vector3(0f, 3f);
    [SerializeField] private float smoothTimeX = 0.30f;
    [SerializeField] private float smoothTimeY = 0.1f;

    private Vector3 vel = Vector3.zero;
    private float fixedZ;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fixedZ = transform.position.z;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(player == null)
        {
            return;
        }

        // destination position
        float newX = Mathf.SmoothDamp(transform.position.x, player.position.x + offset.x, ref vel.x, smoothTimeX);
        float newY = Mathf.SmoothDamp(transform.position.y, player.position.y + offset.y, ref vel.y, smoothTimeY);
        transform.position = new Vector3(newX, newY, fixedZ);
    }
}
