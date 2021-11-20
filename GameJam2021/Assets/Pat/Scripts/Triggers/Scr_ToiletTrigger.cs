using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_ToiletTrigger : Scr_TriggerParent
{
    private int objCount = 0;

    void Start()
    {
        GetComponent<Renderer>().material.SetColor("_Color", gizmoColorVisible);
    }

    void Update()
    {
        CheckOverlap("Items");
        Debug.Log(objCount);
    }

    public override void CheckOverlap(string value)
    {
        //base.CheckOverlap(value);
        DoEvent();
    }

    public override void DoEvent()
    {
        if (objCount >= 3) Debug.Log("Flush the Zombies"); //else objCount++;
        //ToDo: Stop Zombie coming out of toilet
    }

    public override void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Scr_PickupP>() != null)
        {
            objCount++;
        }

    }

    public override void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Scr_PickupP>() != null)
        {
            objCount--;
        }
    }
}
