using UnityEngine;

public class CubePlacer : MonoBehaviour
{
    private Grid grid;
    Vector3 scale = new Vector3(3, 3, 3);

    private void Awake()
    {
        grid = FindObjectOfType<Grid>();
    }   

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hitInfo))
            {
                if(hitInfo.collider.tag == "Road")
                {
                    PlaceCubeNear(hitInfo.point);
                }
            }
        }
    }

    private void PlaceCubeNear(Vector3 clickPoint)
    {
        var finalPosition = grid.GetNearestPointOnGrid(clickPoint);
        GameObject pl = GameObject.CreatePrimitive(PrimitiveType.Cube);
        pl.transform.localScale = scale;


        pl.transform.position = finalPosition;

        //GameObject.CreatePrimitive(PrimitiveType.Sphere).transform.position = nearPoint;
    }
}