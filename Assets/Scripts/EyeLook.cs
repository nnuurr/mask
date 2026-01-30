using UnityEngine;

public class EyeLook : MonoBehaviour
{    
    private Transform lookTrans;
    [SerializeField] private Transform playerTrans;
    [SerializeField] private ClickableButtonsManager bManager;
    [SerializeField] private Transform[] butTrans;
    [SerializeField] private SecondMask secondMask;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(bManager != null && secondMask.GetIsActive())
        {
            lookTrans = butTrans[bManager.GetCurrButtonIndex()];
        }
        else
        {
            lookTrans = playerTrans;
        }
        transform.LookAt(lookTrans.position);
    }
}
