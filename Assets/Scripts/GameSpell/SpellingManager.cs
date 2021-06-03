using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpellingManager : MonoBehaviour
{
    [SerializeField] private SpellingUI spellUI;
    [SerializeField] private SpellDataScriptable spellData;
    [SerializeField] private AudioClip bravo_audio;
    [SerializeField] private GameObject[] congrats;
    [SerializeField] private GameObject congratEndGame;

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
        if(pronunciations.Count <= 0)
        {
            StartCoroutine(BackTopic(3f));
        }
        else
        {
            int val = Random.Range(0, pronunciations.Count);
            selectedPronunciation = pronunciations[val];
            spellUI.SetPronunciation(selectedPronunciation);
            pronunciations.RemoveAt(val);
        }
    }

    public int GetLength()
    {
        return pronunciations.Count;
    }

    public void NextRound()
    {
        //random popup congratulation
        int val = Random.Range(0, congrats.Length);
        Instantiate(congrats[val]);

        gameObject.GetComponent<AudioSource>().clip = bravo_audio;
        gameObject.GetComponent<AudioSource>().Play();
        Invoke("SelectPronunciation", gameObject.GetComponent<AudioSource>().clip.length + 0.1f);
    }

    public void EndGame()
    {
        Instantiate(congratEndGame);

        gameObject.GetComponent<AudioSource>().clip = bravo_audio;
        gameObject.GetComponent<AudioSource>().Play();
        StartCoroutine(BackTopic(gameObject.GetComponent<AudioSource>().clip.length + 0.2f));
    }

    IEnumerator BackTopic(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        SceneManager.LoadScene("TopicsAnimalsScene");
    }
}

[System.Serializable]
public class Pronunciation
{
    public string pronounceText;
    public AudioClip pronounceAudio;
    public Sprite animalSprite;
}
