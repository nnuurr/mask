using NUnit.Framework;
using UnityEngine;

public class SecondMask : MonoBehaviour
{
    [SerializeField]
    private Light localLightSource;
    [SerializeField]
    private Light directionalSource;

    [SerializeField]
    private bool IsActive = false;

    public void Update()
    {
        
    }

    public void Activate(bool state)
    {
        if (localLightSource != null) localLightSource.enabled = state;
        if (directionalSource != null) directionalSource.enabled = !state;
        IsActive = state;
    }

    public bool GetIsActive()
    {
        return IsActive;
    }
}
