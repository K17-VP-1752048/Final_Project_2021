using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VocabularyManager : MonoBehaviour
{
    [SerializeField] private DataAnimalsScriptable vocaData;
    [SerializeField] private List<Image> listImg;

    private int index = 0;
    private Image img;
    private TMP_Text tmpText;
    private GameObject obj;
    private int page;
    // Start is called before the first frame update
    void Start()
    {
        /*if(vocaData.vocals.Count / 9 == 0)
        {
            page = vocaData.vocals.Count / 9;
        }
        else
        {
            page = vocaData.vocals.Count / 9 + 1;
        }*/
        for (int i = 0; i < vocaData.vocals.Count; i++)
        {
            if(i >= listImg.Count)
            {
                this.index = i;
                break;
            }
            
            listImg[i].sprite = vocaData.vocals[i].sprite;
            listImg[i].preserveAspect = true;
            listImg[i].GetComponentInChildren<TMP_Text>().text = vocaData.vocals[i].voca_text;
            listImg[i].gameObject.SetActive(true);
        }
    }

    public void NextList()
    {
        ResetActiveFalse();
        int tmp = 0;
        for (int i = this.index; i < vocaData.vocals.Count; i++)
        {
            if (tmp >= listImg.Count)
            {
                this.index = i;
                break;
            }

            listImg[tmp].sprite = vocaData.vocals[i].sprite;
            listImg[tmp].preserveAspect = true;
            listImg[tmp].GetComponentInChildren<TMP_Text>().text = vocaData.vocals[i].voca_text;
            listImg[tmp].gameObject.SetActive(true);
            tmp++;
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
