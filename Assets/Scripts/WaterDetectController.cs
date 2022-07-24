using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDetectController : MonoBehaviour
{
    float rayLength = 1f;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, Vector3.down, out hit, rayLength))
        {
            // change layer != water
            // int LayerIgnoreRaycast = LayerMask.NameToLayer("Ignore Raycast");
            // gameObject.layer = LayerIgnoreRaycast;
            gameObject.SetActive(false);
        }
    }
}
