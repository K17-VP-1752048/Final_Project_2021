using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextSpeech;
using UnityEngine.Android;
using UnityEngine.SceneManagement;
using TMPro;

public class VoiceController : MonoBehaviour
{
    const string LANG_CODE = "fr_FR";
    [SerializeField] TMP_Text resText;

    void Start()
    {
        Setup(LANG_CODE);

#if UNITY_ANDROID
        SpeechToText.instance.onPartialResultsCallback = OnPartialSpeechResult;
#endif
        SpeechToText.instance.onResultCallback = OnFinalSpeechResult;

        CheckPermission();
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

    public void StartPronouce()
    {
        GetComponent<AudioSource>().Play();
    }

    public void StartListening()
    {
        SpeechToText.instance.StartRecording();
    }

    public void StopListening()
    {
        SpeechToText.instance.StopRecording();
    }

    void OnFinalSpeechResult(string result)
    {
        if(result.ToLower() == resText.text.ToLower())
        {
            SceneManager.LoadScene("WinScene");
        }
    }
    void OnPartialSpeechResult(string result)
    {
        if (result.ToLower() == resText.text.ToLower())
        {
            SceneManager.LoadScene("WinScene");
        }
    }

    void Setup(string code)
    {
        SpeechToText.instance.Setting(code);
    }
}
