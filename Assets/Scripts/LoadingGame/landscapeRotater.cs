using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class landscapeRotater : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    private void Update()
    {
        Screen.autorotateToLandscapeLeft = true;
        Screen.autorotateToLandscapeRight = true;
        Screen.orientation = ScreenOrientation.AutoRotation;
    }
}
