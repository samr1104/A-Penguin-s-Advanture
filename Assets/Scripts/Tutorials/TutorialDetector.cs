using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialDetector : MonoBehaviour
{
    // change instructions
    public bool detect1 = false;
    public GameObject ground1;
    public bool detect2 = false;
    public GameObject ground2;

    // remind enemy
    public bool detect3 = false;
    public GameObject ground3;
    public bool detect4 = false;
    public GameObject ground4;
    public bool detect5 = false;
    public GameObject ground5;

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position == ground1.transform.position + new Vector3(0, 1.5f, 0))
        {
            detect1 = true;
        }

        if(gameObject.transform.position == ground2.transform.position + new Vector3(0, 1.5f, 0))
        {
            detect2 = true;
        }

        // remind enemy
        if (gameObject.transform.position == ground3.transform.position + new Vector3(0, 1.5f, 0))
        {
            // Debug.Log("here you are!");
            detect3 = true;
        }

        if (gameObject.transform.position == ground4.transform.position + new Vector3(0, 1.5f, 0))
        {
            // Debug.Log("here you are!");
            detect4 = true;
        }

        if (gameObject.transform.position == ground5.transform.position + new Vector3(0, 1.5f, 0))
        {
            // Debug.Log("here you are!");
            detect5 = true;
        }
    }
}
