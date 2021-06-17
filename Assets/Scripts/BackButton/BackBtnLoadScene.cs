using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackBtnLoadScene : MonoBehaviour
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
        // Create request popup "Sure to quit game...?"
        // If sure
        SceneManager.LoadScene("Scenes/TopicsAnimalsScene");
        // If not
    }
    public void LoadTopicsAlimentsScene()
    {
        // Create request popup
        SceneManager.LoadScene("Scenes/TopicsAlimentsScene");
    }
    public void LoadTopicsHouseScene()
    {
        // Create request popup
        SceneManager.LoadScene("Scenes/TopicsHouseScene");
    }
    public void LoadTopicsNumberScene()
    {
        // Create request popup
        SceneManager.LoadScene("Scenes/TopicsNumberScene");
    }
}
