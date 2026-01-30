using System;
using UnityEngine;

public class MaskVision : MonoBehaviour
{
    [SerializeField] bool[] Masks;
    [SerializeField] float dist;
    

    void Start()
    {
        Masks = new bool[5];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, dist))
        {
            Debug.Log("h");
        }
    }

    void UpdateMaskState(int maskId, bool state)
    {
        Masks[maskId] = state;
        foreach (var visionDependant in FindObjectsByType<VisionDependant>(FindObjectsSortMode.None))
        {
            visionDependant.AdjustVisibility(maskId, state);
        }
    }
}
