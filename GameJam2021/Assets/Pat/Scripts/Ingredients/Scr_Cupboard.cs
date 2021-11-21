using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Cupboard : MonoBehaviour
{
    private bool unlocked = false;
    private bool opened = false;
    private Animator anim;
    public SoundManager sound;
    void Start()
    {
        anim = GetComponent<Animator>();
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
            //Destroy(collision.gameObject);
            unlocked = true;
        }
    }

    private void UnlockDoor()
    {
        Debug.Log("This is where door opens");
        //ToDo: Open Door with Lerp
        anim.Play("OpenDoor", 0,0.0f);
        sound.PlaySound();
        //gameObject.SetActive(false);
    }
}
