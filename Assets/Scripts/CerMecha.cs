using UnityEngine;

public class CerMecha : MonoBehaviour
{
    [SerializeField] private GameObject[] cerObjects;
    [SerializeField] private GameObject[] paralelObj;
    [SerializeField] private ThirdMask tMask;
    private Transform[] savedTrans;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        savedTrans = new Transform[cerObjects.Length];
    }

    // Update is called once per frame
    void Update()
    {
        
        for(int i = 0; i < cerObjects.Length; i++)
        {
            if(cerObjects[i].activeSelf)
            {
                savedTrans[i] = cerObjects[i].transform;
            }
            cerObjects[i].SetActive(tMask.GetIsActive());
            
            paralelObj[i].SetActive(!tMask.GetIsActive());

            paralelObj[i].transform.position = savedTrans[i].position;
            paralelObj[i].transform.localRotation = savedTrans[i].localRotation;
        }
    }
}
