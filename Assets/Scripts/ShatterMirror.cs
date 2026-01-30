using UnityEngine;

public class ShatterMirror : MonoBehaviour
{
    [SerializeField] private GameObject glass;
    [SerializeField] private Draggable draggable;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        glass.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Throwable") && !draggable.IsDragging())
        {
            glass.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
