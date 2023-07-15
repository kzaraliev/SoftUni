using UnityEngine;

[ExecuteInEditMode]
public class Follow : MonoBehaviour
{
    public GameObject Target;

    public Vector3 Position = new Vector3(0, 5, 10);
    public Quaternion Rotation = new Quaternion(0, 0, 0, 0);

    public void LateUpdate()
    {
        transform.position = Target.transform.position - Position;
        transform.LookAt(Target.transform);
    }
}
