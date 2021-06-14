﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VocabularyManager : MonoBehaviour
{
    [SerializeField] private DataAnimalsScriptable vocaDataAnimals;
    [SerializeField] private DataFoodScriptable vocaDataFood;
    [SerializeField] private DataHouseholdScriptable vocaDataHousehold;
    [SerializeField] private List<Image> listImg;
    [SerializeField] private string topic;

    private int index = 0;
    private int indexPrevious = 0;
    private List<Vocabulary> list;

    // Start is called before the first frame update
    void Start()
    {
        if (topic == "Animal")
        {
            list = new List<Vocabulary>(vocaDataAnimals.vocals);
        }
        else if (topic == "Food")
        {
            list = new List<Vocabulary>(vocaDataFood.vocals);
        }
        else if (topic == "House")
        {
            list = new List<Vocabulary>(vocaDataHousehold.vocals);
        }

        for (int i = 0; i < list.Count; i++)
        {
            if(i >= listImg.Count)
            {
                this.index = i;
                break;
            }
            
            listImg[i].sprite = list[i].sprite;
            listImg[i].preserveAspect = true;
            listImg[i].GetComponentInChildren<TMP_Text>().text = list[i].voca_text;
            listImg[i].gameObject.SetActive(true);
        }
    }

    public void NextList()
    {
        ResetActiveFalse();
        int tmp = 0;
        for (int i = this.index; i < list.Count; i++)
        {
            if (i == list.Count - 1)
            {
                int page = (list.Count % listImg.Count != 0) ? (list.Count / 9 + 1) : (list.Count / 9);
                this.indexPrevious = listImg.Count * page - 2 * listImg.Count;
            }

            if (tmp >= listImg.Count)
            {
                this.index = i;
                this.indexPrevious = this.index - 2 * listImg.Count;
                break;
            }

            listImg[tmp].sprite = list[i].sprite;
            listImg[tmp].preserveAspect = true;
            listImg[tmp].GetComponentInChildren<TMP_Text>().text = list[i].voca_text;
            listImg[tmp].gameObject.SetActive(true);
            tmp++;
        }
    }

    public void PreviousList()
    {
        if(this.indexPrevious >= 0)
        {
            ResetActiveFalse();
            int tmp = 0;
            for (int i = this.indexPrevious; i < list.Count; i++)
            {
                if (tmp >= listImg.Count)
                {
                    this.index = i;
                    this.indexPrevious = this.index - 2 * listImg.Count;
                    break;
                }

                listImg[tmp].sprite = list[i].sprite;
                listImg[tmp].preserveAspect = true;
                listImg[tmp].GetComponentInChildren<TMP_Text>().text = list[i].voca_text;
                listImg[tmp].gameObject.SetActive(true);
                tmp++;
            }
        }
    }

    public void ResetActiveFalse()
    {
        for (int i = 0; i < listImg.Count; i++)
        {
            listImg[i].gameObject.SetActive(false); 
        }
    }
}

[System.Serializable]
public class Vocabulary
{
    public Sprite sprite;
    public string voca_text;
}
