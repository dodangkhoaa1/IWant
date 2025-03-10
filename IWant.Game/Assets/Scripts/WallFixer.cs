using Unity.VisualScripting;
using UnityEngine;

public class WallFixer : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private Transform rightWall;
    [SerializeField] private Transform leftWall;
    [SerializeField] private float pos = 0.15f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     FixWalls();
    }
    private void FixWalls()
    {
        float aspectRadio = (float)Screen.height / Screen.width;
        //Debug.Log("Aspect Radio: " + aspectRadio);

        Camera mainCamera = Camera.main;

        float halfHorizontalFov = mainCamera.orthographicSize / aspectRadio;
        //Debug.Log("World width: " + halfHorizontalFov);

        rightWall.transform.position = new Vector3(halfHorizontalFov + pos, 0, 0);
        leftWall.transform.position = -rightWall.transform.position;
    }
 
}
