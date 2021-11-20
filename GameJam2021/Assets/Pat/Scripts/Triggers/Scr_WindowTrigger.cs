using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_WindowTrigger : Scr_TriggerParent
{

    private Transform tr;
    private Transform trSnapOne;
    private Transform trSnapTwo;
    private Transform trSnapThree;
    private Scr_Plank plank;

    private bool snapOne = false;
    private bool snapTwo = false;
    private bool snapThree = false;

    private bool plankPlaced = false;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        trSnapOne = transform.GetChild(0).GetComponent<Transform>();
        trSnapTwo = transform.GetChild(1).GetComponent<Transform>();
        trSnapThree = transform.GetChild(2).GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckOverlap("Planks");
    }

    public override void DoEvent()
    {
        if (!snapOne && plank.SetInPlace == false)
        {
            plank.GetComponent<Transform>().position = trSnapOne.position;
            snapOne = true;
            SetPlank();
            return;
        }
        if (!snapTwo && plank.SetInPlace == false)
        {
            plank.GetComponent<Transform>().position = trSnapTwo.position;
            snapTwo = true;
            SetPlank();
            return;
        }
        if (!snapThree && plank.SetInPlace == false)
        {
            plank.GetComponent<Transform>().position = trSnapThree.position;
            snapThree = true;
            SetPlank();
            return;
        }
        
    }

    public override void CheckOverlap(string value)
    {
        if(isOverlapped) DoEvent();
    }

    public override void OnTriggerEnter(Collider other)
    {
        
        if(other.GetComponent<Scr_Plank>() != null)
        {
            base.OnTriggerEnter(other);
            isOverlapped = true;
            Freeze(other);
        }
    }

    public void Freeze(Collider other)
    {
        plank = other.GetComponent<Scr_Plank>();
        Debug.Log(plank);
    }

    public void SetPlank()
    {
        plank.GetComponent<Rigidbody>().useGravity = false;
        plank.GetComponent<Rigidbody>().isKinematic = true;
        plank.transform.Rotate(90, 0, 0, Space.World);
        plank.transform.Rotate(0, Random.Range(-10, 10), 0, Space.Self);
        isOverlapped = false;
        plank.SetInPlace = true;

    }
}
