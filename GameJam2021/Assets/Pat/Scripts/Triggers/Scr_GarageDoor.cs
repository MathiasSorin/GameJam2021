using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_GarageDoor : Scr_TriggerParent
{

    private Transform tr;
    private Transform trSnapOne;
    private Transform trSnapTwo;
    private Transform trSnapThree;
    private Scr_Battery battery;

    private bool snapOne = false;
    private bool snapTwo = false;
    private bool snapThree = false;

    private bool zombiesActive = true;

    private int batteryCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        trSnapOne = transform.GetChild(0).GetComponent<Transform>();
        trSnapTwo = transform.GetChild(1).GetComponent<Transform>();
        trSnapThree = transform.GetChild(2).GetComponent<Transform>();
        GetComponent<Renderer>().material.SetColor("_Color", gizmoColorVisible);
    }

    // Update is called once per frame
    void Update()
    {
        CheckOverlap("Battery");
    }

    public override void DoEvent()
    {

    }

    public override void CheckOverlap(string value)
    {
        if (isOverlapped /*&& plank.isHeld == false*/) DoEvent();
    }

    public override void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Scr_Battery>())
        {
            Destroy(other.gameObject);
            batteryCount++;
            Debug.Log(batteryCount);
        }
    }


}
