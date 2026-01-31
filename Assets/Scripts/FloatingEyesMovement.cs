using UnityEngine;

public class FloatingEyesMovement : MonoBehaviour
{
    [SerializeField] private float forwardMovementLimit = 1.5f;
    [SerializeField] private float sidewaysMovementLimit = 1.0f;
    [SerializeField] private float upwardsMovementLimit = 0.5f;

    [SerializeField] private float baseSpeedForward = 0.1f;
    [SerializeField] private float baseSpeedSideways = 0.05f;
    [SerializeField] private float baseSpeedUpwards = 0.05f;

    [SerializeField] private float speedRandomRange = 0.03f;

    private float speedForward;
    private float speedSideways;
    private float speedUpwards;

    private Vector3 startPosition;
    private float phaseForward, phaseSideways, phaseUpwards;


    void Start()
    {
        startPosition = transform.localPosition;

        speedForward = baseSpeedForward + Random.Range(-speedRandomRange, speedRandomRange);
        speedSideways = baseSpeedSideways + Random.Range(-speedRandomRange, speedRandomRange);
        speedUpwards = baseSpeedUpwards + Random.Range(-speedRandomRange, speedRandomRange);
        phaseForward = Random.Range(0f, Mathf.PI * 2f);
        phaseSideways = Random.Range(0f, Mathf.PI * 2f);
        phaseUpwards = Random.Range(0f, Mathf.PI * 2f);

    }
    void Update()
    {
        float forwardOffset = Mathf.Sin(Time.time * speedForward + phaseForward)
                              * forwardMovementLimit;

        float sidewaysOffset = Mathf.Sin(Time.time * speedSideways + phaseSideways)
                               * sidewaysMovementLimit;

        float upwardOffset = Mathf.Sin(Time.time * speedUpwards + phaseUpwards)
                             * upwardsMovementLimit;

        transform.localPosition = startPosition + new Vector3(
            sidewaysOffset,
            upwardOffset,
            forwardOffset
        );
    }

}
