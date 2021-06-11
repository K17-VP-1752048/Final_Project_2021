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
            if(i > listImg.Count)
            {
                Debug.Log("break");
                break;
            }
            listImg[i].sprite = vocaData.vocals[i].sprite;
            listImg[i].preserveAspect = true;
            listImg[i].GetComponentInChildren<TMP_Text>().text = vocaData.vocals[i].voca_text;
            this.index = i;
        }
    }

    public void NextList()
    {
        Debug.Log(this.index);
        //for(int i = this.index++; i < )
    }
}

[System.Serializable]
public class Vocabulary
{
    public Sprite sprite;
    public string voca_text;
}
