﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SpellingManager : MonoBehaviour
{
    [SerializeField] private SpellingUI spellUI;
    [SerializeField] private SpellDataScriptable spellData;
    [SerializeField] private SpellFoodDataScriptable spellFoodData;
    [SerializeField] private SpellHouseholdDataScriptable spellHouseholdData;
    [SerializeField] private AudioClip bravo_audio;
    [SerializeField] private AudioClip fail_audio;
    [SerializeField] private GameObject popUpCheeringCanvas;
    [SerializeField] private GameObject gameWinCanvas;
    [SerializeField] private GameObject getKeyRewardCanvas;
    [SerializeField] private float timeTransition = 4f;
    [SerializeField] private GameObject popupWrong;
    [SerializeField] private GameObject popupTimeOut;
    [SerializeField] private string selectedTopic;
    [SerializeField] private Image pronounceImg, speakImg;
    [SerializeField] private Button backBtn, skipBtn;
    [SerializeField] private GameObject NotCompleted;

    private List<Pronunciation> pronunciations;
    private Pronunciation selectedPronunciation;
    private SaveLoadFile slf;
    private int index;
    private bool finished = false;
    public static string numberofskips;

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

        SetEnabled(true);
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
        SetEnabled(true);

        if (selectedTopic == "Animals")
        {
            if (pronunciations.Count <= 0)
            {
                slf.ResetCurrentSpell_Animals();
                slf.ResetCurrentListSpell_Animals();
                //StartCoroutine(BackTopic(3f));
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
                //StartCoroutine(BackTopic(3f));
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
                //StartCoroutine(BackTopic(3f));
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
        skipBtn.gameObject.SetActive(false);
    }

    public int GetLength()
    {
        return pronunciations.Count;
    }

    public void NextRound()
    {
        SetEnabled(false);

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
        //int val = Random.Range(0, congrats.Length);
        //GameObject obj = Instantiate(congrats[val]);
        //obj.transform.SetParent(spellUI.transform, false);

        int val = Random.Range(0, popUpCheeringCanvas.transform.childCount);
        popUpCheeringCanvas.transform.GetChild(val).gameObject.SetActive(true);

        gameObject.GetComponent<AudioSource>().clip = bravo_audio;
        gameObject.GetComponent<AudioSource>().Play();
        StartCoroutine(ShowPopupCheering(val));
        Invoke("SelectPronunciation", 1.5f);
    }

    IEnumerator ShowPopupCheering(int val)
    {
        yield return new WaitForSeconds(1f);
        popUpCheeringCanvas.transform.GetChild(val).gameObject.SetActive(false);
    }


    public void Skip()
    {
        SetEnabled(false);

        //remove after spell correct
        pronunciations.RemoveAt(this.index);

        //reset game
        if (selectedTopic == "Animals")
        {
            slf.ResetCurrentSpell_Animals();
            slf.SaveCurrentListSpellAnimals(pronunciations);
            slf.SaveNumberOfSkipsGameSpell("Animals");
        }
        else if (selectedTopic == "Food")
        {
            slf.ResetCurrentSpell_House();
            slf.SaveCurrentListSpellHousehold(pronunciations);
            slf.SaveNumberOfSkipsGameSpell("Food");
        }
        else if (selectedTopic == "Household")
        {
            slf.ResetCurrentSpell_House();
            slf.SaveCurrentListSpellHousehold(pronunciations);
            slf.SaveNumberOfSkipsGameSpell("Household");
        }

        Invoke("SelectPronunciation", 1f);
    }

    public void TryAgain()
    {
        SetEnabled(false);
        GameObject obj = Instantiate(popupWrong);
        obj.transform.SetParent(spellUI.transform, false);

        gameObject.GetComponent<AudioSource>().clip = fail_audio;
        gameObject.GetComponent<AudioSource>().Play();
        StartCoroutine(DestroyPopup(obj));
    }

    IEnumerator DestroyPopup(GameObject obj)
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(obj);
        SetEnabled(true);
    }

    public void EndGame(bool flag)
    {
        SetEnabled(false);

        //remove after spell correct
        pronunciations.RemoveAt(this.index);

        //reset game
        if (selectedTopic == "Animals")
        {
            slf.ResetCurrentSpell_Animals();
            slf.ResetCurrentListSpell_Animals();

            if (!slf.CheckCompleteGame("GameSpellAnimal") && slf.LoadNumberOfSkipsGameSpell("Animals") < 11)
            {
                //inscrease key
                slf.IncreaseKey();

                //complete game
                slf.CompleteGame("GameSpellAnimal");

                this.finished = true;
            }

            //save number of skips
            if (!flag)
            {
                numberofskips = (slf.LoadNumberOfSkipsGameSpell("Animals") + 1).ToString();
            }
            else
            {
                numberofskips = slf.LoadNumberOfSkipsGameSpell("Animals").ToString();
            }

            slf.ResetNumberOfSkipsGameSpell("Animals");
        }
        else if (selectedTopic == "Food")
        {
            slf.ResetCurrentSpell_Food();
            slf.ResetCurrentListSpell_Food();

            if (!slf.CheckCompleteGame("GameSpellFood") && slf.LoadNumberOfSkipsGameSpell("Food") < 11)
            {
                //inscrease key
                slf.IncreaseKey();

                //complete game
                slf.CompleteGame("GameSpellFood");

                this.finished = true;
            }

            //save number of skips
            if (!flag)
            {
                numberofskips = (slf.LoadNumberOfSkipsGameSpell("Food") + 1).ToString();
            }
            else
            {
                numberofskips = slf.LoadNumberOfSkipsGameSpell("Food").ToString();
            }

            slf.ResetNumberOfSkipsGameSpell("Food");
        }
        else if (selectedTopic == "Household")
        {
            slf.ResetCurrentSpell_House();
            slf.ResetCurrentListSpell_House();

            if (!slf.CheckCompleteGame("GameSpellHousehold") && slf.LoadNumberOfSkipsGameSpell("Household") < 11)
            {
                //inscrease key
                slf.IncreaseKey();

                //complete game
                slf.CompleteGame("GameSpellHousehold");

                this.finished = true;
            }

            //save number of skips
            if (!flag)
            {
                numberofskips = (slf.LoadNumberOfSkipsGameSpell("Household") + 1).ToString();
            }
            else
            {
                numberofskips = slf.LoadNumberOfSkipsGameSpell("Household").ToString();
            }

            slf.ResetNumberOfSkipsGameSpell("Household");
        }

        //random popup congratulation
        //int val = Random.Range(0, congrats.Length);
        //GameObject obj = Instantiate(congrats[val]);
        //obj.transform.SetParent(spellUI.transform, false);

        if (flag)
        {
            int val = Random.Range(0, popUpCheeringCanvas.transform.childCount);
            popUpCheeringCanvas.transform.GetChild(val).gameObject.SetActive(true);


            gameObject.GetComponent<AudioSource>().clip = bravo_audio;
            gameObject.GetComponent<AudioSource>().Play();

            StartCoroutine(ShowPopupCheering(val));
            StartCoroutine(BackTopic(gameObject.GetComponent<AudioSource>().clip.length));
        }
        else
        {
            StartCoroutine(GameOver(1f));
        }

        //popUpCheeringCanvas.transform.GetChild(val).gameObject.SetActive(false);
    }

    IEnumerator BackTopic(float delayTime)
    {
        SetEnabled(false);
        yield return new WaitForSeconds(delayTime);

        //win game
        //Instantiate(congratEndGame);

        gameWinCanvas.SetActive(true);
        yield return new WaitForSeconds(timeTransition);

        if (this.finished)
        {
            if (getKeyRewardCanvas != null)
            {
                gameWinCanvas.GetComponentInChildren<Animator>().SetTrigger("Disappear");
                getKeyRewardCanvas.SetActive(true);
                yield return new WaitForSeconds(timeTransition);
            }
        }

        //yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("TopicsAnimalsScene");
        SetEnabled(true);
    }

    IEnumerator GameOver(float delaytime)
    {
        SetEnabled(false);
        yield return new WaitForSeconds(delaytime);

        NotCompleted.gameObject.SetActive(true);
    }

    void SetEnabled(bool enabled)
    {
        pronounceImg.GetComponent<BoxCollider2D>().enabled = enabled;
        speakImg.GetComponent<BoxCollider2D>().enabled = enabled;
        //backBtn.enabled = enabled;
        skipBtn.enabled = enabled;
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
