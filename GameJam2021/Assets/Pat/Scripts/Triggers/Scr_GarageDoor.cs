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
    private bool hasBatteries = false;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.SetColor("_Color", gizmoColorVisible);
    }

    // Update is called once per frame
    void Update()
    {
        CheckOverlap("Battery");
    }

    public override void DoEvent()
    {
        if (batteryCount >= 3 && !hasBatteries)
        {
            gameObject.tag = "QuestItem";
            hasBatteries = true;
        }
    }

    public override void CheckOverlap(string value)
    {
        DoEvent();
    }

    /*public override void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Scr_Battery>())
        {
            Destroy(other.gameObject);
            batteryCount++;
            Debug.Log(batteryCount);
        }
    
    }*/

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Scr_Battery>())
        {
            Destroy(collision.gameObject);
            batteryCount++;
            sound.PlaySound();
            //Debug.Log(batteryCount);
        }
    }

}
