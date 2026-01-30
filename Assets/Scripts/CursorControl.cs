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

    [SerializeField]
    private Vector2 offsetForNonDefaultCursor = new Vector2();

    private void Start()
    {
        image = GetComponent<Image>();
    }

    public void SetCursorTo(ClickableType objectType)
    {
        switch (objectType)
        {
            case ClickableType.None:
                image.sprite = defaultCursor;
                image.transform.localPosition = new Vector3(0.0f,
                                             0.0f,
                                             0.0f);
                break;
            case ClickableType.Interactable:
            case ClickableType.Draggable:
                image.sprite = interactableCursor;
                image.transform.localPosition = new Vector3(offsetForNonDefaultCursor.x,
                                             offsetForNonDefaultCursor.y,
                                             0.0f);
                break;
            default:
                image.sprite = defaultCursor;
                image.transform.localPosition = new Vector3(offsetForNonDefaultCursor.x,
                                             offsetForNonDefaultCursor.y,
                                             0.0f);
                break;
        }
    }    
}
