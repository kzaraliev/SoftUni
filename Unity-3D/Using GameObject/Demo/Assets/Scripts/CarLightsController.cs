using UnityEngine;

public class CarLightsController : MonoBehaviour
{
    public void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            var lights = transform.GetComponentsInChildren<Light>();
            foreach (Light light in lights)
            {
                light.enabled = !light.enabled;
            }
        }
    }
}
