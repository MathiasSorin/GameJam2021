using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_DoorTrigger : Scr_TriggerParent
{


    void Start()
    {
        
    }

    void Update()
    {
        CheckOverlap("Shelf");
    }

    public override void CheckOverlap(string value)
    {
        base.CheckOverlap(value);
    }

    public override void DoEvent()
    {
        Debug.Log("Do the thing");
        //ToDo: Zombie Sound Stop/Ding Ding sound
    }
}
