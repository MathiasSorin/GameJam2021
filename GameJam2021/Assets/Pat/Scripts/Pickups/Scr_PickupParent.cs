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

    public void DetectPickup(GameObject player)
    {
        Debug.Log("Detect");
    }

    public void Pickup()
    {
        Debug.Log("pickup");
    }

}
