using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFindLevel : MonoBehaviour
{
    [SerializeField] GameObject popUp;
    [SerializeField] int currentObjectNumber = 0;
    [SerializeField] int totalObjectNumber;
    [SerializeField] string nextScene = null;
    [SerializeField] float timeWait = 1f;

    private SaveLoadFile saveLoadFile;
    //[SerializeField] string nextScene;

    // Start is called before the first frame update
    void Start()
    {
        saveLoadFile = gameObject.AddComponent<SaveLoadFile>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentObjectNumber == totalObjectNumber && nextScene != null)
        {
            //popUp.SetActive(true);
            //popup.GetComponent<Achievement>().StartAnimations();
            //StartCoroutine("LoadNextScene");

            StartCoroutine(LoadNextScene());
        }
    }

    IEnumerator LoadNextScene()
    {
        SaveCurrentScene();
        popUp.SetActive(true);
        yield return new WaitForSeconds(timeWait);
        SceneManager.LoadScene(nextScene);
    }

    public void Count()
    {
        currentObjectNumber++;
    }

    private void SaveCurrentScene()
    {
        saveLoadFile.SaveCurrentSceneFindFood(nextScene);
    }
}
