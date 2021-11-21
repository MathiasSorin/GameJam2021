using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_GarageTrigger : Scr_TriggerParent
{

    private bool alarmOn = true;
    private AudioSource aux;

    private void Start()
    {
        aux = GetComponent<AudioSource>();
    }
    public override void DoEvent()
    {
        if (alarmOn)
        {
            Debug.Log("Beep");
            alarmOn = false;
            aux.Stop();
        }
    }

    public override void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Scr_Remote>() != null)
        {
            //ToDo: Stop Sound for Car
            
            DoEvent();
        }
    }
}
