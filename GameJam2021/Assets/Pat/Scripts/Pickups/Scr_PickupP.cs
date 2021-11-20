using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_PickupP : MonoBehaviour, IPickupable
{
    public bool isHeld = false;
    public string Uiname;
    

    public virtual void Update()
    {
        if (isHeld)
        {
            Debug.Log("im held");
        }

        
    }

    public string IsLookedAt()
    {
        return Uiname;

    }
   
    public virtual void DetectPickup(GameObject player)
    {
        Debug.Log("Detect");

        Pickup();
    }

    public virtual void Pickup()
    {
        if (Input.GetButton("Fire1"))
        {
            Debug.Log("pickup");
            //ToDo: Pickup Item
            //Change

        }
    }

    
}
