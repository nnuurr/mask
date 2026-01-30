using UnityEngine;

public class Throwable : MonoBehaviour
{
    [SerializeField] private Transform playerTrans;
    [SerializeField] private Animator breakMaskAnim;
    private Rigidbody rb;
    private Draggable draggable;

    private float force = 50;
    private bool pickedUp = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        draggable = GetComponent<Draggable>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(draggable.IsDragging())
        {
            if(breakMaskAnim != null)
            {
                breakMaskAnim.SetBool("break", true);
            }
            pickedUp = true;
        }
        else if(pickedUp)
        {
            rb.AddForce(playerTrans.forward * force + playerTrans.up * (force/2), ForceMode.Impulse);
            pickedUp = false;
        }
    }
}
