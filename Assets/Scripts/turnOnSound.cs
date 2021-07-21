using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnOnSound : MonoBehaviour
{
    // Update is called once per frame
    public void turnOn()
    {
        if(KeepSoundPlay.state)
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
