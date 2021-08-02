using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class EditModeTesting
    {
        // A Test behaves as an ordinary method
        [Test]
        public void EditModeTestingSimplePasses()
        {
            // Use the Assert class to test conditions
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator NumberofClickableObjectMatchWithNumberOfAnswer()
        {
            GameFindInput("Aliment_Find4", 5);
            yield return null;
        }

        public void GameFindInput(string sceneName, int numberOfCorrectAnswer)
        {
            EditorSceneManager.OpenScene("Assets/Scenes/GameFind/" + sceneName + ".unity");
            GameObject panelObject = GameObject.Find("PanelObject");
            ClickControl[] clickableObjects =  GameObject.FindObjectsOfType<ClickControl>();

            Assert.AreEqual(numberOfCorrectAnswer, clickableObjects.Length);
        }

        
    }
}
