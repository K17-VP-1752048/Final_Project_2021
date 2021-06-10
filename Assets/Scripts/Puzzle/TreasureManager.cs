using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreasureManager : MonoBehaviour
{
    //    private Animation keyFly = GameObject.Find("Key").GetComponent<Animation>();
    private Canvas OpenTreasureCanvas;

    private void Start()
    {
        OpenTreasureCanvas = GameObject.Find("CanvasOpenTreasure").GetComponent<Canvas>();

    }

    public void openATreasure()
    {
        string name = "Puzzle" + CollectionManager.numberOfOpenTreasure + 1;
        StartCoroutine(openTreasureAnim(name));
    }

    IEnumerator openTreasureAnim(string objectName)
    {
        if (gameObject.name.Equals(objectName))
        {
 //           keyFly.Play();
            CollectionManager.numberOfOpenTreasure++;
            OpenTreasureCanvas.enabled = true;
            yield return new WaitForSeconds(2f);

            GameObject tmp = GameObject.Find(objectName);
            tmp.GetComponent<Image>().sprite = null;
            tmp.transform.Find("Image").GetComponent<Image>().enabled = true;

            OpenTreasureCanvas.enabled = false;
        }
    }
}
