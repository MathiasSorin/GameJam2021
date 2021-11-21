using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_BedTrigger : Scr_TriggerParent
{

    private bool zombiesUnderBed = true;
    private AudioSource aux;
    public GameObject zombieArms;
    public AudioClip sweepSound;

    private void Start()
    {
        aux = GetComponent<AudioSource>();
    }
    public override void DoEvent()
    {
        if (zombiesUnderBed)
        {
            Destroy(zombieArms);
            zombiesUnderBed = false;
            aux.Stop();
            aux.volume = 1.0f;
            aux.clip = sweepSound;
            aux.loop = false;
            aux.Play();
            sound.PlaySound();
        }
    }

    public override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == obj)
        {
            //ToDo: Stop Sound for Car

            DoEvent();
        }
    }
    public bool ZombiesUnderBed
    {
        get { return zombiesUnderBed; }
    }

}
