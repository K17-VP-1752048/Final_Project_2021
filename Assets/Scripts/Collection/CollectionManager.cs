using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionManager : MonoBehaviour
{
    [SerializeField] int numberOfTreasure;

    private static int numberOfOpenTreasure;
    private Canvas OpenTreasureCanvas;
    private SaveLoadFile slf;


    // Start is called before the first frame update
    void Start()
    {
        slf = gameObject.AddComponent<SaveLoadFile>();
        //slf.IncreaseKey();
        
        //slf.ResetBox();
        numberOfOpenTreasure = slf.LoadBox();

        for (int i = 1; i <= numberOfTreasure; i++)
        {
            GameObject tmp = GameObject.Find("Puzzle" + i);

            // for opened treasures, treasure box set to false
            if (i <= numberOfOpenTreasure)
            {
                tmp.transform.GetChild(1).gameObject.SetActive(false);
            }
            // for closed treasures, images set to false
            else
            {
                tmp.transform.GetChild(0).gameObject.SetActive(false);
                // impossible d'ouvrir un trésor à l'arrière sans ouvrir le trésor devant lui
                if (i > numberOfOpenTreasure + 1)
                {
                    tmp.transform.GetChild(1).GetComponent<Image>().color = new Color(.1f, .1f, .1f, .6f);
                }
            }
        }
        OpenTreasureCanvas = GameObject.Find("CanvasOpenTreasure").GetComponent<Canvas>();
        OpenTreasureCanvas.enabled = false;
    }
}
