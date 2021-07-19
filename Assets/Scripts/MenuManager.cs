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

    //For trophies tutorial
    public void onPressTrophy(GameObject tutorialPanel)
    {
        tutorialPanel.SetActive(true);
    }

    //For trophies tutorial
    public void onReleaseTrophy(GameObject tutorialPanel)
    {
        tutorialPanel.SetActive(false);
    }
}