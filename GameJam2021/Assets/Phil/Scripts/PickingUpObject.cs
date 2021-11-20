using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickingUpObject : MonoBehaviour
{

    //TO SETUP:
    //Object to pickup must have the tag "QuestItem"
    //Object to pickup must have a rigidbody
    //Press "E" to grab an item an "E" again to release it

    public float range = 25f;
    public float moveForce = 250f;
    public Transform holdParent;
    private GameObject heldObject;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldObject == null)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, out hit, range))
                {
                    if(hit.transform.gameObject.tag == "QuestItem")
                    {
                        PickupObject(hit.transform.gameObject);
                    }
                    

                }
            }
            else
            {
                DropObject();

            }
        }

        if (heldObject != null)
        {
            MoveObject();
        }


        //RAYCAST DEBUG
        Debug.DrawRay(transform.position, transform.forward * range, Color.red);

    }
    
    
    
    
    void MoveObject()
    {
        if (Vector3.Distance(heldObject.transform.position, holdParent.transform.position) > 0.1f)
        {
            Vector3 moveDirection = (holdParent.position - heldObject.transform.position);
            heldObject.GetComponent<Rigidbody>().AddForce(moveDirection * moveForce);
        }
    }

    
    
    
    void PickupObject(GameObject pickupObject)
    {
        if (pickupObject.GetComponent<Rigidbody>())
        {
            Rigidbody objectRb = pickupObject.GetComponent<Rigidbody>();
            objectRb.useGravity = false;
            objectRb.drag = 10;

            objectRb.transform.parent = holdParent;
            heldObject = pickupObject;
        }
    }

    
    
    
    void DropObject()
    {
        Rigidbody heldRb = heldObject.GetComponent<Rigidbody>();
        heldRb.useGravity = true;
        heldRb.drag = 1;

        heldObject.transform.parent = null;
        heldObject = null;
    }

}
