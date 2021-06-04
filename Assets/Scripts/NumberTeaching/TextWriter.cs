using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextWriter : MonoBehaviour
{
    private Text uiText;
    private string text;
    private float timePerChar;
    private float timer;
    private int characterIndex;

    public void addWriter(Text ui, string textToWrite, float timePerCharacter)
    {
        uiText = ui;
        text = textToWrite;
        timePerChar = timePerCharacter;
        characterIndex = 0;
    }

    private void Update()
    {
        if(uiText != null)
        {
            timer -= Time.deltaTime;
            while(timer <= 0f)
            {
                timer += timePerChar;
                characterIndex++;
                uiText.text = text.Substring(0, characterIndex);

                if(characterIndex >= text.Length)
                {
                    uiText = null;
                    return;
                }
            }
        }
    }
}