using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Cup : Scr_PickupP, IPickupable
{
    //Trans
    /*public void DetectPickup(GameObject player)
    {
        Debug.Log("Detect");
    }*/

    public override void Pickup()
    {
        base.Pickup();
    }

    public override void DetectPickup(GameObject player)
    {
        //base.DetectPickup(player);
        Debug.Log("Potato");
    }

}
