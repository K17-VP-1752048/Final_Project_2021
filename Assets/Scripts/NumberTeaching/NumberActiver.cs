using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberActiver : MonoBehaviour
{
    [SerializeField] TextWriter textWriter;
//    [SerializeField] private Object textBackground;

    private string[] nums = {"One", "Two", "Three", "Four", "Five", "Six",
        "Seven", "Eight", "Nine", "Ten", "Zero"};

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < nums.Length; i++)
        {
            GameObject.Find(nums[i]).GetComponent<Text>().enabled = false;
        }

        Text message = GameObject.Find("TextRun").GetComponent<Text>();
        textWriter.addWriter(message, "Bienvenue!", .2f);
        
//        GameObject.Find("TextBackground").GetComponent<Image>().enabled = false;

        StartCoroutine(printNumberCoroutine());
    }

    // Update is called once per frame
    IEnumerator printNumberCoroutine()
    {
        for (int i = 0; i < nums.Length; i++)
        {
            yield return new WaitForSeconds(2f);
            GameObject.Find(nums[i]).GetComponent<Text>().enabled = true;
        }
    }
}
