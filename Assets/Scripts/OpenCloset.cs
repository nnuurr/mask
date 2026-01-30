using UnityEngine;

public class OpenCloset : MonoBehaviour
{
    private const int openCloset = 130;
    private const int closeCloset = 0;
    [SerializeField] private Transform leftDoor;
    [SerializeField] private Transform rightDoor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.E))
        {
            open();
        }
    }

    private void open()
    {
        leftDoor.localRotation = Quaternion.Euler(0,openCloset,0);
        rightDoor.localRotation = Quaternion.Euler(0,-openCloset,0);
    }
}
