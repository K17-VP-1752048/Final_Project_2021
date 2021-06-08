using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoadFile : MonoBehaviour
{
    private QuizDataScriptable quizData;
    private SpellDataScriptable spellData;

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
    public void SaveCurrentListSpellAnimals(List<Pronunciation> currentList)
    {
        //save current list
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/saveCurrentListSpellAnimals.dat", FileMode.OpenOrCreate);
        List<string> list = new List<string>();
        for (int i = 0; i < currentList.Count; i++)
        {
            list.Add(currentList[i].pronounceText);
        }
        bf.Serialize(file, list);
        file.Close();
    }

    public void SaveCurrentSpellAnimal(Pronunciation pr)
    {
        //save current question
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/saveCurrentSpellAnimal.dat", FileMode.OpenOrCreate);
        string pronounceText = pr.pronounceText;
        bf.Serialize(file, pronounceText);
        file.Close();
    }

    public List<Pronunciation> LoadCurrentListSpellAnimals()
    {
        if (File.Exists(Application.persistentDataPath + "/saveCurrentListSpellAnimals.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/saveCurrentListSpellAnimals.dat", FileMode.OpenOrCreate);

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

    public Pronunciation LoadCurrentSpellAnimal()
    {
        if (File.Exists(Application.persistentDataPath + "/saveCurrentSpellAnimal.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/saveCurrentSpellAnimal.dat", FileMode.OpenOrCreate);
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
        bf.Serialize(file, nameScene);
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
            string res = bf.Deserialize(file) as string;
            file.Close();

            return res;
        }
        return null;
    }

    //save and load current scene of Count game
    public void SaveCurrentSceneCountNumber(string nameScene)
    {
        //save current list
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/saveCurrentSceneCountNumber.dat", FileMode.OpenOrCreate);
        bf.Serialize(file, nameScene);
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
            string res = bf.Deserialize(file) as string;
            file.Close();

            return res;
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
        if (File.Exists(Application.persistentDataPath + "/saveCurrentSpellAnimal.dat"))
        {
            File.Delete(Application.persistentDataPath + "/saveCurrentSpellAnimal.dat");
        }
        if (File.Exists(Application.persistentDataPath + "/saveCurrentListSpellAnimals.dat"))
        {
            File.Delete(Application.persistentDataPath + "/saveCurrentListSpellAnimals.dat");
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
