using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    AudioSource gameMusic;

    private void Start()
    {
        gameMusic = GameObject.Find("BackgroundAudio").GetComponent<AudioSource>();
        if(!gameMusic.isPlaying)
        {
            gameMusic.Play();
        }
    }
}
