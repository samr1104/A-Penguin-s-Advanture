using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    // public bool move = false;
    // private Vector3 direction;
    // public LayerMask stopMovement;
    float rayLength = 1f;
    public bool moveable = true;
    public GameObject upBox;
    public int limitSteps = 999;

    public Material Material0;
    public Material Material1;
    public Material Material2;
    public Material Material3;

    public LayerMask water;

    void Update()
    {
        // if(move)
        // {
        //     transform.Translate(direction);
        //     bool isDown = downsideDetect();
        //     if(isDown == false){
        //         transform.Translate(Vector3.down);
        //     }
        //     if(upBox != null) {
        //         upBox.transform.Translate(direction);
        //         if(isDown == false) upBox.transform.Translate(Vector3.down);
        //     }
        //     move = false;
        //     limitSteps--;
        // }

        if(limitSteps == 3)
        {
            gameObject.GetComponent<MeshRenderer> ().material = Material3;
        } else if(limitSteps == 2) {
            gameObject.GetComponent<MeshRenderer> ().material = Material2;
        } else if(limitSteps == 1) {
            gameObject.GetComponent<MeshRenderer> ().material = Material1;
        } else if(limitSteps <= 0) {
            gameObject.GetComponent<MeshRenderer> ().material = Material0;
        }
    }

    // void OnTriggerEnter(Collider other)
    // {
    //     if(other.gameObject.tag == "Player")
    //     {
    //         move = true;
    //         direction = other.gameObject.GetComponent<PlayerController>().direction;
    //     }
    // }

    bool downsideDetect()
    {
        RaycastHit hit;
        if(!Physics.Raycast(transform.position, Vector3.down, out hit, rayLength))
        {
            return false;
        }
        else return true;
    }

    public bool checkMoveable(Vector3 direction)
    {
        moveable = !Physics.Raycast(transform.position, direction, rayLength, ~water);
        if(limitSteps <= 0) {
            moveable = false;
        }
        return moveable;
    }

    public void moveBox(Vector3 direction)
    {
        transform.Translate(direction);
        bool isDown = downsideDetect();
        if (isDown == false){
            transform.Translate(Vector3.down);
            // audio
            SoundManager.PlayWaterClip();
        }
        if (upBox!=null) {
            upBox.transform.Translate(direction);
            if (isDown == false) upBox.transform.Translate(Vector3.down);
        }
    }
}
