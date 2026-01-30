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
        if (Input.GetKeyDown(KeyCode.B))
        {
            Activate(!IsActive);
        }
    }

    public void Activate(bool state)
    {
        if (postProcessVolume!=null) postProcessVolume.enabled = state;
        IsActive = state;
    }
}
