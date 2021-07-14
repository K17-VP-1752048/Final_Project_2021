using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    private Image progressBar;
    private AudioSource bgMusic;
    [SerializeField] private string sceneAddress;
    
    private void Start()
    {
        progressBar = transform.GetChild(0).Find("Progress Bar").GetComponent<Image>();
        bgMusic = GameObject.Find("BackgroundAudio").GetComponent<AudioSource>();
        bgMusic.mute = true;

        StartCoroutine(LoadAsynchronously(sceneAddress));
    }

    IEnumerator LoadAsynchronously(string nameScene)
    {
        yield return new WaitForSeconds(.5f);
        progressBar.fillAmount = 0.2f;
        yield return new WaitForSeconds(.5f);
        progressBar.fillAmount = 0.4f;
        yield return new WaitForSeconds(.5f);
        progressBar.fillAmount = 0.6f;
        yield return new WaitForSeconds(.5f);
        progressBar.fillAmount = 0.9f;
        yield return new WaitForSeconds(1f);
        AsyncOperation operation = SceneManager.LoadSceneAsync(nameScene);
        while (!operation.isDone)
        {
            //progressBar.fillAmount = operation.progress;
            progressBar.fillAmount = 1;
            bgMusic.mute = false;

            yield return null;
        }
    }
}
