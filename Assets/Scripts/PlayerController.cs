using System.Collections;
using System.IO;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRb;
    [SerializeField] private float MAX_VELOCITY;
    [SerializeField] private float speed = 10;
    
    private float velX = 0;
    private float velY = 0;
    private float velZ = 0;

    private const float MAX_JUMP_TIME = 0.1f;
    private float jTimeModifier = 2;
    private float jumpTime = MAX_JUMP_TIME;
    private float jumpForce = 10;
    private float groundedRayDis = 0.3f;

    #region camera

    public Transform camera;
    public float xRotate = 0f, MaxTurn = 90f, MinTurn = -90f, mouseSens = 5f;
    #endregion
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnMouse()
    {
        float x = Input.GetAxis("Mouse X") * mouseSens;
        float y = Input.GetAxis("Mouse Y") * mouseSens;

        xRotate -= y;
        xRotate = Mathf.Clamp(xRotate, MinTurn, MaxTurn);

        camera.localRotation = Quaternion.Euler(xRotate, 0f, 0f);

        transform.Rotate(Vector3.up * x);
    }
    void Update() 
    {
        OnMouse();
    }
    void FixedUpdate()
    {
        ApplyVelocity();
    }

    void Move() 
    { 
        float xAxis = Input.GetAxis("Horizontal");
        float zAxis = Input.GetAxis("Vertical");

        velZ = Mathf.Clamp(zAxis * speed, -MAX_VELOCITY, MAX_VELOCITY);
        velX = Mathf.Clamp(xAxis * speed, -MAX_VELOCITY, MAX_VELOCITY);
    }


    void Jump() 
    {
        bool jumpInput = Input.GetButton("Jump");
        bool isGrounded = Physics.BoxCast(transform.position, new Vector3(0.32f, 0.64f, 0.32f), Vector3.down, Quaternion.Euler(Vector3.zero), groundedRayDis);
        
        if(jumpInput) 
        {
            velY = jumpForce;
            jTimeModifier = 1;
        }
        else if (jumpTime > 0 && velY != 0)
        { 
            velY = jumpForce / 2;
            jTimeModifier = 2;
        }

        if(velY > 0f && jumpTime > 0) 
        {
            jumpTime -= Time.deltaTime * jTimeModifier;
        }
        else if (!isGrounded) 
        {
            velY = -jumpForce;
        }
        else 
        {
            velY = 0f;
            jumpTime = MAX_JUMP_TIME;
        }
    }

    void ApplyVelocity() 
    {
        Move();
        Jump();
        playerRb.linearVelocity = transform.right * velX + transform.forward * velZ + transform.up * velY;
    }
}
