using UnityEngine;

public class OpenDrawer : Clickable
{
    [SerializeField] private float offSet;
    private Vector3 endPos;
    private Vector3 startPos;

    private bool isOpening = false;
    
    public float duration = 1.5f;
    private float time = 0.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        startPos = transform.position;
        endPos = transform.position + transform.forward * offSet;

        clickableType = ClickableType.Interactable;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpening && time < duration)
        {
            transform.position = Vector3.Lerp(startPos, endPos, time / duration);
            time += Time.deltaTime;
        }
    }

    public override void Clicked()
    {
        isOpening = true;
        SetClickable(false);
    }
}
