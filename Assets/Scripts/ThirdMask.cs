using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ThirdMask : MonoBehaviour
{
    [SerializeField]
    public PostProcessVolume postProcessVolume;

    [SerializeField]
    private bool IsActive = false;

    public void Update()
    {
    }

    public void Activate(bool state)
    {
        if (postProcessVolume!=null) postProcessVolume.enabled = state;
        IsActive = state;
    }

    public bool GetIsActive()
    {
        return IsActive;
    }
}
