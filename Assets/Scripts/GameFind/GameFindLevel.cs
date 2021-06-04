using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFindLevel : MonoBehaviour
{
    [SerializeField] GameObject popup;
    [SerializeField] int currentObjectNumber = 0;
    [SerializeField] int totalObjectNumber;
    //[SerializeField] string nextScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentObjectNumber == totalObjectNumber)
        {
            popup.SetActive(true);
            //StartCoroutine("LoadNextScene");
        }
    }

    /*IEnumerator LoadNextScene()
    {
        popup.SetActive(true);
        yield return new WaitForSeconds(3.2f);
        SceneManager.LoadScene(nextScene);

    }*/

    public void Count()
    {
        currentObjectNumber++;
    }
}
