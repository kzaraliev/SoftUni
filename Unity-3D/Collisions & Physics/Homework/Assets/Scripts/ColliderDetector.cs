using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ColliderDetector : MonoBehaviour
{
    private RaycastHit hit;
    private float hitDistance = 5f;
    private bool isCrashed = false;

    private void FixedUpdate()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitDistance, Color.green);

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, hitDistance))
        {
            Debug.Log($"Did hit!");
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "GateDetector" && isCrashed == false)
        {
            Debug.Log("Gate passed!");

        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Quad"))
        {
            isCrashed = true;
            Debug.Log("Plane crashed! Game Over");
        }
    }
}
