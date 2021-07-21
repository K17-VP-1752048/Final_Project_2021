using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSoundChecker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // check if Sound is OFF/ON
        if (!KeepSoundPlay.state)
        {
            SetStateForSoundEffect(false);
        }
    }
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
