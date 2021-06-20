using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpellingManager : MonoBehaviour
{
    [SerializeField] private SpellingUI spellUI;
    [SerializeField] private SpellDataScriptable spellData;
    [SerializeField] private SpellFoodDataScriptable spellFoodData;
    [SerializeField] private SpellHouseholdDataScriptable spellHouseholdData;
    [SerializeField] private AudioClip bravo_audio;
    [SerializeField] private AudioClip fail_audio;
    [SerializeField] private GameObject[] congrats;
    [SerializeField] private GameObject congratEndGame;
    [SerializeField] private GameObject popupWrong;
    [SerializeField] private GameObject popupTimeOut;
    [SerializeField] private string selectedTopic;

    private List<Pronunciation> pronunciations;
    private Pronunciation selectedPronunciation;
    private SaveLoadFile slf;
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        slf = gameObject.AddComponent<SaveLoadFile>();
        if(selectedTopic == "Animals")
        {
            SpellAnimal();
        }
        else if (selectedTopic == "Food")
        {
            SpellFood();
        }
        else if (selectedTopic == "Household")
        {
            SpellHousehold();
        }
    }

    public void SpellAnimal()
    {
        slf.SpellData = spellData;
        List<Pronunciation> list = slf.LoadCurrentListSpellAnimals();
        Pronunciation p = slf.LoadCurrentSpellAnimal();

        if (list == null)
        {
            pronunciations = new List<Pronunciation>(slf.SpellData.pronunciations);
        }
        else
        {
            pronunciations = list;
        }
        if (p == null)
        {
            SelectPronunciation();
        }
        else
        {
            spellUI.SetPronunciation(p);
            this.index = pronunciations.IndexOf(p);
        }
    }

    public void SpellFood()
    {
        slf.SpellFoodData = spellFoodData;
        List<Pronunciation> list = slf.LoadCurrentListSpellFood();
        Pronunciation p = slf.LoadCurrentSpellFood();

        if (list == null)
        {
            pronunciations = new List<Pronunciation>(slf.SpellFoodData.pronunciations);
        }
        else
        {
            pronunciations = list;
        }
        if (p == null)
        {
            SelectPronunciation();
        }
        else
        {
            spellUI.SetPronunciation(p);
            this.index = pronunciations.IndexOf(p);
        }
    }

    public void SpellHousehold()
    {
        slf.SpellHouseholdData = spellHouseholdData;
        List<Pronunciation> list = slf.LoadCurrentListSpellHousehold();
        Pronunciation p = slf.LoadCurrentSpellHousehold();

        if (list == null)
        {
            pronunciations = new List<Pronunciation>(slf.SpellHouseholdData.pronunciations);
        }
        else
        {
            pronunciations = list;
        }
        if (p == null)
        {
            SelectPronunciation();
        }
        else
        {
            spellUI.SetPronunciation(p);
            this.index = pronunciations.IndexOf(p);
        }
    }

    void SelectPronunciation()
    {
        if (selectedTopic == "Animals")
        {
            if (pronunciations.Count <= 0)
            {
                slf.ResetCurrentSpell_Animals();
                slf.ResetCurrentListSpell_Animals();
                StartCoroutine(BackTopic(3f));
            }
            else
            {
                int val = Random.Range(0, pronunciations.Count);
                selectedPronunciation = pronunciations[val];
                this.index = val;
                spellUI.SetPronunciation(selectedPronunciation);
                slf.SaveCurrentSpellAnimal(selectedPronunciation);
            }
        }
        else if (selectedTopic == "Food")
        {
            if (pronunciations.Count <= 0)
            {
                slf.ResetCurrentSpell_Food();
                slf.ResetCurrentListSpell_Food();
                StartCoroutine(BackTopic(3f));
            }
            else
            {
                int val = Random.Range(0, pronunciations.Count);
                selectedPronunciation = pronunciations[val];
                this.index = val;
                spellUI.SetPronunciation(selectedPronunciation);
                slf.SaveCurrentSpellFood(selectedPronunciation);
            }
        }
        else if (selectedTopic == "Household")
        {
            if (pronunciations.Count <= 0)
            {
                slf.ResetCurrentSpell_House();
                slf.ResetCurrentListSpell_House();
                StartCoroutine(BackTopic(3f));
            }
            else
            {
                int val = Random.Range(0, pronunciations.Count);
                selectedPronunciation = pronunciations[val];
                this.index = val;
                spellUI.SetPronunciation(selectedPronunciation);
                slf.SaveCurrentSpellHousehold(selectedPronunciation);
            }
        }
    }

    public int GetLength()
    {
        return pronunciations.Count;
    }

    public void NextRound()
    {
        //remove after spell correct
        pronunciations.RemoveAt(this.index);

        //save current list
        if (selectedTopic == "Animals")
        {
            slf.ResetCurrentSpell_Animals();
            slf.SaveCurrentListSpellAnimals(pronunciations);
        }
        else if (selectedTopic == "Food")
        {
            slf.ResetCurrentSpell_Food();
            slf.SaveCurrentListSpellFood(pronunciations);
        }
        else if (selectedTopic == "Household")
        {
            slf.ResetCurrentSpell_House();
            slf.SaveCurrentListSpellHousehold(pronunciations);
        }

        //random popup congratulation
        int val = Random.Range(0, congrats.Length);
        GameObject obj = Instantiate(congrats[val]);
        obj.transform.SetParent(spellUI.transform, false);

        gameObject.GetComponent<AudioSource>().clip = bravo_audio;
        gameObject.GetComponent<AudioSource>().Play();
        Invoke("SelectPronunciation", gameObject.GetComponent<AudioSource>().clip.length + 0.1f);
    }

    public void TimeOut()
    {
        //reset game
        if (selectedTopic == "Animals")
        {
            slf.ResetCurrentSpell_Animals();
            slf.ResetCurrentListSpell_Animals();
        }
        else if (selectedTopic == "Food")
        {
            slf.ResetCurrentSpell_Food();
            slf.ResetCurrentListSpell_Food();
        }
        else if (selectedTopic == "Household")
        {
            slf.ResetCurrentSpell_House();
            slf.ResetCurrentListSpell_House();
        }

        GameObject obj = Instantiate(popupTimeOut);
        obj.transform.SetParent(spellUI.transform, false);

        gameObject.GetComponent<AudioSource>().clip = fail_audio;
        gameObject.GetComponent<AudioSource>().Play();
        Invoke("SelectPronunciation", gameObject.GetComponent<AudioSource>().clip.length + 0.3f);
    }

    public void TryAgain()
    {
        GameObject obj = Instantiate(popupWrong);
        obj.transform.SetParent(spellUI.transform, false);

        gameObject.GetComponent<AudioSource>().clip = fail_audio;
        gameObject.GetComponent<AudioSource>().Play();
    }

    public void EndGame_With_SpellTimeOut()
    {
        //reset game
        if (selectedTopic == "Animals")
        {
            slf.ResetCurrentSpell_Animals();
            slf.ResetCurrentListSpell_Animals();
        }
        else if (selectedTopic == "Food")
        {
            slf.ResetCurrentSpell_Food();
            slf.ResetCurrentListSpell_Food();
        }
        else if (selectedTopic == "Household")
        {
            slf.ResetCurrentSpell_House();
            slf.ResetCurrentListSpell_House();
        }

        GameObject obj = Instantiate(popupTimeOut);
        obj.transform.SetParent(spellUI.transform, false);

        gameObject.GetComponent<AudioSource>().clip = fail_audio;
        gameObject.GetComponent<AudioSource>().Play();

        StartCoroutine(BackTopic(gameObject.GetComponent<AudioSource>().clip.length + 0.3f));
    }

    public void EndGame()
    {
        //reset game
        if (selectedTopic == "Animals")
        {
            slf.ResetCurrentSpell_Animals();
            slf.ResetCurrentListSpell_Animals();
        }
        else if (selectedTopic == "Food")
        {
            slf.ResetCurrentSpell_Food();
            slf.ResetCurrentListSpell_Food();
        }
        else if (selectedTopic == "Household")
        {
            slf.ResetCurrentSpell_House();
            slf.ResetCurrentListSpell_House();
        }

        //random popup congratulation
        int val = Random.Range(0, congrats.Length);
        GameObject obj = Instantiate(congrats[val]);
        obj.transform.SetParent(spellUI.transform, false);

        gameObject.GetComponent<AudioSource>().clip = bravo_audio;
        gameObject.GetComponent<AudioSource>().Play();

        StartCoroutine(BackTopic(gameObject.GetComponent<AudioSource>().clip.length + 0.1f));
    }



    IEnumerator BackTopic(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        GameObject obj = Instantiate(congratEndGame);
        obj.transform.SetParent(spellUI.transform, false);

        gameObject.GetComponent<AudioSource>().clip = bravo_audio;
        gameObject.GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(delayTime);
        SceneManager.LoadScene("TopicsAnimalsScene");
    }
}

[System.Serializable]
public class Pronunciation
{
    public string pronounceText;
    public AudioClip pronounceAudio;
    public AudioClip audio;
    public Sprite sprite;
}
