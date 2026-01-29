using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRb;
    [SerializeField] private float MAX_VELOCITY;
    [SerializeField] private float speed = 10;
    private float velX = 0;
    private float velZ = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float zAxis = Input.GetAxis("Vertical");

        velZ = Mathf.Clamp(zAxis * speed, -MAX_VELOCITY, MAX_VELOCITY);
        velX = Mathf.Clamp(xAxis * speed, -MAX_VELOCITY, MAX_VELOCITY);


        playerRb.linearVelocity = new Vector3(velX, 0, velZ);
    }
}
