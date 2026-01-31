using UnityEngine;

public class ThirdPuzzle : MonoBehaviour
{
    [SerializeField] private EndLevel door;
    private int count = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (count >= 3)
        {
            door.OpenDoor();
        }
    }

    public void Counter()
    {
        count++;
    }
}
