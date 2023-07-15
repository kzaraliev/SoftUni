using UnityEngine;

public class CarLightsController : MonoBehaviour
{
    public void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Light[] lights = transform.GetComponentsInChildren<Light>();
            foreach (Light light in lights)
            {
                light.enabled = !light.enabled;
            }
        }
    }
}
