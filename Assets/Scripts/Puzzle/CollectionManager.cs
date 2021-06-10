using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionManager : MonoBehaviour
{
    [SerializeField] int numberOfTreasure;
    public static int numberOfOpenTreasure;
    private Canvas OpenTreasureCanvas;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = numberOfTreasure; i > 0; i--)
        {
            GameObject tmp = GameObject.Find("Puzzle" + i);
            tmp.transform.Find("Image").GetComponent<Image>().enabled = false;

            if (i > numberOfOpenTreasure + 1)
            {
                tmp.GetComponent<Image>().color = Color.grey;
            }
        }
        OpenTreasureCanvas = GameObject.Find("CanvasOpenTreasure").GetComponent<Canvas>();
        OpenTreasureCanvas.enabled = false;
    }
}
