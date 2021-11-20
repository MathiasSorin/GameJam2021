using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_WindowTrigger : Scr_TriggerParent
{

    private Transform tr;
    private Transform trSnapOne;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        trSnapOne = GetComponentInChildren<Transform>();
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
        Debug.Log("Snap Plank to Window");
        //ToDo: Snap Planks to window
        obj.transform.position = trSnapOne.position;
        obj.GetComponent<Rigidbody>().isKinematic = true;
        obj.GetComponent<Rigidbody>().useGravity = false;
    }
}
