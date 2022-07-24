using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaTutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    public float timeLimit = 1f;
    private int popUpIndex;

    private GameObject player;
    private HaTutorialDetect detector;
    private PlayerController playerController;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        detector = player.GetComponent<HaTutorialDetect>();
        timer = timeLimit;
        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
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
            if (detector.detect1 == true)
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 1)
        {
            timer -= Time.deltaTime;
            playerController.FreezePlayer();
            if (Input.GetKeyDown(KeyCode.Space) && timer<=0)
            {
                playerController.UnfreezePlayer();
                // playerController.isMoving = false;
                timer = timeLimit;
                popUpIndex++;
            }
        }
        else if (popUpIndex == 2)
        {
            if (detector.detect2 == true)
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 3)
        {
            timer -= Time.deltaTime;
            playerController.FreezePlayer();
            if (Input.GetKeyDown(KeyCode.Space) && timer<=0)
            {
                playerController.UnfreezePlayer();
                // playerController.isMoving = false;
                timer = timeLimit;
                popUpIndex++;
            }
        }
    }
}
