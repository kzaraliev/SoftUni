using UnityEngine;

public class DriverAI : MonoBehaviour
{
    private Rigidbody body;

    private void Start()
    {
        this.body = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        this.body.AddRelativeForce(new Vector3(0, 0, 10), ForceMode.Acceleration);
    }
}
