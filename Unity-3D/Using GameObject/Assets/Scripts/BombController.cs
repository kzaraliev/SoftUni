using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    public GameObject Bomb;
    private GameObject clone;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DropSphere();
        }
    }

    //There is a problem when space is pressed before the previous sphere is gone. Need help with this! :)
    private void DropSphere()
    {
        if (clone != null)
        {
            Destroy(clone);
        }
    
        clone = Instantiate(Bomb, transform.position, Quaternion.identity);
        Rigidbody rb = clone.GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = clone.AddComponent<Rigidbody>();
        }

        Destroy(clone, 5f);
    }
}
