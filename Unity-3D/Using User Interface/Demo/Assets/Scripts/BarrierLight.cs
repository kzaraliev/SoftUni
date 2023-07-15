using UnityEngine;

public class BarrierLight : MonoBehaviour
{
    private Light light;
    private float timer = 2f;
    private bool isFirstColor = true;
    public Color firstColor = Color.yellow;
    public Color secondColor = Color.red;

    private void Start()
    {
        light = GetComponent<Light>();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = 0.5f;
            light.color = isFirstColor ? secondColor : firstColor;
            isFirstColor = !isFirstColor;
        }
    }
}
