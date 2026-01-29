using System.IO;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRb;
    [SerializeField] private float MAX_VELOCITY;
    [SerializeField] private float speed = 10;
    private float velX = 0;
    private float velZ = 0;


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

        float xAxis = Input.GetAxis("Horizontal");
        float zAxis = Input.GetAxis("Vertical");


        velZ = Mathf.Clamp(zAxis * speed, -MAX_VELOCITY, MAX_VELOCITY);
        velX = Mathf.Clamp(xAxis * speed, -MAX_VELOCITY, MAX_VELOCITY);


        playerRb.linearVelocity = transform.right * velX + transform.forward * velZ;

    }


}
