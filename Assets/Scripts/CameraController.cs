using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Public variable to store a reference to the player game object
    public GameObject player;
    public float cameraSpeed = 5f;
    public bool needView = true;
    private GameObject goal;
    //Private variable to store the offset distance between the player and camera
    private Vector3 offset;
    private Vector3 startPos, goalPos;
    public bool finishView = false;
    private float timer = 2f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerController>().FreezePlayer();
        goal = GameObject.Find("Goal");
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
        // Stop BGMs
        // Music_Trans.instance.gameObject.GetComponent<AudioSource>().Pause();
        startPos = player.transform.position + offset;
        goalPos = goal.transform.position + offset;

        if (needView) StartCoroutine(MoveCamera());
        else {
            finishView = true;
            player.GetComponent<PlayerController>().UnfreezePlayer();}
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        if (finishView == true) transform.position = player.transform.position + offset;
    }
    private IEnumerator MoveCamera(){
        float timee = timer;
        timer = 0.35f;
        while (timer>=0){
            timer -= Time.deltaTime;
            yield return null;
        }
        timer = timee;
        while (transform.position != goalPos) {
            transform.position = Vector3.MoveTowards(transform.position, goalPos, cameraSpeed * Time.deltaTime);
            yield return null;
        }
        while (timer>=0){
            timer -= Time.deltaTime;
            yield return null;
        }
        while (transform.position != startPos) {
            transform.position = Vector3.MoveTowards(transform.position, startPos, cameraSpeed * Time.deltaTime);
            yield return null;
        }
        finishView = true;
        player.GetComponent<PlayerController>().UnfreezePlayer();
    }
}
