using UnityEngine;

public class AsteroidProximity : MonoBehaviour
{
    private LineRenderer lineRenderer;
    public GameObject drawingPrefab;
    public Material material;
    private Transform asteroidPosition;
    private Transform planetPosition;
    public float distance_to_planet;


    private void Start()
    {
        // Adding astroid position variable for clarity
        planetPosition = GameObject.Find("Planet").transform;
        asteroidPosition = transform;
        GameObject drawing = Instantiate(drawingPrefab);
        lineRenderer = drawing.GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, asteroidPosition.position);
        lineRenderer.SetPosition(1, planetPosition.position);
    }

    void Update()
    {
        lineRenderer.SetPosition(0, asteroidPosition.position);
        distance_to_planet = CalculateDistance(asteroidPosition.position, planetPosition.position);
    }

    private float CalculateDistance(Vector3 asteroidPos, Vector3 planetPos)
    {
        float x1 = asteroidPos.x;
        float y1 = asteroidPos.y;

        float x2 = planetPos.x;
        float y2 = planetPos.y;

        float distance = Mathf.Sqrt(Mathf.Pow((x2 - x1), 2) + Mathf.Pow((y2 - y1), 2));
        return distance;
    }
}
