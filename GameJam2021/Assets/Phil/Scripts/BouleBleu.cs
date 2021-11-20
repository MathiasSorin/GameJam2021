using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouleBleu : MonoBehaviour, IPickupable
{
    
    public void Start()
    {
               
    }
    public void DetectPickup(GameObject player)
    {
        //Feedback visuel


        Debug.Log("Detect");

        Pickup();
    }

    public void Pickup()
    {
        if (Input.GetButton("Fire1"))
        {
            Debug.Log("pickup");
        }
    }
}
