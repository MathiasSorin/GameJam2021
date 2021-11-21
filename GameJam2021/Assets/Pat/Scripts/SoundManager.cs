using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource achieve;

    private void Start()
    {
        achieve = GetComponent<AudioSource>();
    }

    public void PlaySound()
    {

        achieve.Play();
    }

}
