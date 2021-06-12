using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TreasureManager : MonoBehaviour
{
    private GameObject keyFly;
    private Canvas OpenTreasureCanvas;
    private SaveLoadFile slf;
    [SerializeField] int keyNeeded;

    private void Start()
    {
        slf = gameObject.AddComponent<SaveLoadFile>();
        OpenTreasureCanvas = GameObject.Find("CanvasOpenTreasure").GetComponent<Canvas>();
        keyFly = GameObject.Find("Key");
        keyFly.SetActive(false);
    }

    public void openATreasure()
    {
        // check the keys first!
        //string name = "Puzzle" + (CollectionManager.numberOfOpenTreasure + 1);
        string name = "Puzzle" + (slf.LoadBox() + 1);
        Debug.Log("Click on button " + name);
        if (slf.LoadKey() >= keyNeeded)
        {
            StartCoroutine(openTreasureAnim(name));
        }
        else
        {
            // Alert that keys are not enough
        }
    }

    IEnumerator openTreasureAnim(string objectName)
    {
        GameObject tmp = GameObject.Find(objectName).transform.GetChild(1).gameObject;

        if (tmp.GetComponent<Image>().color == Color.white)
        {
            keyFly.SetActive(true);
            // numberOfOpenTreasure++;
            slf.IncreaseBox();
            // Keys--
            slf.DecreaseKey(1);
            
            yield return new WaitForSeconds(0.5f);
            keyFly.SetActive(false);
            tmp.GetComponent<Image>().enabled = false;

            OpenTreasureCanvas.enabled = true;
            yield return new WaitForSeconds(1f);

            SceneManager.LoadScene("Scenes/Puzzle/" + objectName);
        }
    }
}
