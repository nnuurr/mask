using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class CursorControl : MonoBehaviour
{
    [SerializeField]
    Sprite defaultCursor;
    [SerializeField]
    Sprite interactableCursor;

    private Image image;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    public void SetCursorTo(int objectType)
    {
        switch (objectType)
        {
            case 0:
                image.sprite = defaultCursor;
                break;
            case 1:
                image.sprite = interactableCursor;
                break;
            default:
                image.sprite = defaultCursor;
                break;
        }
    }    
}
