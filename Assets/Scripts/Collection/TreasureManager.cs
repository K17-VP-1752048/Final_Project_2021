using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TreasureManager : MonoBehaviour
{
    public GameObject keyFly;
    public GameObject OpenTreasureCanvas;
    private SaveLoadFile slf;
    public Text notifText;
    public Image keyImage;

    private void Start()
    {
        slf = gameObject.AddComponent<SaveLoadFile>();

        //keyFly.SetActive(false);
    }

    public bool checkTreasureKey(int keyNeeded)
    {
        return (slf.LoadKey() >= keyNeeded);
    }

    public void alertNotEnoughKey(string message)
    {
        StartCoroutine(notEnoughKey(message));
    }
    IEnumerator notEnoughKey(string mes)
    {
        string beginText = notifText.text;
        keyImage.color = Color.red;
        notifText.text = mes;
        yield return new WaitForSeconds(0.3f);
        keyImage.color = Color.white;
        yield return new WaitForSeconds(0.2f);
        keyImage.color = Color.red;
        yield return new WaitForSeconds(0.3f);
        keyImage.color = Color.white;
        yield return new WaitForSeconds(1f);
        notifText.text = beginText;
    }

    public void startOpenTreasureAnim(string puzzleName, int numberOfKeyLost)
    {
        if(puzzleName.Contains("Extra1"))
            StartCoroutine(openTreasureExtra(GameObject.Find(puzzleName), "ImageExtra1"));
        else if(puzzleName.Contains("Extra2"))
            StartCoroutine(openTreasureExtra(GameObject.Find(puzzleName), "ImageExtra2"));
        else
            StartCoroutine(openTreasure(GameObject.Find(puzzleName)));
        

        // numberOfOpenTreasure++;
        slf.IncreaseBox();
        // Keys--
        slf.DecreaseKey(numberOfKeyLost);
    }

    IEnumerator openTreasure(GameObject tmp)
    {
        keyFly.SetActive(true);

        yield return new WaitForSeconds(1f);
        keyFly.SetActive(false);
        //tmp.transform.GetChild(1).GetComponent<Image>().enabled = false;
        tmp.transform.GetChild(1).gameObject.SetActive(false);

        OpenTreasureCanvas.SetActive(true);
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(tmp.name);
    }

    IEnumerator openTreasureExtra(GameObject tmp, string scene)
    {
        keyFly.SetActive(true);

        yield return new WaitForSeconds(1f);
        keyFly.SetActive(false);
        //tmp.transform.GetChild(1).GetComponent<Image>().enabled = false;
        tmp.transform.GetChild(1).gameObject.SetActive(false);

        OpenTreasureCanvas.SetActive(true);
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(scene);
    }

    public void alertTreasureCanNotOpen()
    {
        StartCoroutine(runTreasureCanNotOpenAnim());
    }

    IEnumerator runTreasureCanNotOpenAnim()
    {
        string beginText = notifText.text;
        notifText.text = "Impossible d'ouvrir ce trésor";
        yield return new WaitForSeconds(1f);
        notifText.text = beginText;
    }

    public void writeNotif(string notif)
    {
        notifText.text = notif;
    }
}
