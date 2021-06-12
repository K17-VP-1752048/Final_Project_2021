﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    private Image progressBar;
    [SerializeField] private string sceneAddress;
    
    private void Start()
    {
        progressBar = GameObject.Find("Progress Bar").GetComponent<Image>();
        StartCoroutine(LoadAsynchronously(sceneAddress));
    }

    IEnumerator LoadAsynchronously(string nameScene)
    {
        yield return new WaitForSeconds(0.5f);
        progressBar.fillAmount = 0.5f;
        yield return new WaitForSeconds(0.5f);
        AsyncOperation operation = SceneManager.LoadSceneAsync(nameScene);
        while (!operation.isDone)
        {
            //progressBar.fillAmount = operation.progress;
            progressBar.fillAmount = 1;

            yield return null;
        }
    }
}
