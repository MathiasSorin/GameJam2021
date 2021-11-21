using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    public string textUI;
    public TextMeshProUGUI tmpUI;

    

    void Update()
    {

           
        



            if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;

            if (heldObject == null)
            {
                
                if (Physics.Raycast(transform.position, transform.forward, out hit, range))
                {
                    if(hit.transform.gameObject.tag == "QuestItem" && hit.transform.gameObject.GetComponent<Scr_Drawer>() == null)
                    {
                        PickupObject(hit.transform.gameObject);
                    }
                    
                    if (hit.transform.gameObject.tag == "Untagged" && hit.transform.gameObject.GetComponent<Scr_Remote>() != null)
                    {
                        Debug.Log("Test");
                    }
                    if (hit.transform.gameObject.tag == "QuestItem" && hit.transform.gameObject.GetComponent<Scr_Drawer>() != null)
                    {
                        hit.transform.gameObject.GetComponent<Animator>().Play("DrawerClose");
                        hit.transform.gameObject.GetComponent<Scr_Drawer>().CompleteObjective();

                    }

                }
            }
            else 
            {
                  
                    DropObject();
               
                                           

            }
        }
           
        
        RaycastHit hit2;
        if (heldObject == null & Physics.Raycast(transform.position, transform.forward, out hit2, range))
        {
            var y = hit2.transform.gameObject.GetComponent<Scr_PickupP>();
            
            if (y != null && !y.isHeld) 
            {
                if (hit2.transform.gameObject.tag == "QuestItem")
                {
                    textUI = y.IsLookedAt();
                    tmpUI.text = textUI;


                }
                
            }
            



        }
        else
        {
            textUI = "";

            tmpUI.text = textUI;
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
           
            var pickUpObjectScript = pickupObject.GetComponent<Scr_PickupP>();
            if(pickUpObjectScript != null)
            {
                
                pickUpObjectScript.isHeld = true;

            }
            



            objectRb.useGravity = false;
            objectRb.drag = 10;

            objectRb.transform.parent = holdParent;
            heldObject = pickupObject;
            pickupObject.GetComponent<Scr_PickupP>().AuxToPlay.clip = pickupObject.GetComponent<Scr_PickupP>().pickupSound;
            pickupObject.GetComponent<Scr_PickupP>().AuxToPlay.volume = 1.0f;
            pickupObject.GetComponent<Scr_PickupP>().AuxToPlay.Play();
            //heldObject.GetComponent<Scr_PickupP>().isHeld = true;
        }
    }

    
    
    
    void DropObject()
    {
        Rigidbody heldRb = heldObject.GetComponent<Rigidbody>();
        var pickUpObjectScript = heldObject.GetComponent<Scr_PickupP>();
        if (pickUpObjectScript != null)
        {
            pickUpObjectScript.AuxToPlay.clip = pickUpObjectScript.droppedSound;
            pickUpObjectScript.AuxToPlay.volume = 0.05f;
            pickUpObjectScript.AuxToPlay.Play();
            pickUpObjectScript.isHeld = false;
        }

        heldRb.useGravity = true;
        heldRb.drag = 1;
        //heldObject.GetComponent<Scr_PickupP>().isHeld = false;
        heldObject.transform.parent = null;
        heldObject = null;
    }

}
