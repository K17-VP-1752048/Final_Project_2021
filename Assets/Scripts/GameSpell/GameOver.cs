using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    [SerializeField] private string topic, loadingScene;
    [SerializeField] private TMP_Text numberofskips;

    private void Start()
    {
        numberofskips.text = SpellingManager.numberofskips;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(loadingScene);
    }

    public void BackTopic()
    {
        SceneManager.LoadScene(topic);
    }
}
