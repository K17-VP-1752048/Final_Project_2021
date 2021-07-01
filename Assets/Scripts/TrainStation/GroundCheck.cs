using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private Number number;

    // Start is called before the first frame update
    void Start()
    {
        number = gameObject.transform.parent.gameObject.GetComponent<Number>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            number.SetIsGrounded(true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            number.SetIsGrounded(false);
        }
    }
}
