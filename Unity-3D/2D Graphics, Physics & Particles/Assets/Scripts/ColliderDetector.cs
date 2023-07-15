using UnityEngine;

public class ColliderDetector : MonoBehaviour
{
    enum Status
    {
        Playing,
        Passed,
        Failed,
        Dead
    }

    public UI gameUI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "GateDetector")
        {
            gameUI.UpdateTimer();
            gameUI.UpdateGateCounter();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        gameUI.ShowGameOverScreenDeath();
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
        }
    }
}
