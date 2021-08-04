using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleImageManager : MonoBehaviour
{
    public GameObject mainCharac1;
    public GameObject message1;
    public GameObject mainCharac2;
    public GameObject message2;
    [SerializeField] GameObject screenshot;
    public GameObject flashLight;


    private GameObject buttons;

    // Start is called before the first frame update
    void Start()
    {
        //message1.SetActive(false);
        //message2.SetActive(false);
        buttons = GameObject.Find("Buttons");
        buttons.SetActive(false);

        StartCoroutine(runAnim());
    }

    IEnumerator runAnim()
    {
        yield return new WaitForSeconds(1f);
        buttons.SetActive(true);
        yield return new WaitForSeconds(1f);
        mainCharac1.SetActive(true);
        yield return new WaitForSeconds(3f);
        message1.SetActive(true);
        yield return new WaitForSeconds(2f);
        if (mainCharac2 != null) mainCharac2.SetActive(true);
        message1.SetActive(false);
        if (message2 != null) {
            yield return new WaitForSeconds(2f);
            message2.SetActive(true); 
        }
    }

    public void TakeScreenShot()
    {
        StartCoroutine(takeAShot());
    }

    IEnumerator takeAShot()
    {
        buttons.SetActive(false);

        yield return new WaitForEndOfFrame();
        if(KeepSoundPlay.state)
            GetComponent<AudioSource>().Play();
        Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        texture.Apply();

        string name = "mondeludique" + System.DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".jpg";

        NativeGallery.SaveImageToGallery(texture, "Monde Ludique", name);

        flashLight.SetActive(true);

        yield return new WaitForSeconds(.2f);
        buttons.SetActive(true);
        flashLight.SetActive(false);

        screenshot.transform.GetChild(0).GetComponent<Image>().sprite 
            = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0f, 0f));
        screenshot.SetActive(true);
        
        yield return new WaitForSeconds(1.5f);
        screenshot.SetActive(false);
        Destroy(texture);
    }
}
