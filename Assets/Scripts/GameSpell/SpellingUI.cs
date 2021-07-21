using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SpellingUI : MonoBehaviour
{
    [SerializeField] private TMP_Text pronunciationText;
    [SerializeField] private Image animalImg;
    [SerializeField] private Image speak;
    [SerializeField] private GameObject spellUI;

    private Pronunciation pronunciation;
    // Start is called before the first frame update
    void Start()
    {
        pronunciation = new Pronunciation();
    }

    public void SetPronunciation(Pronunciation pronunciation)
    {
        this.pronunciation                          = pronunciation;

        pronunciationText.text                      = pronunciation.pronounceText;
        speak.GetComponent<AudioSource>().clip      = pronunciation.pronounceAudio;
        animalImg.sprite                            = pronunciation.sprite;
        spellUI.GetComponent<AudioSource>().clip    = pronunciation.audio;
        if (KeepSoundPlay.state)
            spellUI.GetComponent<AudioSource>().Play();
        animalImg.preserveAspect                    = true;
    }
}
