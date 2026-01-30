using UnityEngine;

public class PlayerCursor2 : MonoBehaviour
{
    public Texture2D cursorArrow;
    public Texture2D cursorInteractable;

    private Camera _cam;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _cam = Camera.main;
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
