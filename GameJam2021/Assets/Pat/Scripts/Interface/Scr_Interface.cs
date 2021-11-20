using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPickupable
{
    public void DetectPickup(GameObject player);

    public void Pickup();
    
}


