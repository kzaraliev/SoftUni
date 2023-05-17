using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float verticalInput;
    public float horizontalInput;

    // Update is called once per frame
    void FixedUpdate()
    {
        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");


        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * speed);


        // tilt the plane up/down based on up/down arrow keys
        if (verticalInput != 0)
        {
            if (verticalInput == 1f)
            {
                transform.Rotate(-1, 0, 0 * rotationSpeed * Time.deltaTime);
            }

            if (verticalInput == -1f)
            {
                transform.Rotate(1, 0, 0 * rotationSpeed * Time.deltaTime);
            }
        }

        if (horizontalInput != 0)
        {
            if (horizontalInput == 1f)
            {
                transform.Rotate(0, 1, 0 * rotationSpeed * Time.deltaTime);
            }

            if (horizontalInput == -1f)
            {
                transform.Rotate(0, -1, 0 * rotationSpeed * Time.deltaTime);
            }
        }

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, 0, 1 * rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, 0, -1 * rotationSpeed * Time.deltaTime);
        }
    }
}
