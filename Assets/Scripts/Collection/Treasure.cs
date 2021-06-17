using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Treasure : MonoBehaviour
{
    private string puzzleName;
    [SerializeField] TreasureManager treasureManager;
    [SerializeField] int keyNeed;

    public void openATreasure()
    {
        //string name = "Puzzle" + (slf.LoadBox() + 1);

        puzzleName = this.transform.parent.name;
        Debug.Log("Click on button " + puzzleName);

        // check if treasure is in the middle of screen
        // ...

        if (GetComponent<Image>().color == Color.white)
        {
            // check the keys
            if (treasureManager.checkTreasureKey(keyNeed))
            {
                treasureManager.startOpenTreasureAnim(puzzleName);
            }
            else
            {
                // Alert that keys are not enough
                treasureManager.alertNotEnoughKey();
            }
        }
        else
        {
            treasureManager.alertTreasureCanNotOpen();
        }
    }
}
