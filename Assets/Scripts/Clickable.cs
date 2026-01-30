using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Clickable : MonoBehaviour
{
    [SerializeField]
    protected int clickCounter;

    protected ClickableType clickableType;

    private void Awake()
    {
        clickCounter = 0;
        clickableType = ClickableType.Interactable;
    }

    public virtual void OnMouseDown()
    {
        Debug.Log("Clickable object was clicked!");
        clickCounter++;
    }

    public ClickableType GetClickableType()
    {
        return clickableType;
    }

}
