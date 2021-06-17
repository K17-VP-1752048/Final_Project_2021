using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenceLoader : MonoBehaviour
{
    public void LoadTopicsScene()
    {
        SceneManager.LoadScene("TopicsScene");
    }
    public void LoadCollectionScene()
    {
        SceneManager.LoadScene("CollectionScene");
    }
    public void LoadMenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }
    public void LoadTopicsAnimalScene()
    {
        SceneManager.LoadScene("TopicsAnimalsScene");
    }
    public void LoadTopicsAlimentsScene()
    {
        SceneManager.LoadScene("TopicsAlimentsScene");
    }
    public void LoadTopicsHouseScene()
    {
        SceneManager.LoadScene("TopicsHouseScene");
    }
    public void LoadTopicsNumberScene()
    {
        SceneManager.LoadScene("TopicsNumberScene");
    }
    public void LoadVocaAnimalScene()
    {
        SceneManager.LoadScene("Vocabulary_Animal");
    }
    public void LoadVocaFoodScene()
    {
        SceneManager.LoadScene("Vocabulary_Food");
    }
    public void LoadVocaHouseScene()
    {
        SceneManager.LoadScene("Vocabulary_House");
    }
    public void LoadGameSpellAnimal()
    {
        SceneManager.LoadScene("LoadingGameSpellAnimal");
    }
    public void LoadGameSpellFood()
    {
        SceneManager.LoadScene("LoadingGameSpellFood");
    }
    public void LoadGameSpellHouse()
    {
        SceneManager.LoadScene("LoadingGameSpellHousehold");
    }
    public void LoadGameMatch()
    {
        SceneManager.LoadScene("LoadingGameMatch");
    }
    public void LoadGameFind()
    {
        SceneManager.LoadScene("LoadingGameFindFood");
    }
    public void LoadGameCount()
    {
        SceneManager.LoadScene("LoadingGameCountNumber");
    }
    public void LoadGameQuiz()
    {
        SceneManager.LoadScene("LoadingGameQuiz");
    }
}