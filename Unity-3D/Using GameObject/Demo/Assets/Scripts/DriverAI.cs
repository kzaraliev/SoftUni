using UnityEngine;

public class DriverAI : MonoBehaviour
{
    public Vector3 endPosition;

    public float speed = 1f;
    private Vector3 startPosition;
    private float startTime;
    private float journeyLength;

    private void Start()
    {
        startPosition = transform.position;
        journeyLength = Vector3.Distance(startPosition, endPosition);
        startTime = Time.time;
    }

    private void Update()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fractionOfJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(startPosition, endPosition, fractionOfJourney);
    }
}
