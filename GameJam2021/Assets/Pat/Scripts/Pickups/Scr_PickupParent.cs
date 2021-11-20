using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_PickupParent : MonoBehaviour, IPickupable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        }
    }

}
