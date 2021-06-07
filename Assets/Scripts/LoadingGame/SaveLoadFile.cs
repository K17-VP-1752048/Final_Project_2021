using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoadFile : MonoBehaviour
{
    private QuizDataScriptable quizData;
    private string nameScene_Match;
    private string nameScene_CountNumber;

    public QuizDataScriptable QuizData { get => quizData; set => quizData = value; }

    //save and load game quiz
    public void SaveCurrentList(List<Question> currentList)
    {
        //save current list
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/saveCurrentList.dat", FileMode.OpenOrCreate);
        List<string> list = new List<string>();
        for (int i = 0; i < currentList.Count; i++)
        {
            list.Add(currentList[i].questionInfo);
        }
        bf.Serialize(file, list);
        file.Close();
    }

    public void SaveCurrentQuestion(Question currentQuestion)
    {
        //save current question
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/saveCurrentQuestion.dat", FileMode.OpenOrCreate);
        string questionInfo = currentQuestion.questionInfo;
        bf.Serialize(file, questionInfo);
        file.Close();
    }

    public List<Question> LoadCurrentList()
    {
        if(File.Exists(Application.persistentDataPath + "/saveCurrentList.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/saveCurrentList.dat", FileMode.OpenOrCreate);

            if (file.Length == 0)
            {
                return null;
            }

            List<string> list = bf.Deserialize(file) as List<string>;
            file.Close();

            List<Question> listQuestion = new List<Question>();
            for(int i = 0; i < list.Count; i++)
            {
                Question result = quizData.questions.Find(x => x.questionInfo == list[i]);
                if (result != null)
                {
                    listQuestion.Add(result);
                }
            }
            return listQuestion;
        }
        return null;
    }

    public Question LoadCurrentQuestion()
    {
        if (File.Exists(Application.persistentDataPath + "/saveCurrentQuestion.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/saveCurrentQuestion.dat", FileMode.OpenOrCreate);
            if(file.Length == 0)
            {
                return null;
            }
            string q = bf.Deserialize(file) as string;
            file.Close();

            Question result = quizData.questions.Find(x => x.questionInfo == q);
            if (result != null)
            {
                return result;
            }
        }
        return null;
    }

    //save and load current scene of Match game
    public void SaveCurrentSceneMatch(string nameScene)
    {
        //save current list
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/saveCurrentSceneMatch.dat", FileMode.OpenOrCreate);
        nameScene_Match = nameScene;
        bf.Serialize(file, nameScene_Match);
        file.Close();
    }

    public string LoadCurrentSceneMatch()
    {
        if (File.Exists(Application.persistentDataPath + "/saveCurrentSceneMatch.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/saveCurrentSceneMatch.dat", FileMode.OpenOrCreate);
            if (file.Length == 0)
            {
                return null;
            }
            nameScene_Match = bf.Deserialize(file) as string;
            file.Close();

            return nameScene_Match;
        }
        return null;
    }

    //save and load current scene of Count game
    public void SaveCurrentSceneCountNumber(string nameScene)
    {
        //save current list
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/saveCurrentSceneCountNumber.dat", FileMode.OpenOrCreate);
        nameScene_CountNumber = nameScene;
        bf.Serialize(file, nameScene_CountNumber);
        file.Close();
    }

    public string LoadCurrentSceneCountNumber()
    {
        if (File.Exists(Application.persistentDataPath + "/saveCurrentSceneCountNumber.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/saveCurrentSceneCountNumber.dat", FileMode.OpenOrCreate);
            if (file.Length == 0)
            {
                return null;
            }
            nameScene_CountNumber = bf.Deserialize(file) as string;
            file.Close();

            return nameScene_CountNumber;
        }
        return null;
    }

    public void ResetGame()
    {
        if (File.Exists(Application.persistentDataPath + "/saveCurrentQuestion.dat"))
        {
            File.Delete(Application.persistentDataPath + "/saveCurrentQuestion.dat");
        }
        if (File.Exists(Application.persistentDataPath + "/saveCurrentList.dat"))
        {
            File.Delete(Application.persistentDataPath + "/saveCurrentList.dat");
        }
        if (File.Exists(Application.persistentDataPath + "/saveCurrentSceneMatch.dat"))
        {
            File.Delete(Application.persistentDataPath + "/saveCurrentSceneMatch.dat");
        }
        if (File.Exists(Application.persistentDataPath + "/saveCurrentSceneCountNumber.dat"))
        {
            File.Delete(Application.persistentDataPath + "/saveCurrentSceneCountNumber.dat");
        }
    }
}
