using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_ToiletTrigger : Scr_TriggerParent
{
    private int objCount;

    void Start()
    {
        
    }

    void Update()
    {
        CheckOverlap("Items");
    }

    public override void CheckOverlap(string value)
    {
        base.CheckOverlap(value);
    }

    public override void DoEvent()
    {
        if (objCount >= 3) Debug.Log("Do the thing"); else objCount++;
        //ToDo: Stop Zombie coming out of toilet
    }

    public override void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Scr_PickupParent>() != null)
        {
            Debug.Log(other);
            obj = other.gameObject;
            triggered = true;
            isOverlapped = true;
        }

    }

    public override void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Scr_PickupParent>() != null)
        {
            Debug.Log(other);
            isOverlapped = false;
        }
    }
}
