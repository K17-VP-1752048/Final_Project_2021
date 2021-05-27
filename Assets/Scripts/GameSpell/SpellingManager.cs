using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpellingManager : MonoBehaviour
{
    [SerializeField] private SpellingUI spellUI;
    [SerializeField] private SpellDataScriptable spellData;
    [SerializeField] private AudioClip bravo_audio;

    private List<Pronunciation> pronunciations;
    private Pronunciation selectedPronunciation;
    // Start is called before the first frame update
    void Start()
    {
        pronunciations = new List<Pronunciation>(spellData.pronunciations);
        SelectPronunciation();
    }

    void SelectPronunciation()
    {
        if (pronunciations.Count <= 0)
        {
            SceneManager.LoadScene("TopicsAnimalsScene");
        }
        else
        {
            int val = Random.Range(0, pronunciations.Count);
            selectedPronunciation = pronunciations[val];
            spellUI.SetPronunciation(selectedPronunciation);
            pronunciations.RemoveAt(val);
        }
    }
    public void NextRound()
    {
        gameObject.GetComponent<AudioSource>().clip = bravo_audio;
        gameObject.GetComponent<AudioSource>().Play();
        Invoke("SelectPronunciation", gameObject.GetComponent<AudioSource>().clip.length + 0.1f);
    }
}

[System.Serializable]
public class Pronunciation
{
    public string pronounceText;
    public AudioClip pronounceAudio;
    public Sprite animalSprite;
}
