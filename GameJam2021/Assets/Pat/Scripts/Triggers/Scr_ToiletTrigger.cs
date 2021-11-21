using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_ToiletTrigger : Scr_TriggerParent
{
    private int objCount = 0;
    private bool isClogged = false;
    public AudioClip flushSound;
    private AudioSource aux;
    public GameObject zombieHand;

    void Start()
    {
        GetComponent<Renderer>().material.SetColor("_Color", gizmoColorVisible);
        aux = GetComponent<AudioSource>();
    }

    void Update()
    {
        CheckOverlap("Items");
    }

    public override void CheckOverlap(string value)
    {
        //base.CheckOverlap(value);
        DoEvent();
    }

    public override void DoEvent()
    {
        if (objCount >= 3 && !isClogged)
        {
            isClogged = true;
            Debug.Log("Flush the Zombies"); //else objCount++;
            //ToDo: Stop Zombie coming out of toilet
            aux.Play();
            Destroy(zombieHand);
            
        }
    }

    public override void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Scr_PickupP>() != null)
        {
            objCount++;
            sound.PlaySound();
        }

    }

    public override void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Scr_PickupP>() != null)
        {
            objCount--;
        }
    }

    public override void OnDrawGizmos()
    {
        gizmoColor.a = 1.0f;
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireCube(transform.position, gameObject.GetComponent<BoxCollider>().size);
    }
}
