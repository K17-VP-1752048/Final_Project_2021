using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace Tests
{
    public class MenuSceneTest
    {

        [UnitySetUp]
        public IEnumerator LoadLoadingScene()
        {
            SceneManager.LoadScene("Assets/Scenes/Loading/LoadingScene.unity");
            yield return new WaitForSeconds(5f);
        }

        [UnityTest]
        public IEnumerator PlayButtonClickedLoadTopicsScene()
        {
            GameObject playBtn = GameObject.Find("Canvas/Play Btn");
            EventSystem.current.SetSelectedGameObject(playBtn);
            playBtn.GetComponent<Button>().onClick.Invoke();
            yield return new WaitForSeconds(2f);
            string sceneName = SceneManager.GetActiveScene().name;
            Assert.AreEqual(sceneName, "TopicsScene");

            yield return null;
        }

        [UnityTest]
        public IEnumerator CollectionButtonClickedLoadCollectionScene()
        {
            GameObject collectionBtn = GameObject.Find("Canvas/Collection Button");
            EventSystem.current.SetSelectedGameObject(collectionBtn);
            collectionBtn.GetComponent<Button>().onClick.Invoke();
            yield return new WaitForSeconds(2f);
            string sceneName = SceneManager.GetActiveScene().name;
            Assert.AreEqual(sceneName, "CollectionScene");

            yield return null;
        }

        [UnityTest]
        public IEnumerator MusicTurnOffWhenClicked()
        {
            
            GameObject settingBtn = GameObject.Find("Canvas/SettingBtn");
            SimulateButtonClick(settingBtn);
            yield return new WaitForSeconds(2f);

            GameObject checkBox = GameObject.Find(
                "Canvas/SettingBtn/SettingPanel/Music/Checkbox");
            Sprite checkBoxBeforeClick = checkBox.GetComponent<Image>().sprite;
            SimulateButtonClick(checkBox);
            yield return new WaitForSeconds(2f);

            GameObject musicAudio = GameObject.Find("BackgroundAudio");

            GameObject closeBtn = GameObject.Find("Canvas/SettingBtn/SettingPanel/CloseBtn");
            SimulateButtonClick(closeBtn);
            yield return new WaitForSeconds(2f);

            GameObject playBtn = GameObject.Find("Canvas/Play Btn");
            SimulateButtonClick(playBtn);
            yield return new WaitForSeconds(2f);
 
            string sceneName = SceneManager.GetActiveScene().name;
            //check if in topics scene
            Assert.AreEqual("TopicsScene", sceneName);

            GameObject checkBoxNextScene = GameObject.Find(
                "Canvas/SettingBtn/SettingPanel/Music/Checkbox");
            Sprite checkBoxNextSceneSprite = checkBoxNextScene.GetComponent<Image>().sprite;
            
            //check if music is off
            Assert.AreNotEqual(checkBoxBeforeClick, checkBoxNextSceneSprite);
            Assert.AreEqual(true, musicAudio.GetComponent<AudioSource>().mute);
        }

        [UnityTest]
        public IEnumerator SettingSaveSoundChangeInOtherScene()
        {

            GameObject settingBtn = GameObject.Find("Canvas/SettingBtn");
            SimulateButtonClick(settingBtn);
            yield return new WaitForSeconds(2f);

            GameObject checkBox = GameObject.Find(
                "Canvas/SettingBtn/SettingPanel/Sounds/Checkbox");
            Sprite checkBoxBeforeClick = checkBox.GetComponent<Image>().sprite;
            SimulateButtonClick(checkBox);
            yield return new WaitForSeconds(2f);

            GameObject closeBtn = GameObject.Find("Canvas/SettingBtn/SettingPanel/CloseBtn");
            SimulateButtonClick(closeBtn);
            yield return new WaitForSeconds(2f);

            GameObject playBtn = GameObject.Find("Canvas/Play Btn");
            SimulateButtonClick(playBtn);
            yield return new WaitForSeconds(2f);

            //check if in topics scene
            string sceneName = SceneManager.GetActiveScene().name;
            Assert.AreEqual("TopicsScene", sceneName);

            GameObject checkBoxNextScene = GameObject.Find(
                "Canvas/SettingBtn/SettingPanel/Sounds/Checkbox");

            Sprite checkBoxNextSceneSprite = checkBoxNextScene.GetComponent<Image>().sprite;
            Assert.AreNotEqual(checkBoxBeforeClick, checkBoxNextSceneSprite);
            

        }
        public void SimulateButtonClick(GameObject button)
        {
            EventSystem.current.SetSelectedGameObject(button);
            button.GetComponent<Button>().onClick.Invoke();
        }

        public void FindButtonInSceneAndSimulate(string buttonPath)
        {
            GameObject button = GameObject.Find(buttonPath);
            EventSystem.current.SetSelectedGameObject(button);
            button.GetComponent<Button>().onClick.Invoke();
        }

        [UnityTest]
        public IEnumerator CantOpenTreasureIfHasNoKey()
        {
            GameObject collectionBtn = GameObject.Find("Canvas/Collection Button");
            EventSystem.current.SetSelectedGameObject(collectionBtn);
            collectionBtn.GetComponent<Button>().onClick.Invoke();
            yield return new WaitForSeconds(1.5f);
            string sceneName = SceneManager.GetActiveScene().name;

            Assert.AreEqual(sceneName, "CollectionScene");

            GameObject treasure = GameObject.Find("Treasure2");
            SimulateButtonClick(treasure);
            GameObject puzzleImg = GameObject.Find("Image2");
            GameObject canvasOpenTreasure = GameObject.Find("CanvasOpenTreasure");
            Assert.IsNull(puzzleImg);
            Assert.IsNull(canvasOpenTreasure);
            Assert.IsNotNull(treasure);

        }

        [UnityTest]
        public IEnumerator QuitGameBackToGameChoosingScene()
        {
            FindButtonInSceneAndSimulate("Play Btn");
            yield return new WaitForSeconds(1.5f);
            FindButtonInSceneAndSimulate("Zoo Btn");
            yield return new WaitForSeconds(1.5f);
            FindButtonInSceneAndSimulate("gameSpellAnimal");
            yield return new WaitForSeconds(5f);
            Assert.AreEqual("Animals_Spelling", SceneManager.GetActiveScene().name);

            yield return new WaitForSeconds(1.5f);

            FindButtonInSceneAndSimulate("QuitCanvas/Background/YesBtn");

            Assert.AreEqual("Animals_Spelling", SceneManager.GetActiveScene().name);
        }

    }
}
