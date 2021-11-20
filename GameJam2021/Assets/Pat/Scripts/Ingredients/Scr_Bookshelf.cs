using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Bookshelf : MonoBehaviour
{
    private Transform tr;
    private Rigidbody rb;
    [HideInInspector]
    public float dir;
    //[HideInInspector]

    private void Start()
    {
        tr = this.transform;
        rb = this.GetComponent<Rigidbody>();

        dir = Vector3.Dot(tr.right, Vector3.right);

        if (Mathf.Abs(dir) == 1)
        {
            rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;

        }
        else
        {
            rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotation;
        }
    }
}
