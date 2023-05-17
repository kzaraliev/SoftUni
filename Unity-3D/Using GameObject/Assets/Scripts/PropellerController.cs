using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerController : MonoBehaviour
{
    private float rotationSpeed = 10f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,-1 * rotationSpeed, Space.Self);
    }
}
