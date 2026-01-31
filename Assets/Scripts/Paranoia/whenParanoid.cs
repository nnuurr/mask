using UnityEngine;

public class whenParanoid : MonoBehaviour
{
    private FirstMask fMask;
    [SerializeField] private GameObject[] paranoidObjects;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fMask = FindFirstObjectByType<FirstMask>().GetComponent<FirstMask>();
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < paranoidObjects.Length; i++)
        {
            paranoidObjects[i].SetActive(fMask.GetIsActive());
        }
    }
}
