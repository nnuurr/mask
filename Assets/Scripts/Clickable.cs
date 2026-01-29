using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Clickable : MonoBehaviour
{
    [SerializeField]
    private int clickCounter;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log("Clickable object was clicked!");
        clickCounter++;
    }
}
