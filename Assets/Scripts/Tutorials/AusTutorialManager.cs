using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AusTutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    public float TimeLimit = 1f;
    private int popUpIndex;

    private GameObject player;
    private AusTutorialDetect detector;
    private float timer;
    private PlayerController playerController;

    // private float timer = 0f;

// Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        detector = player.GetComponent<AusTutorialDetect>();
        timer = TimeLimit;
        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < popUps.Length; i++)
        {
            if(i == popUpIndex)
            {
                popUps[i].SetActive(true);
            } else {
                popUps[i].SetActive(false);
            }
        }

        if(popUpIndex == 0) {
            if (detector.detect1 == true)
            {
                popUpIndex++;
            }
        } else if(popUpIndex == 1) {
            timer -= Time.deltaTime;
            // player.SetActive(false);
            // while (!playerController.FreezePlayer()) {
            //     Debug.Log("waiting");
            // }
            playerController.FreezePlayer();
            if (Input.GetKeyDown(KeyCode.Space) && timer<=0)
            {
                playerController.UnfreezePlayer();
                
                popUpIndex++;
            }
        }
    }
}
