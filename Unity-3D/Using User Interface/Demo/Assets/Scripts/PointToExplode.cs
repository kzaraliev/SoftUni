using UnityEngine;

public class PointToExplode : MonoBehaviour
{
    public float explodeForce;
    public UI ui;

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name.Contains("Van") || hit.transform.name.Contains("Crate"))
                {
                    ui.UpdateScore(10);
                    ExplodeNear(hit);
                }
            }
        }
    }

    public void ExplodeNear(RaycastHit hit)
    {
        Vector3 randomVector = new Vector3(GetRandom(), GetRandom(), GetRandom());
        hit.transform.GetComponent<Rigidbody>().AddExplosionForce(explodeForce, hit.transform.position + randomVector, 10);
    }

    private float GetRandom()
    {
        return Random.Range(0.1f, 1f);
    }
}
