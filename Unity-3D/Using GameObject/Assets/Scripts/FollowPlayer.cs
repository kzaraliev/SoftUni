using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject plane;
    public Vector3 offset;
    private float smoothSpeed = 0.125f;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 desiredPosition = plane.transform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;

        transform.LookAt(plane.transform);
    }
}
