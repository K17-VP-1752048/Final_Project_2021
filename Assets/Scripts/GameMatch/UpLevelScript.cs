using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpLevelScript : MonoBehaviour
{
    [SerializeField] private string nextScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && nextScene != "")
        {
            SceneManager.LoadScene(nextScene);
        }
        else if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("TopicsAnimalsScene");
        }
    }
}
