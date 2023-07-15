using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float rotationSpeed = 10f;
    public float torqueSpeed = 0.5f;
    public float verticalInput;
    public float horizontalInput;
    public float rollInput;

    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rollInput = 0;
        
        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");
        // get the user's vertical input
        horizontalInput = Input.GetAxis("Horizontal");


        rb.AddRelativeForce(Vector3.forward * speed, ForceMode.Acceleration);
        rb.AddTorque(Vector3.up * torqueSpeed * horizontalInput, ForceMode.Acceleration);

        if (Input.GetKey(KeyCode.Q))
        {
            rollInput = -1;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            rollInput = 1;
        }

        // tilt the plane up/down/left/right based on arrow keys
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime * verticalInput);
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime * horizontalInput);
        transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime * rollInput);
    }   
}
