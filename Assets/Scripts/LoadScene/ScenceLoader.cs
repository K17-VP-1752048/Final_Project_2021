using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenceLoader : MonoBehaviour
{
    public void LoadTopicsScene()
    {
        SceneManager.LoadScene("Scenes/TopicsScene");
    }
    public void LoadCollectionScene()
    {
        SceneManager.LoadScene("Scenes/CollectionScene");
    }
    public void LoadMenuScene()
    {
        SceneManager.LoadScene("Scenes/MenuScene");
    }
}
