using UnityEngine;

public class ItemFalling : MonoBehaviour
{
    public void LateUpdate()
    {
        transform.Translate(new Vector3(0, -0.1f, 0));
    }
}
