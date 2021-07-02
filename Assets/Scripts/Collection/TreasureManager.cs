using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TreasureManager : MonoBehaviour
{
    public GameObject keyFly;
    private Canvas OpenTreasureCanvas;
    private SaveLoadFile slf;
    private Text notifText;
    public Image keyImage;

    private void Start()
    {
        slf = gameObject.AddComponent<SaveLoadFile>();
        OpenTreasureCanvas = GameObject.Find("CanvasOpenTreasure").GetComponent<Canvas>();
        OpenTreasureCanvas.enabled = false;
        keyFly.SetActive(false);
        //keyImage = GameObject.Find("Key Img").GetComponent<Image>();
        notifText = GameObject.Find("TitleText").GetComponent<Text>();
    }

    public bool checkTreasureKey(int keyNeeded)
    {
        return (slf.LoadKey() >= keyNeeded);
    }

    public void alertNotEnoughKey()
    {
        StartCoroutine(notEnoughKey());
    }
    IEnumerator notEnoughKey()
    {
        keyImage.color = Color.red;
        notifText.text = "Les clés ne suffisent pas";
        yield return new WaitForSeconds(0.3f);
        keyImage.color = Color.white;
        yield return new WaitForSeconds(0.2f);
        keyImage.color = Color.red;
        yield return new WaitForSeconds(0.3f);
        keyImage.color = Color.white;
        yield return new WaitForSeconds(1f);
        notifText.text = "Ouvrir ce trésor avec une clé";
    }

    public void startOpenTreasureAnim(string puzzleName)
    {
        StartCoroutine(openTreasure(GameObject.Find(puzzleName)));
    }
    IEnumerator openTreasure(GameObject tmp)
    {
        keyFly.SetActive(true);
        // numberOfOpenTreasure++;
        slf.IncreaseBox();
        // Keys--
        slf.DecreaseKey(1);

        yield return new WaitForSeconds(1f);
        keyFly.SetActive(false);
        tmp.transform.GetChild(1).GetComponent<Image>().enabled = false;

        OpenTreasureCanvas.enabled = true;
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(tmp.name);
    }

    public void alertTreasureCanNotOpen()
    {
        StartCoroutine(runTreasureCanNotOpenAnim());
    }

    IEnumerator runTreasureCanNotOpenAnim()
    {
        notifText.text = "Impossible d'ouvrir ce trésor";
        yield return new WaitForSeconds(1f);
        notifText.text = "Ouvrir ce trésor avec une clé";
    }
}
