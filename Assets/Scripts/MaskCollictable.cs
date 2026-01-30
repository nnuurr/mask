using UnityEngine;

public class MaskCollictable : MonoBehaviour
{
    [Header("Specific:")]
    [SerializeField] private int maskNumber;

    private FirstMask fMask;
    private SecondMask sMask;
    private ThirdMask tMask;

    [Header("Masks Objects:")]
    [SerializeField] private GameObject[] Masks;
    
    private Draggable drag;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        drag = GetComponent<Draggable>();

        fMask = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstMask>();
        sMask = GameObject.FindGameObjectWithTag("Player").GetComponent<SecondMask>();
        tMask = GameObject.FindGameObjectWithTag("Player").GetComponent<ThirdMask>();
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
                    Mask2();
                    Mask3();
                    break;
                case 2:
                    Mask1();
                    sMask.Activate(true);
                    Mask3();
                    break;
                case 3:
                    Mask1();
                    Mask2();
                    tMask.Activate(true);
                    break;
            }
            Destroy(gameObject);
        }
    }

    void Mask1()
    {
        if(fMask.GetIsActive())
        {
            Instantiate(Masks[0], transform.position, Quaternion.identity);
            fMask.Activate(false);
        }
    }
    void Mask2()
    {
        if(sMask.GetIsActive())
        {
            Instantiate(Masks[1], transform.position, Quaternion.identity);
            sMask.Activate(false);
        }
    }
    void Mask3()
    {
        if(tMask.GetIsActive())
        {
            Instantiate(Masks[2], transform.position, Quaternion.identity);
            tMask.Activate(false);
        }
    }
}
