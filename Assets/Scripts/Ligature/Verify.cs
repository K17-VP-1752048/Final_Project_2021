using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Verify : MonoBehaviour
{
    [SerializeField] List<GameObject> charBoxs;
    [SerializeField] Sentinel sentinel;
    [SerializeField] GameObject verifierBtn;
    [SerializeField] GameObject popupCanvas;
    [SerializeField] AudioClip wordSpell;
    [SerializeField] private GameObject gameWinCanvas;
    [SerializeField] private GameObject getKeyRewardCanvas;
    [SerializeField] string nextScene;
    [SerializeField] string correctWord;

    private bool allAnswerIsCorrect;
    private bool allBoxIsFilled;
    private bool finished = false;
    private SaveLoadFile slf;

    private void Start()
    {
        slf = gameObject.AddComponent<SaveLoadFile>();
    }

    public void Click()
    {
        ClickEffect(); 
    }

    public void Release()
    {
        ReleaseEffect();
        Check();
    }

    private void ClickEffect()
    {
        verifierBtn.GetComponent<Image>().color = new Color32(34, 125, 48, 200);
    }

    private void ReleaseEffect()
    {
        verifierBtn.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
    }

    private void Check()
    {
        allAnswerIsCorrect = true;
        allBoxIsFilled = true;
        sentinel.GetComponent<Sentinel>().SetShouldStopAlert(false);
        foreach (GameObject charBox in charBoxs)
        {
            int charBoxCheck = charBox.GetComponent<CharBox>().Check();
            print("charBoxCheck: " + charBoxCheck);
            if (charBoxCheck == -1)
            {
                StartCoroutine(BoxEmptyAlert(charBox));              
                allBoxIsFilled = false;
            }
            if (charBoxCheck == 0)
            {
                allAnswerIsCorrect = false;
            }
        }
        if (!allBoxIsFilled) 
        {
            if(KeepSoundPlay.state)
                verifierBtn.GetComponent<AudioSource>().Play();
            if (!allAnswerIsCorrect)
            {
                foreach (GameObject charBox in charBoxs)
                {
                    if (charBox.GetComponent<CharBox>().Check() == 0)
                    {
                        charBox.GetComponent<CharBox>().SetToDefault();
                    }
                }
            }
        }
        if (allBoxIsFilled && !allAnswerIsCorrect)
        {
            if (KeepSoundPlay.state)
                GetComponent<AudioSource>().Play();
            foreach (GameObject charBox in charBoxs)
            {
                if (charBox.GetComponent<CharBox>().Check() == 0)
                {
                    charBox.GetComponent<CharBox>().SetToDefault();
                }
            }
        }
        if (allBoxIsFilled && allAnswerIsCorrect)
        {
            if(nextScene != "TopicsHouseScene" && nextScene != "")
            {
                slf.SaveCurrentSceneLingature(nextScene);

                StartCoroutine(ShowPopUp());
            }
            else
            {
                //Win Game
                slf.ResetGameLingature();

                if (!slf.CheckCompleteGame("GameLigature"))
                {
                    slf.IncreaseKey();
                    slf.CompleteGame("GameLigature");
                    this.finished = true;
                }

                StartCoroutine(WinGame(3.5f));
            }
        }
    }


    IEnumerator ShowPopUp()
    {
        popupCanvas.GetComponentInChildren<Popup>().SetPopUpCanvasCorrectWord(correctWord);
        Instantiate(popupCanvas);

        yield return new WaitForSeconds(
            popupCanvas.GetComponentInChildren<AudioSource>().clip.length);
        AudioSource.PlayClipAtPoint(wordSpell, Camera.main.transform.position);
        yield return new WaitForSeconds(wordSpell.length);
        SceneManager.LoadScene(nextScene);
    }

    IEnumerator BoxEmptyAlert(GameObject charBox)
    {
        WaitForSeconds wait = new WaitForSeconds(.25f);
        sentinel.GetComponent<Sentinel>().SetAlertIssued(true);
        charBox.GetComponent<Image>().color = new Color32(241, 83, 83, 255);
        for (float i = 0; i < 8; i++)
        {
            if (sentinel.GetComponent<Sentinel>().ShouldStopAlert())
            {
                break;
            }
            yield return wait;
        }
        charBox.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        sentinel.GetComponent<Sentinel>().SetAlertIssued(false);
    }

    IEnumerator WinGame(float seconds)
    {
        popupCanvas.GetComponentInChildren<Popup>().SetPopUpCanvasCorrectWord(correctWord);
        GameObject popUp =  Instantiate(popupCanvas);
        
        yield return new WaitForSeconds(
            popupCanvas.GetComponentInChildren<AudioSource>().clip.length);
        if (KeepSoundPlay.state)
            AudioSource.PlayClipAtPoint(wordSpell, Camera.main.transform.position);
        yield return new WaitForSeconds(wordSpell.length);
        Destroy(popUp);

        gameWinCanvas.SetActive(true);
        yield return new WaitForSeconds(seconds);

        if (finished && getKeyRewardCanvas != null)
        {
            if (getKeyRewardCanvas != null)
            {
                gameWinCanvas.GetComponentInChildren<Animator>().SetTrigger("Disappear");
                getKeyRewardCanvas.SetActive(true);
                yield return new WaitForSeconds(2f);
            }
        }

        SceneManager.LoadScene(nextScene);
    }
}
