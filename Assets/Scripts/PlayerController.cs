using System;
using System.Collections;
using System.IO;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRb;
    [SerializeField] private float MAX_VELOCITY;
    [SerializeField] private float speed = 10;
    
    private float velX = 0;
    private float velZ = 0;

    private float jumpForce = 500;
    private float groundedRayDis = 0.3f;

    #region camera

    public Transform camera;
    public float xRotate = 0f, MaxTurn = 90f, MinTurn = -90f, mouseSens = 5f;
    #endregion

    private CursorControl cursorControl;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        cursorControl = FindFirstObjectByType<CursorControl>();
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
        CheckForInteractable();
    }

    private void CheckForInteractable()
    {
        Vector2 screenPos = new Vector2(Screen.width / 2, Screen.height / 2); 
        Ray ray = Camera.main.ScreenPointToRay(screenPos); 
        if (Physics.Raycast(ray, out RaycastHit hit, 2f)) 
        { 
            Clickable clickable = hit.collider.GetComponent<Clickable>(); 
            if (clickable != null) 
            {
                cursorControl.SetCursorTo(1);
            }
            else
            {
                cursorControl.SetCursorTo(0);
            }
        }
        else 
        {
            cursorControl.SetCursorTo(0);
        }
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
        if(jumpInput && isGrounded)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void ApplyVelocity() 
    {
        Move();
        Jump();
        playerRb.linearVelocity = transform.right * velX + transform.forward * velZ + Vector3.up * playerRb.linearVelocity.y;
    }
}
