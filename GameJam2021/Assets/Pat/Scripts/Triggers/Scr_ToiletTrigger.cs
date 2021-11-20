using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_ToiletTrigger : Scr_TriggerParent
{


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
        Debug.Log("Do the thing");
        //ToDo: Stop Zombie coming out of toilet
    }
}
