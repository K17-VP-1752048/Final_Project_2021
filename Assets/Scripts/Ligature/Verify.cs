using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Verify : MonoBehaviour
{
    [SerializeField] List<GameObject> charBoxs;
    [SerializeField] Sentinel sentinel;
    [SerializeField] GameObject verifierBtn;
    [SerializeField] GameObject popupCanvas;

    private bool allAnswerIsCorrect;
    private bool allBoxIsFilled;

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
        if (!allBoxIsFilled) verifierBtn.GetComponent<AudioSource>().Play();
        if (allBoxIsFilled && !allAnswerIsCorrect)
        {
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
            ShowPopup();
        }
    }

    private void ShowPopup()
    {
        popupCanvas.SetActive(true);
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
}
