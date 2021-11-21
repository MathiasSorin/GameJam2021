using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_DoorTrigger : Scr_TriggerParent
{
    private bool isBlocked = false;

    void Start()
    {
        GetComponent<Renderer>().material.SetColor("_Color", gizmoColorVisible);
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
        //base.DoEvent();
        //ToDo: Zombie Sound Stop/Ding Ding sound
        Debug.Log("No More Zombies at the door");
        obj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        sound.PlaySound();
    }


    public bool IsBlocked
    {
        get { return isBlocked; }
    }
}
