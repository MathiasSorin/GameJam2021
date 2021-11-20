using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_WindowTrigger : Scr_TriggerParent
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckOverlap("Planks");
    }

    public override void CheckOverlap(string value)
    {
        base.CheckOverlap(value);
    }

    public override void DoEvent()
    {
        //ToDo: Snap Planks to window
    }
}
