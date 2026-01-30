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

    [Header("Placement Validation")]
    public LayerMask invalidLayers;   // Layers the object cannot overlap
    public float checkRadius = 0.5f;  // Size of overlap check
    private bool isValid = true;

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
        isValid = !Physics.CheckSphere(transform.position, checkRadius, invalidLayers);

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
            transform.position = originalPosition;

        // Restore original color
        SetColor(originalColor);
    }

    private void SetColor(Color c)
    {
        rend.material.color = c;
    }
}
