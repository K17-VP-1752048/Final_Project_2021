using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleImageManager : MonoBehaviour
{
    [SerializeField] string bgName;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find(bgName).GetComponent<Animator>().Play("zoomIn");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
