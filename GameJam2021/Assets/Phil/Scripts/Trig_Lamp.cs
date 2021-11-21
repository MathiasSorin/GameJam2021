using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trig_Lamp : MonoBehaviour
{
    public GameObject light1;
    public GameObject light2;
    private bool canBeActivated = true;
    public AudioSource aux;


    private void Start()
    {
        light1.SetActive(false);
        light2.SetActive(false);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            if (canBeActivated)
            {
                LightOn();
            }

        }
    }
        
    public void LightOn()
    {
        aux.Play();
        light1.SetActive(true);
        light1.SetActive(true);
        Invoke("LightOff", 3f);
        canBeActivated = false;

    }

    public void LightOff()
    {
        aux.Play();
        light1.SetActive(false);
        light1.SetActive(false);
        canBeActivated = true;

    }
}
