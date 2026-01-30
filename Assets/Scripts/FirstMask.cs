using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class FirstMask : MonoBehaviour
{
    [SerializeField]
    public PostProcessVolume postProcessVolume;

    [SerializeField]
    private bool IsActive = false;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            Activate(!IsActive);
        }
    }

    public void Activate(bool state)
    {
        if (postProcessVolume != null) postProcessVolume.enabled = state;
        IsActive = state;
    }

    public bool GetIsActive()
    {
        return IsActive;
    }
}
