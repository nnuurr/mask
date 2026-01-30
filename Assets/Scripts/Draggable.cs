using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Draggable : Clickable
{
    private bool isDragging = false;

    private Vector3 screenPoint;
    private Vector3 offset;
    private Vector3 originalPosition;

    private Renderer rend;
    private Color originalColor;

    private Rigidbody rb;
    private Collider col;

    private Material originalMaterial;
    [SerializeField]
    private Material draggingMaterialFine;
    [SerializeField]
    private Material draggingMaterialBad;
    [SerializeField]
    private Animator handAnim;

    [Header("Placement Validation")]
    public LayerMask invalidLayers;   // Layers the object cannot overlap
    private bool isValid = true;
    public float sensorDistance = 50f;

    void Awake()
    {
        clickableType = ClickableType.Draggable;

        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;

        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();

        originalMaterial = rend.material;
    }

    private void Update()
    {
        if (isDragging)
        {
            if (isValid)
                rend.material = (draggingMaterialFine != null) ? draggingMaterialFine : originalMaterial;
            else
                rend.material = (draggingMaterialBad != null) ? draggingMaterialBad : originalMaterial;
        }
        else
        {
            rend.material = originalMaterial;
        }

        handAnim.SetBool("Hold", isDragging);

    }

    public bool IsDragging()
    {
        return isDragging;
    }

    bool CheckPlacementValid()
    {
        BoxCollider box = col as BoxCollider;
        if (box == null)
            return true;

        // Calculate world-space box from local BoxCollider data
        Vector3 center = transform.TransformPoint(box.center);

        Vector3 halfExtents = Vector3.Scale(
            box.size * 0.5f,
            transform.lossyScale
        );

        Collider[] hits = Physics.OverlapBox(
            center,
            halfExtents,
            transform.rotation,
            invalidLayers,
            QueryTriggerInteraction.Ignore
        );

        // Ignore self just in case
        foreach (var hit in hits)
        {
            if (hit != col)
                return false;
        }

        return true;
    }

    public override void OnMouseDown()
    {
        originalPosition = transform.position;

        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position -
                 Camera.main.ScreenToWorldPoint(
                     new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

        // Disable physics
        if (rb != null)
            rb.isKinematic = true;

        // Disable collisions
        col.enabled = false;

        // Make semi-transparent
        SetColor(new Color(originalColor.r, originalColor.g, originalColor.b, 0.5f));

        isDragging = true;
    }

    void OnMouseDrag()
    {
        if (!isDragging) return;

        Vector3 curScreenPoint =
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;

        // Validate placement
        isValid = CheckPlacementValid();

        if (isValid)
            SetColor(new Color(originalColor.r, originalColor.g, originalColor.b, 0.5f));
        else
            SetColor(Color.red);
    }

    void OnMouseUp()
    {
        if (!isDragging) return;
        isDragging = false;

        // Restore physics
        if (rb != null)
            rb.isKinematic = false;

        // Restore collisions
        col.enabled = true;

        // Snap back if invalid
        if (!isValid)
        {
            transform.position = originalPosition;
        }
        else
        {
            // Check if placed on WeightSensor
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, sensorDistance))
            {
                if (hit.collider.GetComponent<WeightSensor>() != null)
                    hit.collider.GetComponent<WeightSensor>().ActivateSensor(this);
            }
        }

        // Restore original color
        SetColor(originalColor);
    }

    private void SetColor(Color c)
    {
        rend.material.color = c;
    }
}
