using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VocabularyManager : MonoBehaviour
{
    [SerializeField] private Vocabulary_Animals_Scriptable vocaData;

    private int index = 0;
    private Image img;
    private TMP_Text tmpText;
    private GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 screen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        for (int i = index; i < vocaData.list.Count; i++)
        {
            obj.AddComponent<Image>().sprite = vocaData.list[i].sprite;
            obj.AddComponent<Image>().preserveAspect = true;
            obj.AddComponent<TMP_Text>().text = vocaData.list[i].voca_text;
            GameObject tmp = Instantiate(obj) as GameObject;
            tmp.transform.position = new Vector2(screen.x * 2, screen.y * 4);
        }
    }
}

public class Vocabulary
{
    public Sprite sprite;
    public string voca_text;
}
