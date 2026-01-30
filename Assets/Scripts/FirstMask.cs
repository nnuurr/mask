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
        postProcessVolume.enabled = state;
        IsActive = state;
    }
}
