using UnityEngine;

public class CarController : MonoBehaviour
{
    private float forwardInput;
    private float sideInput;

    public int driveSpeed;
    public int turnSpeed;

    private Rigidbody car;

    public void Start()
    {
        car = GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        forwardInput = Input.GetAxis("Vertical");
        sideInput = Input.GetAxis("Horizontal");

        car.AddRelativeForce(Vector3.forward * forwardInput * driveSpeed, ForceMode.Acceleration);
        car.AddTorque(Vector3.up * sideInput * turnSpeed, ForceMode.Acceleration);
    }
}
