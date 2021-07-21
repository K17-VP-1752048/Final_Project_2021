using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextSpeech;
using UnityEngine.Android;
using UnityEngine.UI;
using TMPro;

public class VoiceController : MonoBehaviour
{
    const string LANG_CODE = "fr_FR";
    [SerializeField] private TMP_Text resText;
    [SerializeField] private SpellingManager spellingManager;
    [SerializeField] private Button skipBtn;

    private int count = 0;

    void Start()
    {
        Setup(LANG_CODE);
#if UNITY_ANDROID
        SpeechToText.instance.onPartialResultsCallback = OnPartialSpeechResult;
#endif
        SpeechToText.instance.onResultCallback = OnFinalSpeechResult;

        CheckPermission();
    }

    void Update()
    {
        /*if (count >= 3 && spellingManager.GetLength() > 1)
        {
            spellingManager.TimeOut();
            count = 0;
        }
        else if (count >= 3 && spellingManager.GetLength() <= 1)
        {
            spellingManager.EndGame_With_SpellTimeOut();
            count = 0;
        }*/

        if (count >= 3)
        {
            skipBtn.gameObject.SetActive(true); 
        }
    }

    void CheckPermission()
    {
#if UNITY_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            Permission.RequestUserPermission(Permission.Microphone);
        }
#endif
    }

    public void StartPronouce(Image pronounceImg)
    {
        if (KeepSoundPlay.state)
            pronounceImg.GetComponent<AudioSource>().Play();
    }

    public void StartListening()
    {
        if (KeepSoundPlay.state)
            GetComponent<AudioSource>().Play();
        SpeechToText.instance.StartRecording();
    }

    public void StopListening()
    {
        SpeechToText.instance.StopRecording();
    }

    void OnFinalSpeechResult(string result)
    {
        if(result.ToLower() == resText.text.ToLower() && spellingManager.GetLength() > 1)
        {
            spellingManager.NextRound();
            count = 0;
        }
        else if ((result.ToLower() == resText.text.ToLower() && spellingManager.GetLength() <= 1))
        {
            spellingManager.EndGame(true);
            count = 0;
        }
        else
        {
            spellingManager.TryAgain();
        }
        count++;
    }

    void OnPartialSpeechResult(string result)
    {
        if (result.ToLower() == resText.text.ToLower() && spellingManager.GetLength() > 1)
        {
            spellingManager.NextRound();
            count = 0;
        }
        else if ((result.ToLower() == resText.text.ToLower() && spellingManager.GetLength() <= 1))
        {
            spellingManager.EndGame(true);
            count = 0;
        }
        else
        {
            spellingManager.TryAgain();
        }
        count++;
    }

    void Setup(string code)
    {
        SpeechToText.instance.Setting(code);
    }

    public void EventSkipBtn()
    {
        skipBtn.GetComponent<AudioSource>().Play();

        if (spellingManager.GetLength() > 1)
        {
            spellingManager.Skip();
        }
        else if (spellingManager.GetLength() <= 1)
        {
            spellingManager.EndGame(false);
        }

        count = 0;
    }
}
