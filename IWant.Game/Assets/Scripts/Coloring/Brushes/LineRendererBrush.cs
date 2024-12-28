using UnityEngine;

public class LineRendererBrush : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private LineRenderer linePrefab;
    private LineRenderer currentLineRenderer;

    [Header(" Settings ")]
    [SerializeField] private Color color;
    [SerializeField] private float distanceThreshold;
    private Vector2 lastClickedPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            CreateLine();
        else if (Input.GetMouseButton(0))
            PaintOnCanvas();
    }


    private void CreateLine()
    {
        RaycastHit hit;
        Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity);

        //We didn't hit anything
        if (hit.collider == null) return;

        currentLineRenderer = Instantiate(linePrefab, Vector3.zero, Quaternion.identity, transform);

        currentLineRenderer.SetPosition(0, hit.point);

        currentLineRenderer.startColor = color;
        currentLineRenderer.endColor = currentLineRenderer.startColor;

        // Save the last clicked position
        lastClickedPosition = Input.mousePosition;
    }
    private void PaintOnCanvas()
    {
        if (currentLineRenderer == null) return;

        if (Vector2.Distance(lastClickedPosition, Input.mousePosition) < distanceThreshold) return;

        // Save the last clicked position
        lastClickedPosition = Input.mousePosition;

        RaycastHit hit;
        Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity);

        //We didn't hit anything, ensure we paint inside the canvas
        if (hit.collider == null) return;

        AddPoint(hit.point);
    }

    private void AddPoint(Vector3 worldPos)
    {
        currentLineRenderer.positionCount++;
        currentLineRenderer.SetPosition(currentLineRenderer.positionCount - 1, worldPos);

    }
}
