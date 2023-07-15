using UnityEngine;

public class Propeller : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.Rotate(Vector3.forward * 10);
    }
}
