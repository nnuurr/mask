using UnityEngine;

public class EndLevel : MonoBehaviour
{
    private const float OPEN = 130;
    [SerializeField] private Transform door;
    [SerializeField] private GameObject ender;
    
    private Quaternion doorStart;
    private Quaternion doorOpen;

    private bool openTheDoor = false;
    private float duration = 1.5f;
    private float time = 0.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ender.SetActive(false);

        doorStart = door.localRotation;
        doorOpen = Quaternion.Euler(0, OPEN, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(openTheDoor && time < duration)
        {
            ender.SetActive(true);

            door.localRotation = Quaternion.Lerp(doorStart, doorOpen, time / duration);
            time += Time.deltaTime;
        }
    }

    public void OpenDoor()
    {
        openTheDoor = true;
    }
}
