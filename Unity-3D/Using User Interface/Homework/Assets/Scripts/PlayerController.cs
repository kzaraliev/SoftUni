using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float forwardForce;
    public float verticalForce;
    public float horizontalForce;
    public float rollForce;

    private Rigidbody body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var rollInput = 0;

        // Push the plane forward
        body.AddRelativeForce(Vector3.forward * forwardForce, ForceMode.Acceleration);
        
        // tilt the plane by vertically
        var input = Input.GetAxis("Vertical");
        body.AddRelativeTorque(Vector3.right * this.verticalForce * input, ForceMode.Acceleration);

        // tilt the plane by horizontally
        input = Input.GetAxis("Horizontal");
        body.AddRelativeTorque(Vector3.up * this.horizontalForce * input, ForceMode.Acceleration);

        if (Input.GetKey(KeyCode.Q))
        {
            rollInput = -1;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            rollInput = 1;
        }

        // roll the plane
        body.AddRelativeTorque(Vector3.forward * this.rollForce * rollInput, ForceMode.Acceleration);
    }
}
