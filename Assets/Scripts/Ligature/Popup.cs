using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Popup : MonoBehaviour
{
    public void SetPopUpCanvasCorrectWord(string correctWord)
    {
        gameObject.transform.GetChild(0).gameObject.GetComponentInChildren<TextMeshProUGUI>().text = correctWord;
    }
}
