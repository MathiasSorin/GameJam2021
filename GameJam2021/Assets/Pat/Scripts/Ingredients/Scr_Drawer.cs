using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Drawer : Scr_PickupP
{
    public bool isClosed = false;

    public void CompleteObjective()
    {
        isClosed = true;
        Debug.Log(isClosed);

    }

}
