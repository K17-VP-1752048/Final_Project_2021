using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSwitcher : MonoBehaviour
{
    public Sprite imgCheckBox;
    public Sprite imgCheckBoxChecked;

    // Start is called before the first frame update
    void Start()
    {
        // check if Sound is OFF/ON
        if (!KeepSoundPlay.state)
        {
            GetComponent<Image>().sprite = imgCheckBox;
            SetStateForSoundEffect(false);
        }
        else
        {
            GetComponent<Image>().sprite = imgCheckBoxChecked;
        }
    }

    public void TurnOnAndOffSound()
    {
        if (!KeepSoundPlay.state)
        {
            GetComponent<Image>().sprite = imgCheckBoxChecked;
            KeepSoundPlay.state = true;
            SetStateForSoundEffect(true);
        }
        else
        {
            GetComponent<Image>().sprite = imgCheckBox;
            KeepSoundPlay.state = false;
            SetStateForSoundEffect(false);
        }
    }

    //----True is turn on; False is turn off----
    private void SetStateForSoundEffect(bool state)
    {
        AudioSource[] sounds = FindObjectsOfType<AudioSource>();
        foreach (AudioSource s in sounds)
        {
            if (!s.clip.ToString().Equals("bgMusic (UnityEngine.AudioClip)"))
            {
                //Debug.Log("Turn off " + s.clip.ToString());
                s.mute = !state;
            }
        }
    }
}
