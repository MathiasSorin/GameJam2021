using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Cup : MonoBehaviour, IPickupable
{
    //Trans
    public void DetectPickup(GameObject player)
    {
        Debug.Log("Detect");
    }

    public void Update()
    {
        if (Input.GetButton("Fire1"))
        {

            
        }
    }
    public void Pickup()
    {
        Debug.Log("pickup");
    }
}
