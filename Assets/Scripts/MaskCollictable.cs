using UnityEngine;

public class MaskCollictable : MonoBehaviour
{
    [Header("Specific:")]
    [SerializeField] private int maskNumber;

    [Header("Masks:")]
    [SerializeField] private FirstMask fMask;
    [SerializeField] private SecondMask sMask;
    [SerializeField] private ThirdMask tMask;
    
    private Draggable drag;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        drag = GetComponent<Draggable>();
    }

    // Update is called once per frame
    void Update()
    {
        if(drag.IsDragging())
        {
            switch(maskNumber)
            {
                case 1:
                    fMask.Activate(true);
                    break;
                case 2:
                    sMask.Activate(true);
                    break;
                case 3:
                    tMask.Activate(true);
                    break;
            }
        }
    }
}
