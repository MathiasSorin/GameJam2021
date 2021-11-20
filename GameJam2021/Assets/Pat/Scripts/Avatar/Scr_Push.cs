using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Push : MonoBehaviour
{
    private Rigidbody rb;
    [Range(1f,5f)]
    public float pushForce = 2.0f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;

        if (body == null || body.isKinematic) return;

        if (hit.moveDirection.y < -0.3) return;

            Vector3 pushDir = hit.moveDirection;

            pushDir.y = 0f;

            //Debug.Log("isPushing");
            body.velocity = pushDir * 2;
        }
}
