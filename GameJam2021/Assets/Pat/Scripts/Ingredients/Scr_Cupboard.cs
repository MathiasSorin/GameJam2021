using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Cupboard : MonoBehaviour
{
    private bool unlocked = false;
    private bool opened = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(unlocked && !opened)
        {

            UnlockDoor();
            opened = true;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Scr_Keys>())
        {
            Destroy(collision.gameObject);
            unlocked = true;
        }
    }

    private void UnlockDoor()
    {
        Debug.Log("This is where door opens");
        //ToDo: Open Door with Lerp
    }
}
