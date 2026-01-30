using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class WeightSensor : MonoBehaviour
{
    public void ActivateSensor(Draggable src)
    {
        Debug.Log($"Weight Sensor Activated by {src.name}");
    }    
}
