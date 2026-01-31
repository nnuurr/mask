using UnityEngine;

public class Puzzle1End : MonoBehaviour
{
    [SerializeField] private EndLevel level1;
    [SerializeField] private ClickableButtonsManager butManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(butManager.GetDidFinish())
        {
            level1.OpenDoor();
        }
    }
}
