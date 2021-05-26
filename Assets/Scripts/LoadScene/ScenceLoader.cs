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
    public void LoadTopicsAnimalScene()
    {
        SceneManager.LoadScene("Scenes/TopicsAnimalsScene");
    }
    public void LoadTopicsAlimentsScene()
    {
        SceneManager.LoadScene("Scenes/TopicsAlimentsScene");
    }
    public void LoadTopicsHouseScene()
    {
        SceneManager.LoadScene("Scenes/TopicsHouseScene");
    }
    public void LoadTopicsNumberScene()
    {
        SceneManager.LoadScene("Scenes/TopicsNumberScene");
    }
}
