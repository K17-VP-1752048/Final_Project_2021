using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoadPlayer : MonoBehaviour
{
    [SerializeField] private Image progressBar;
    [SerializeField] private string valueDefault;
    [SerializeField] private string namePlayerPrefs;

    private void Start()
    {
        StartCoroutine(LoadAsynchronously(PlayerPrefs.GetString(namePlayerPrefs, valueDefault)));
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
