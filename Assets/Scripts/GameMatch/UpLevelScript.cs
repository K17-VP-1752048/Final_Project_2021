using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpLevelScript : MonoBehaviour
{
    private SaveLoadFile slf;
    // Start is called before the first frame update
    void Start()
    {
        //initiate
        slf = gameObject.AddComponent<SaveLoadFile>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && slf.LoadCurrentSceneMatch() != "" && slf.LoadCurrentSceneMatch() != "TopicsAnimalsScene")
        {
            //SceneManager.LoadScene(PlayerPrefs.GetString("nextSceneMatch"));
            SceneManager.LoadScene(slf.LoadCurrentSceneMatch());
        }
        else if (Input.GetMouseButtonDown(0))
        {
            //PlayerPrefs.DeleteKey("nextSceneMatch");
            slf.ResetGameMatch();
            SceneManager.LoadScene("TopicsAnimalsScene");
        }
    }
}
