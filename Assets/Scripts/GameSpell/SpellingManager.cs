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
    private SaveLoadFile slf;
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        slf = gameObject.AddComponent<SaveLoadFile>();
        slf.SpellData = spellData;
        List<Pronunciation> list = slf.LoadCurrentListSpellAnimals();
        Pronunciation p = slf.LoadCurrentSpellAnimal();

        if (list == null)
        {
            pronunciations = new List<Pronunciation>(spellData.pronunciations);
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
        if(pronunciations.Count <= 0)
        {
            slf.ResetGameSpell();
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

    public int GetLength()
    {
        return pronunciations.Count;
    }

    public void NextRound()
    {
        //remove after spell correct
        pronunciations.RemoveAt(this.index);

        //save current list
        slf.SaveCurrentListSpellAnimals(pronunciations);

        //random popup congratulation
        int val = Random.Range(0, congrats.Length);
        Instantiate(congrats[val]);

        gameObject.GetComponent<AudioSource>().clip = bravo_audio;
        gameObject.GetComponent<AudioSource>().Play();
        Invoke("SelectPronunciation", gameObject.GetComponent<AudioSource>().clip.length + 0.1f);
    }

    public void EndGame()
    {
        //reset game
        slf.ResetGameSpell();

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
    public AudioClip animalAudio;
    public Sprite animalSprite;
}
