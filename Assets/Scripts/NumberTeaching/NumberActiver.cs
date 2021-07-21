using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NumberActiver : MonoBehaviour
{
    //public TextWriter textWriter;
    public GameObject[] numbers;
    public GameObject textBackground;
    public GameObject[] textsInTextBackground;
    public GameObject refreshBtn;

    private Text message;
    private SaveLoadFile slf;

    // Start is called before the first frame update
    void Start()
    {
        slf = gameObject.AddComponent<SaveLoadFile>();
        StartCoroutine(printNumberCoroutine());
    }

    IEnumerator printNumberCoroutine()
    {
        yield return new WaitForSeconds(1f);
        textBackground.SetActive(true);
        for(int i = 0; i < textsInTextBackground.Length-1; i++)
        {
            textsInTextBackground[i].SetActive(true);
            if (KeepSoundPlay.state)
                textsInTextBackground[i].GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(4f);
            textsInTextBackground[i].SetActive(false);
        }

        textBackground.SetActive(false);

        foreach (GameObject num in numbers)
        {
            if (KeepSoundPlay.state)
                GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(2.5f);
            num.SetActive(true);
            if (KeepSoundPlay.state)
                num.GetComponent<AudioSource>().Play();
        }

        yield return new WaitForSeconds(2f);
        textsInTextBackground[textsInTextBackground.Length - 1].SetActive(true);
        textBackground.SetActive(true);

        if (!slf.CheckCompleteGame("NumberIntroduce"))
        {
            slf.CompleteGame("NumberIntroduce");
        }

        yield return new WaitForSeconds(3f);
        refreshBtn.SetActive(true);
    }
}
