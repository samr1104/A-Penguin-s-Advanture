using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetect : MonoBehaviour
{
    public GameObject gate;
    private RaycastHit hit;
    bool isTrigger = false;

    private float timer = 0f;
    bool wait = false;

    private Collider gateCollider;
    private Renderer gateTexture;

    private void Start()
    {
        gateCollider = gate.GetComponent<Collider>();
        gateTexture = gate.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isTrigger){
            // only box can push the trigger
            // if (Physics.Raycast(transform.position, Vector3.up, out hit, 10f) && hit.collider.CompareTag("Box")){
            //     gate.SetActive(false);
            //     isTrigger = true;
            // }

            //if (Physics.Raycast(transform.position, Vector3.up, out hit, 10f)){
            //    gateCollider.enabled = false;
            //    gateTexture.enabled = false;
            //    isTrigger = true;
            //} else if(wait) {
            //    if (gateCollider.enabled == false)
            //    {
            //        gateCollider.enabled = true;
            //    }
            //    timer += Time.deltaTime;
            //    if(timer >= 1f)
            //    {
            //        wait = false;
            //        timer = 0f;
            //        gateTexture.enabled = true;
            //    }
            //}

            if (Physics.Raycast(transform.position, Vector3.up, out hit, 3f))
            {
                // Debug.Log("isTrigger " + index + " by " + hit.collider.transform.position);
                gate.SetActive(false);
                isTrigger = true;

                // audio
                if(!hit.collider.CompareTag("Enemy")) {
                    SoundManager.PlayTriggerClip();
                }
            }
        } else {
          //if (!Physics.Raycast(transform.position, Vector3.up, out hit, 10f)){
          //    // gate.SetActive(true);
          //    isTrigger = false;
          //    wait = true;
          //}

            if (!Physics.Raycast(transform.position, Vector3.up, out hit, 3f))
            {
                gate.SetActive(true);
                isTrigger = false;
                // wait = true;
            }
        }

        // if(wait) {
        //     timer += Time.deltaTime;
        //     if(timer >= 1f)
        //     {
        //         wait = false;
        //         timer = 0f;
        //         gate.SetActive(true);
        //     }
        // }
    }
}
