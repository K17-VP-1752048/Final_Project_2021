using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpLevelScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && PlayerPrefs.GetString("nextSceneMatch") != "")
        {
            SceneManager.LoadScene(PlayerPrefs.GetString("nextSceneMatch"));
        }
        else if (Input.GetMouseButtonDown(0))
        {
            PlayerPrefs.DeleteKey("nextSceneMatch");
            SceneManager.LoadScene("TopicsAnimalsScene");
        }
    }
}
