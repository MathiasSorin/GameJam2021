using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_FireplaceTrigger : Scr_TriggerParent
{

    private bool hasMatches;
    private bool hasGas;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.SetColor("_Color", gizmoColorVisible);
    }

    // Update is called once per frame
    void Update()
    {
        CheckOverlap("help");
    }

    public override void CheckOverlap(string value)
    {
        DoEvent();
    }

    public override void DoEvent()
    {
        if(hasGas && hasMatches)
        {
            Debug.Log("Fire: Bye Zombies");
            //ToDo: Fire Feedback & Sound
        }
    }

    public override void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Scr_Gas>() != null)
        {
            hasGas = true;
        }
        if (other.GetComponent<Scr_Matches>() != null)
        {
            hasMatches = true;
        }
    }
    public override void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Scr_Gas>() != null)
        {
            hasGas = false;
        }
        if (other.GetComponent<Scr_Matches>() != null)
        {
            hasMatches = false;
        }
    }
}
