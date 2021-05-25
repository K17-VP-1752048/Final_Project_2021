using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSwitcher : MonoBehaviour
{
    public Sprite imgCheckBox;
    public Sprite imgCheckBoxChecked;

    private GameObject backgroundMusic;

    // Start is called before the first frame update
    void Start()
    {
        backgroundMusic = GameObject.Find("BackgroundAudio");

        AudioSource audioSource = backgroundMusic.GetComponent<AudioSource>();
        if (audioSource.mute)
        {
            GetComponent<Image>().sprite = imgCheckBox;
        }
        else
        {
            GetComponent<Image>().sprite = imgCheckBoxChecked;
        }
    }

    public void TurnOnAndOffMusic()
    {
        AudioSource audioSource = backgroundMusic.GetComponent<AudioSource>();

        if (audioSource.mute)
        {
            GetComponent<Image>().sprite = imgCheckBoxChecked;
            audioSource.mute = false;
        }
        else
        {
            GetComponent<Image>().sprite = imgCheckBox;
            audioSource.mute = true;
        }
    }
}
