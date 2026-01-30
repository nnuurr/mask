using UnityEngine;

public class OpenCloset : Clickable
{
    private const int openCloset = 130;
    private const int closeCloset = 0;
    [SerializeField] private Transform leftDoor;
    [SerializeField] private Transform rightDoor;
    private Quaternion leftDoorStart;
    private Quaternion rightDoorStart;
    private Quaternion leftDoorOpen;
    private Quaternion rightDoorOpen;

    private bool isOpening = false;
    public float duration = 1.5f;
    private float time = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        clickableType = ClickableType.Interactable;
    }

    private void Start()
    {
        leftDoorStart = leftDoor.localRotation;
        rightDoorStart = rightDoor.localRotation;
        leftDoorOpen = Quaternion.Euler(0, openCloset, 0);
        rightDoorOpen = Quaternion.Euler(0, -openCloset, 0);
    }

    private void FixedUpdate()
    {
        if (isOpening && time < duration)
        {
            leftDoor.localRotation = Quaternion.Lerp(leftDoorStart, leftDoorOpen, time / duration);
            rightDoor.localRotation = Quaternion.Lerp(rightDoorStart, rightDoorOpen, time / duration);
            time += Time.deltaTime;
        }
    }

    public override void OnMouseDown()
    {
        isOpening = true;
    }
}
