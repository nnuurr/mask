using NUnit.Framework;
using UnityEngine;

public class SecondMask : MonoBehaviour
{
    [SerializeField]
    private Light localLightSource;
    [SerializeField]
    private Light directionalSource;

    [SerializeField]
    private GameObject floatingEyes;

    [SerializeField]
    private bool IsActive = false;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Activate(!IsActive);
        }
    }

    public void Activate(bool state)
    {
        if (localLightSource != null) localLightSource.enabled = state;
        if (directionalSource != null) directionalSource.enabled = !state;
        if (floatingEyes != null) floatingEyes.SetActive(state);
        IsActive = state;
    }

    public bool GetIsActive()
    {
        return IsActive;
    }
}
