using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoadFile : MonoBehaviour
{
    private QuizDataScriptable quizData;
    private SpellDataScriptable spellData;
    private string nameScene_Match;
    private string nameScene_CountNumber;

    public QuizDataScriptable QuizData { get => quizData; set => quizData = value; }
    public SpellDataScriptable SpellData { get => spellData; set => spellData = value; }

    //save and load quiz game
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

    //save and load spell game
    public void SaveCurrentListSpell(List<Pronunciation> currentList)
    {
        //save current list
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/saveCurrentListSpell.dat", FileMode.OpenOrCreate);
        List<string> list = new List<string>();
        for (int i = 0; i < currentList.Count; i++)
        {
            list.Add(currentList[i].pronounceText);
        }
        bf.Serialize(file, list);
        file.Close();
    }

    public void SaveCurrentSpell(Pronunciation pr)
    {
        //save current question
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/saveCurrentSpell.dat", FileMode.OpenOrCreate);
        string pronounceText = pr.pronounceText;
        bf.Serialize(file, pronounceText);
        file.Close();
    }

    public List<Pronunciation> LoadCurrentListSpell()
    {
        if (File.Exists(Application.persistentDataPath + "/saveCurrentListSpell.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/saveCurrentListSpell.dat", FileMode.OpenOrCreate);

            if (file.Length == 0)
            {
                return null;
            }

            List<string> list = bf.Deserialize(file) as List<string>;
            file.Close();

            List<Pronunciation> listPronounce = new List<Pronunciation>();
            for (int i = 0; i < list.Count; i++)
            {
                Pronunciation result = spellData.pronunciations.Find(x => x.pronounceText == list[i]);
                if (result != null)
                {
                    listPronounce.Add(result);
                }
            }
            return listPronounce;
        }
        return null;
    }

    public Pronunciation LoadCurrentSpell()
    {
        if (File.Exists(Application.persistentDataPath + "/saveCurrentSpell.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/saveCurrentSpell.dat", FileMode.OpenOrCreate);
            if (file.Length == 0)
            {
                return null;
            }
            string p = bf.Deserialize(file) as string;
            file.Close();

            Pronunciation result = spellData.pronunciations.Find(x => x.pronounceText == p);
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

    public void ResetGameQuiz()
    {
        if (File.Exists(Application.persistentDataPath + "/saveCurrentQuestion.dat"))
        {
            File.Delete(Application.persistentDataPath + "/saveCurrentQuestion.dat");
        }
        if (File.Exists(Application.persistentDataPath + "/saveCurrentList.dat"))
        {
            File.Delete(Application.persistentDataPath + "/saveCurrentList.dat");
        }
    }

    public void ResetGameSpell()
    {
        if (File.Exists(Application.persistentDataPath + "/saveCurrentSpell.dat"))
        {
            File.Delete(Application.persistentDataPath + "/saveCurrentSpell.dat");
        }
        if (File.Exists(Application.persistentDataPath + "/saveCurrentListSpell.dat"))
        {
            File.Delete(Application.persistentDataPath + "/saveCurrentListSpell.dat");
        }
    }

    public void ResetGameMatch()
    {
        if (File.Exists(Application.persistentDataPath + "/saveCurrentSceneMatch.dat"))
        {
            File.Delete(Application.persistentDataPath + "/saveCurrentSceneMatch.dat");
        }
    }

    public void ResetGameCountNumber()
    {
        if (File.Exists(Application.persistentDataPath + "/saveCurrentSceneCountNumber.dat"))
        {
            File.Delete(Application.persistentDataPath + "/saveCurrentSceneCountNumber.dat");
        }
    }
}
