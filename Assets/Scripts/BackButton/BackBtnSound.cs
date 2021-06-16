using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackBtnSound : MonoBehaviour
{
    public void playSound()
    {
        GetComponent<AudioSource>().Play();
    }
}
