using UnityEngine;

public class ObstacleCreator : MonoBehaviour
{
    public GameObject obstacle;
    public Vector3 roadDimension = new Vector3(10, 0, 80);
    public Transform road;

    public void Start()
    {
        for (int i = 0; i < 40; i++)
        {
            float x = Random.Range(road.position.x - roadDimension.x, road.position.x + roadDimension.x);
            float z = Random.Range(road.position.z - roadDimension.z, road.position.z + roadDimension.z);
            Vector3 position = new Vector3(x, 0, z);
            GameObject gameObject = GameObject.Instantiate(obstacle, position, Quaternion.identity);
            gameObject.name = $"Crate№_{i}";
        }  
    }
}
