using UnityEngine;

public class MasksSounds : MonoBehaviour
{
    [SerializeField] private AudioClip[] masksSounds;
    [SerializeField] private AudioSource ASource;
    [SerializeField] private FirstMask fMask;
    [SerializeField] private SecondMask sMask;
    [SerializeField] private ThirdMask tMask;
    bool once = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fMask.GetIsActive())
        {
            ASource.PlayOneShot(masksSounds[0]);
        }
        else if (sMask.GetIsActive())
        {
            ASource.PlayOneShot(masksSounds[1]);
        }
        else if (tMask.GetIsActive())
        {
            ASource.PlayOneShot(masksSounds[2]);
        }
    }
}
