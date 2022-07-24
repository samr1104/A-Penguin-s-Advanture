using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TimeLimit : MonoBehaviour
{
    public float timeLimit;
    private float timeCount;
    public GameObject timeCounter;

    private HeartSystem heartSystem;

    private CameraController camera;

    void Start()
    {
        // timeCounter = GameObject.FindGameObjectWithTag("Count");
        heartSystem = gameObject.GetComponent<HeartSystem>();
        camera = GameObject.FindGameObjectWithTag("Camera").GetComponent<CameraController>();
        timeCount = timeLimit;
    }

    // Update is called once per frame
    void Update()
    {
        if(camera.finishView == true) {
            timeLimit-=Time.deltaTime;
            if (timeLimit<=(timeCount + 0.9)) {
                if (timeCounter.activeSelf == false) timeCounter.SetActive(true);
                timeCounter.GetComponent<TMP_Text>().text = "Remaining time: " + ((int)timeLimit).ToString();
            }
            if (timeLimit<=0){
                // transform.gameObject.SetActive(false);
                heartSystem.dead = true;
                timeCounter.GetComponent<TMP_Text>().text = "Time out!";
                // audio
                SoundManager.PlayDieClip();
            }
        }
        
    }
}
