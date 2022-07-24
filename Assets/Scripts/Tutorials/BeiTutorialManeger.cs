using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeiTutorialManeger : MonoBehaviour
{
    public GameObject[] popUps;
    public float timeLimit = 1f;
    private int popUpIndex;

    private GameObject player;
    private PlayerController playerController;
    private float timer;
    private CameraController camera;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        camera = GameObject.Find("Camera").GetComponent<CameraController>();
        timer = timeLimit;
    }

    // Update is called once per frame
    void Update()
    {
        if (camera.finishView==false) return;
        for (int i = 0; i < popUps.Length; i++)
        {
            if (i == popUpIndex)
            {
                popUps[i].SetActive(true);
            }
            else
            {
                popUps[i].SetActive(false);
            }
        }

        if (popUpIndex == 0)
        {
            timer -= Time.deltaTime;
            playerController.FreezePlayer();
            if (Input.GetKeyDown(KeyCode.Space) && timer<=0)
            {
                playerController.UnfreezePlayer();
                timer = timeLimit;
                popUpIndex++;
            }
        }
    }
}
