using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class VisionDependant : MonoBehaviour
{
    [SerializeField]
    int visibleByMask = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void AdjustVisibility(int currentMask, bool state)
    {
        if (currentMask == visibleByMask)
        {
            this.GetComponent<Renderer>().enabled = state;
        }
    }
}
