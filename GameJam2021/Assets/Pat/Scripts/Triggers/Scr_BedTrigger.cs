using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_BedTrigger : Scr_TriggerParent
{

    private bool zombiesUnderBed = true;
    private AudioSource aux;
    public GameObject zombieArms;

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
