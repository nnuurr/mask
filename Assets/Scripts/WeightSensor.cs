using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class WeightSensor : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onSensorTriggered;

    public void ActivateSensor(Draggable src)
    {
        Debug.Log($"Weight Sensor Activated by {src.name}");
        onSensorTriggered.Invoke();
    }    
}
