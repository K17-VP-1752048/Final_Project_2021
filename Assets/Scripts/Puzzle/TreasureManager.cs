using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TreasureManager : MonoBehaviour
{
    private GameObject keyFly;
    private Canvas OpenTreasureCanvas;


    private void Start()
    {
        OpenTreasureCanvas = GameObject.Find("CanvasOpenTreasure").GetComponent<Canvas>();
        keyFly = GameObject.Find("Key");
        keyFly.SetActive(false);
    }

    public void openATreasure()
    {
        // check the keys first!
        // ...
        string name = "Puzzle" + (CollectionManager.numberOfOpenTreasure + 1);
        Debug.Log("Click on button " + name);
        StartCoroutine(openTreasureAnim(name));
    }

    IEnumerator openTreasureAnim(string objectName)
    {
        GameObject tmp = GameObject.Find(objectName).transform.GetChild(1).gameObject;

        if (tmp.GetComponent<Image>().color == Color.white)
        {
            keyFly.SetActive(true);
            CollectionManager.numberOfOpenTreasure++;
            // Keys--
            
            yield return new WaitForSeconds(0.5f);
            keyFly.SetActive(false);
            tmp.GetComponent<Image>().enabled = false;

            OpenTreasureCanvas.enabled = true;
            yield return new WaitForSeconds(1f);

            SceneManager.LoadScene("Scenes/Puzzle/" + objectName);
        }
    }
}
