using UnityEngine;

public class RandomObstaclesSpawner : MonoBehaviour
{
    [SerializeField]
    private int obstaclesCount = 10;

    private void Start()
    {
        for (int i = 0; i < obstaclesCount; i++)
        {
            float x = GetRandomValueOnTestPlane();
            float z = GetRandomValueOnTestPlane();
            float xScale = Random.Range(1f, 5f);
            float zScale = Random.Range(1f, 5f);

            var obstacle = GameObject.CreatePrimitive(PrimitiveType.Cube);
            obstacle.transform.parent = transform;
            obstacle.transform.SetPositionAndRotation(new Vector3(x, 0.5f, z), Quaternion.AngleAxis(Random.Range(0, 360), Vector3.up));
            obstacle.transform.localScale = new Vector3(xScale, 1, zScale);
        }
    }

    private static float GetRandomValueOnTestPlane()
    {
        return Random.Range(2f, 50f) * RandomSign();
    }

    private static int RandomSign()
    {
        return 2 * Random.Range(0, 2) - 1;
    }
}
