using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_JumpscareTrigger : Scr_TriggerParent
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckOverlap("Avatar");
    }

    public override void CheckOverlap(string value)
    {
        base.CheckOverlap(value);
    }

    public override void DoEvent()
    {
        Debug.Log("Boo");
        //ToDo: JumpScare
    }
}
