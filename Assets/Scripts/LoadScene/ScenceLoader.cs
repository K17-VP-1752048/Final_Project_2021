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
    public void LoadVocaAnimalScene()
    {
        SceneManager.LoadScene("Scenes/Vocabulary/Vocabulary_Animal");
    }
    public void LoadVocaFoodScene()
    {
        SceneManager.LoadScene("Scenes/Vocabulary/Vocabulary_Food");
    }
    public void LoadVocaHouseScene()
    {
        SceneManager.LoadScene("Scenes/Vocabulary/Vocabulary_House");
    }
    public void LoadGameSpellAnimal()
    {
        SceneManager.LoadScene("Scenes/Loading/LoadingGameSpellAnimal");
    }
    public void LoadGameSpellFood()
    {
        SceneManager.LoadScene("Scenes/Loading/LoadingGameSpellFood");
    }
    public void LoadGameSpellHouse()
    {
        SceneManager.LoadScene("Scenes/Loading/LoadingGameSpellHousehold");
    }
    public void LoadGameMatch()
    {
        SceneManager.LoadScene("Scenes/Loading/LoadingGameMatch");
    }
    public void LoadGameFind()
    {
        SceneManager.LoadScene("Scenes/Loading/LoadingGameFindFood");
    }
    public void LoadGameCount()
    {
        SceneManager.LoadScene("Scenes/Loading/LoadingGameCountNumber");
    }
    public void LoadGameQuiz()
    {
        SceneManager.LoadScene("Scenes/Loading/LoadingGameQuiz");
    }
}