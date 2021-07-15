using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionManager : MonoBehaviour
{
    [SerializeField] int numberOfTreasure;
    [SerializeField] GameObject treasures;

    private static int numberOfOpenTreasure;
    private Canvas OpenTreasureCanvas;
    private SaveLoadFile slf;

    // Start is called before the first frame update
    void Start()
    {
        slf = gameObject.AddComponent<SaveLoadFile>();
        
        numberOfOpenTreasure = slf.LoadBox();

        for (int i = 0; i < numberOfTreasure; i++)
        {
            Transform tmp = treasures.transform.GetChild(i); //GameObject.Find("Puzzle" + i);

            // for opened treasures, treasure box set to false
            if (i < numberOfOpenTreasure)
            {
                tmp.GetChild(1).gameObject.SetActive(false);
            }
            // for closed treasures, images set to false
            else
            {
                tmp.GetChild(0).gameObject.SetActive(false);
                // impossible d'ouvrir un trésor à l'arrière sans ouvrir le trésor devant lui
                if (i > numberOfOpenTreasure)
                {
                    tmp.GetChild(1).GetComponent<Image>().color = new Color(.1f, .1f, .1f, .6f);
                }
            }
        }
        //OpenTreasureCanvas = GameObject.Find("CanvasOpenTreasure").GetComponent<Canvas>();
        //OpenTreasureCanvas.enabled = false;
    }
}
