using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionManager : MonoBehaviour
{
    [SerializeField] int numberOfTreasure;
    public static int numberOfOpenTreasure = 2;
    private Canvas OpenTreasureCanvas;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i <= numberOfTreasure; i++)
        {
            GameObject tmp = GameObject.Find("Puzzle" + i);

            // for opened treasures, treasure box set to false
            if (i <= numberOfOpenTreasure)
            {
                tmp.transform.GetChild(1).gameObject.SetActive(false);
            }
            // for un-opened treasures, images set to false
            else
            {
                tmp.transform.GetChild(0).gameObject.SetActive(false);
                if (i > numberOfOpenTreasure + 1)
                {
                    tmp.transform.GetChild(1).GetComponent<Image>().color = Color.grey;
                }
            }
        }
        OpenTreasureCanvas = GameObject.Find("CanvasOpenTreasure").GetComponent<Canvas>();
        OpenTreasureCanvas.enabled = false;
    }
}
