using UnityEngine;

public class ItemDropper : MonoBehaviour
{
    public GameObject cube;
    private Rigidbody rb;
    private float rbMass = 0.1f;


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject clone = Instantiate(cube, cube.transform.position, new Quaternion());
            clone.SetActive(true);


            rb = clone.AddComponent<Rigidbody>();
            rb.mass = rbMass;

            Destroy(clone, 5);
        }
    }
}
