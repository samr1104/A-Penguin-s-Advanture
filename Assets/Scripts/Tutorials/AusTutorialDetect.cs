using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AusTutorialDetect : MonoBehaviour
{
    public bool detect1 = false;
    public GameObject ground1;

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position == ground1.transform.position + new Vector3(0, 1.5f, 0))
        {
            detect1 = true;
        }
    }
}
