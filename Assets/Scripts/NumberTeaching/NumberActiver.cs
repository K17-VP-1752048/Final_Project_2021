using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NumberActiver : MonoBehaviour
{
    [SerializeField] TextWriter textWriter;
    [SerializeField] GameObject textBackground;
    private Text message;

    private string[] nums = {"One", "Two", "Three", "Four", "Five", "Six",
        "Seven", "Eight", "Nine", "Ten", "Zero"};

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < nums.Length; i++)
        {
            GameObject.Find(nums[i]).GetComponent<Text>().enabled = false;
        }

        message = textBackground.transform.Find("TextRun").GetComponent<Text>();
        StartCoroutine(printNumberCoroutine());
    }

    IEnumerator printNumberCoroutine()
    {
        textWriter.addWriter(message, "Bonjour!", .1f);
        yield return new WaitForSeconds(2f);
        textWriter.addWriter(message, "Aujourd'hui on va apprendre les chiffres 0-10", .1f);
        yield return new WaitForSeconds(5f);
        textWriter.addWriter(message, "Alors comptez avec moi", .1f);
        yield return new WaitForSeconds(3f);
        textBackground.SetActive(false);

        for (int i = 0; i < nums.Length; i++)
        {
            GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(2f);
            GameObject.Find(nums[i]).GetComponent<Text>().enabled = true;
        }

        yield return new WaitForSeconds(2f);
        message.text = "Excellent, vous êtes prêts à relever d'autres défis?";
        textBackground.SetActive(true);
    }
}
