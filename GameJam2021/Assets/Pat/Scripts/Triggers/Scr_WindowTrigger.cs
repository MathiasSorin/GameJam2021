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
    private AudioSource aux;
    private bool snapOne = false;
    private bool snapTwo = false;
    private bool snapThree = false;

    private bool plankPlaced = false;
    private bool isBarricaded = false;
    private bool zombiesActive = true;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        trSnapOne = transform.GetChild(0).GetComponent<Transform>();
        trSnapTwo = transform.GetChild(1).GetComponent<Transform>();
        trSnapThree = transform.GetChild(2).GetComponent<Transform>();
        GetComponent<Renderer>().material.SetColor("_Color",gizmoColorVisible);
        aux = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckOverlap("Planks");
        BoardCheck();
    }

    public override void DoEvent()
    {
            if (!snapOne && plank.SetInPlace == false)
            {
                plank.GetComponent<Transform>().position = trSnapOne.position;
                snapOne = true;
                SetPlank();
            sound.PlaySound();
            return;
            }
            if (!snapTwo && plank.SetInPlace == false)
            {
                plank.GetComponent<Transform>().position = trSnapTwo.position;
                snapTwo = true;
                SetPlank();
            sound.PlaySound();
            return;
            }
            if (!snapThree && plank.SetInPlace == false)
            {
                plank.GetComponent<Transform>().position = trSnapThree.position;
                snapThree = true;
                SetPlank();
            isBarricaded = true;
            sound.PlaySound();
            return;
            }


    }

    public override void CheckOverlap(string value)
    {
        if(isOverlapped && plank.isHeld == false) DoEvent();
    }

    public override void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Scr_Plank>() != null)
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
        //plank.SetInPlace = true;
     //plank.transform.Rotate(90, 0, 0, Space.World);
     plank.transform.localEulerAngles = new Vector3(90,0,0); // set the rotation angle of the plank in the window trigger
     plank.transform.Rotate(0, Random.Range(-10, 10), 0, Space.Self);
     isOverlapped = false;
     plank.SetInPlace = true;
     plank.gameObject.tag = "Untagged";
     aux.Play();
    }

    public void BoardCheck()
    {
        if(snapOne && snapTwo && snapThree)
        {
            if (zombiesActive)
            {
            Debug.Log("No More Zombies at the window");
                zombiesActive = false;
                //ToDo: Feedback that Zombies have stopped
            }
        }
    }

    public bool IsBarricaded
    {
        get { return isBarricaded; }
    }

}
