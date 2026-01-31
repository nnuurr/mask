using UnityEngine;

public class ParanoiaObjects : MonoBehaviour
{
    [SerializeField] private GameObject obj;
    private BoxCollider bColl;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bColl = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(obj.activeSelf)
        {
            bColl.center = obj.transform.localPosition;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("MainCamera"))
        {
            obj.SetActive(!obj.activeSelf);
        }   
    }
}
