using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace Tests
{
    public class MenuSceneEditMode
    {
        // A Test behaves as an ordinary method
        [Test]
        public void MenuSceneEditModeSimplePasses()
        {
            // Use the Assert class to test conditions
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator MenuSceneEditModeWithEnumeratorPasses()
        {
            

            yield return null;
        }
    }
}
