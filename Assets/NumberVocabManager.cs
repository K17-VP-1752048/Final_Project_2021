using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NumberVocabManager : MonoBehaviour
{
    [SerializeField] private VocabularyScriptable dataVocabulary;
    [SerializeField] private Image vocabImage;
    [SerializeField] private TMP_Text vocabText;
    [SerializeField] private Button prevButton;
    [SerializeField] private Button nextButton;

    [SerializeField] private int currentVocab = 0;
    // Start is called before the first frame update
    void Start()
    {
        ShowVocab();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ShowVocab()
    {
        if(currentVocab == 0)
        {
            prevButton.interactable = false;
        }
        else
        {
            prevButton.interactable = true;
        }
        if(currentVocab == dataVocabulary.vocabularies.Count - 1)
        {
            nextButton.interactable = false;
        }
        else
        {
            nextButton.interactable = true;
        }

        Vocabulary vocab = dataVocabulary.vocabularies[currentVocab];
        if (vocab != null)
        {
            vocabImage.sprite = vocab.sprite;
            vocabImage.preserveAspect = true;
            vocabText.text = vocab.voca_text;
        }
    }

    public void ShowNextVocab()
    {
        currentVocab++;
        ShowVocab();
    }

    public void ShowPreviousVocab()
    {
        currentVocab--;
        ShowVocab();
    }
}
