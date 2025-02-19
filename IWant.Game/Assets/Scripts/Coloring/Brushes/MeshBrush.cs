using System.Collections.Generic;
using UnityEngine;

public class MeshBrush : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private MeshFilter meshFilterPrefab;

    [Header(" Settings ")]
    [SerializeField] private float brushSize;
    private Mesh mesh;

    List<Vector3> vertices = new List<Vector3>();
    List<int> triangles = new List<int>();
    List<Vector2> uvs = new List<Vector2>();

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
            CreateMesh();
        else if (Input.GetMouseButton(0))
            Paint();
    }

    // Allow to create a new mesh
    private void CreateMesh()
    {
        RaycastHit hit;
        Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity);

        //We didn't hit anything
        if (hit.collider == null) return;

        // Start Create Mesh
        mesh = new Mesh();
        vertices.Clear();
        triangles.Clear();
        uvs.Clear();

        //Setting up vertices
        vertices.Add(hit.point + (Vector3.up + Vector3.right) * brushSize / 2); // From finger position to find first vertice
        vertices.Add(vertices[0] + Vector3.down * brushSize); // From first vertice to find second vertice by go down 1 brushSize unit
        vertices.Add(vertices[1] + Vector3.left * brushSize);
        vertices.Add(vertices[2] + Vector3.up * brushSize);

        //Configure UVs
        uvs.Add(Vector2.one);
        uvs.Add(Vector2.right);
        uvs.Add(Vector2.zero);
        uvs.Add(Vector2.up);

        //Setting up triangles
        triangles.Add(0);
        triangles.Add(1);
        triangles.Add(2);

        triangles.Add(0);
        triangles.Add(2);
        triangles.Add(3);

        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.uv = uvs.ToArray();

        //Specify mesh position
        float zPosition = transform.childCount * 0.01f;
        Vector3 position = Vector3.back * zPosition;

        MeshFilter meshFilterInstance = Instantiate(meshFilterPrefab, position, Quaternion.identity, transform);
        meshFilterInstance.sharedMesh = mesh;

        meshFilterInstance.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
        // Save the last clicked position
        lastClickedPosition = Input.mousePosition;
    }

    // Allow to paint on the existing mesh
    private void Paint()
    {
        if (Vector2.Distance(lastClickedPosition, Input.mousePosition) < distanceThreshold) return;

        // Save the last clicked position
        lastClickedPosition = Input.mousePosition;

        RaycastHit hit;
        Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity);

        //We didn't hit anything
        if (hit.collider == null) return;

        //Start painting

        //The amount of vertices before drawing the quad
        int startIndex = mesh.vertices.Length;
        //Setting up vertices
        vertices.Add(hit.point + (Vector3.up + Vector3.right) * brushSize / 2); // From finger position to find first vertex
        vertices.Add(vertices[startIndex + 0] + Vector3.down * brushSize); // From first vertex to find second vertice by go down 1 brushSize unit
        vertices.Add(vertices[startIndex + 1] + Vector3.left * brushSize);
        vertices.Add(vertices[startIndex + 2] + Vector3.up * brushSize);

        //Configure UVs
        uvs.Add(Vector2.one);
        uvs.Add(Vector2.right);
        uvs.Add(Vector2.zero);
        uvs.Add(Vector2.up);

        //Setting up triangles
        triangles.Add(startIndex + 0);
        triangles.Add(startIndex + 1);
        triangles.Add(startIndex + 2);

        triangles.Add(startIndex + 0);
        triangles.Add(startIndex + 2);
        triangles.Add(startIndex + 3);

        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.uv = uvs.ToArray();

        //Get the mesh filter of last child
        transform.GetChild(transform.childCount - 1).GetComponent<MeshFilter>().sharedMesh = mesh;

    }
}
