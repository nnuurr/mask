using UnityEngine;

public class EyeLook : MonoBehaviour
{
    [SerializeField] private Transform lookTrans;
    [SerializeField] private ClickableButtonsManager bManager;
    int currentBot;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(bManager != null)
        {

        }
        transform.LookAt(lookTrans.position);
    }
}
