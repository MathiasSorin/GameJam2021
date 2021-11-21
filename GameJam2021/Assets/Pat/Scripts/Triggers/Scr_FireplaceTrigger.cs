using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_FireplaceTrigger : Scr_TriggerParent
{
    public AudioClip gasSound;
    public AudioClip matchSound;
    public AudioClip fireSound;

    private AudioSource aux;
    private bool hasMatches;
    private bool hasGas;
    private bool onFire;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.SetColor("_Color", gizmoColorVisible);
        aux = GetComponent<AudioSource>();
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
        if(hasGas && hasMatches && !onFire)
        {
            Debug.Log("Fire: Bye Zombies");
            //ToDo: Fire Feedback & Sound
            aux.clip = fireSound;
            aux.Play();
            onFire = true;
        }
    }

    public override void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Scr_Gas>() != null)
        {
            hasGas = true;
            aux.clip = gasSound;
            aux.Play();
        }
        if (other.GetComponent<Scr_Matches>() != null)
        {
            aux.clip = matchSound;
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
