using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_TriggerParent : MonoBehaviour
{
    public GameObject obj;
    protected bool isOverlapped;
    public Color gizmoColor;

    protected bool triggered;

    void Start()
    {
        
    }

    private void Update()
    {
        CheckOverlap("test");
    }

    public virtual void CheckOverlap(string value)
    {
        if (isOverlapped)
        {
            if (triggered)
            {
                //Here an event will be called, if no event is overidden, a string will be printed

                
                //Debug.Log(value);
                //ToDo:
                DoEvent();
                //ToDo: Set a case where it triggers another object
                triggered = false;
            }

        }

    }

    private void OnDrawGizmos()
    {
        gizmoColor.a = 1.0f; 
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireCube(transform.position, transform.localScale);

    }

   public virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == obj)
        {
            triggered = true;
            isOverlapped = true;
        }
    }

    public virtual void OnTriggerExit(Collider other)
    {
        if (other.gameObject == obj)
        {
            isOverlapped = false;
        }
    }

    public virtual void DoEvent()
    {
        Debug.LogError("WHAT IS THE OVERIDE EVENT");
    }
}
