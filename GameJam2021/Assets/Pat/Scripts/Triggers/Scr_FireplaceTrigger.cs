using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Scr_FireplaceTrigger : Scr_TriggerParent
{
    public AudioClip gasSound;
    public AudioClip matchSound;
    public AudioClip fireSound;

    private AudioSource aux;
    private bool hasMatches;
    private bool hasGas;
    private bool onFire;

    private Transform fireSpot;

    public GameObject fire;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.SetColor("_Color", gizmoColorVisible);
        fireSpot = gameObject.transform.GetChild(0).GetComponent<Transform>();
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
            Instantiate(fire, fireSpot);
            fire.GetComponent<ParticleSystem>().Play();
            aux.clip = fireSound;
            aux.Play();
            onFire = true;
            sound.PlaySound();
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
            aux.Play();
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
