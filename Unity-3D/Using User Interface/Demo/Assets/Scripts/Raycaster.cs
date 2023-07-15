using UnityEngine;

public class Raycaster : MonoBehaviour
{
    public UI ui;

    public void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 10))
        {
            Vector3 randomVector = new Vector3(GetRandom(), GetRandom(), GetRandom());
            Rigidbody body = hit.transform.GetComponent<Rigidbody>();
            if (body != null)
            {
                ui.UpdateScore(10);
                body.AddExplosionForce(500, hit.transform.position + randomVector, 10);
            }
        }
    }

    private float GetRandom()
    {
        return Random.Range(0.1f, 1f);
    }
}
