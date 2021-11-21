using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Battery : Scr_PickupP, IPickupable
{
    private bool setInPlace = false;
    // Start is called before the first frame update


    public override void Pickup()
    {
        if (!setInPlace) base.Pickup();
    }

    public override void DetectPickup(GameObject player)
    {
        base.DetectPickup(player);
    }

    public bool SetInPlace
    {
        get { return setInPlace; }
        set { setInPlace = value; }
    }
}
