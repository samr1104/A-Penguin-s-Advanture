using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpIndex;

    public GameObject box1;
    private GameObject player;
    private TutorialDetector detector;
    public GameObject bomb;
    private Inventory inventory;
    private float timer = 0f;
    private float timer4 = 0f;

    // remind enemy
    private int currIndex;
    private int specialIndex = 8;
    private float timer2 = 0f;
    private bool remind = false;

    // wait time
    private PlayerController playerController;
    private float timer3 = 0f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        detector = player.GetComponent<TutorialDetector>();
        inventory = player.GetComponent<Inventory>();
        // specialIndex = popUps.Length - 1;
        playerController = player.GetComponent<PlayerController>();
    }

    void Update()
    {
        for(int i = 0; i < popUps.Length; i++)
        {
            if(i == popUpIndex)
            {
                popUps[i].SetActive(true);
                if(i == 1) {
                    // Boxes change Color
                    box1.GetComponent<ChangeColor>().active = true;
                    // Debug.Log("active change color.");
                } else if(inventory.isFull[0] == false && i == 4) {
                    // Bomb Animator active
                    bomb.GetComponent<Animator>().enabled = true;
                }
            } else {
                popUps[i].SetActive(false);
            }
        }
        
        if(popUpIndex == 0) {
            if (Input.GetKeyDown(KeyCode.D))
            {
                popUpIndex++;
            }
        } else if(popUpIndex == 1) {
            if (detector.detect1 == true)
            {
                popUpIndex++;
                box1.GetComponent<ChangeColor>().active = false;
            }
        } else if(popUpIndex == 2) {
            // timer3 += Time.deltaTime;
            // playerController.isMoving = true;
            //if (timer3 >= 2f)
            //{
            //    playerController.isMoving = false;
            //}
            if (detector.detect2 == true)
            {
                popUpIndex++;
                // timer3 = 0f;
            }
        } else if(popUpIndex == 3) {
            timer += Time.deltaTime;
            // playerController.isMoving = true;
            if (timer >= 2f)
            {
                popUpIndex++;
                // playerController.isMoving = false;
            }
        } else if(popUpIndex == 4) {
            //timer3 += Time.deltaTime;
            //playerController.isMoving = true;
            //if (timer3 >= 2f)
            //{
            //    playerController.isMoving = false;
            //}
            if (inventory.isFull[0] == true)
            {
                popUpIndex++;
                // timer3 = 0f;
            } else if (!remind)
            {
                if (detector.detect3 == true || (detector.detect4 == true || detector.detect5 == true))
                {
                    currIndex = 4;
                    popUpIndex = specialIndex;
                    remind = true;
                    timer2 = 0f;
                }
            }
        } else if(popUpIndex == 5) {
            timer4 += Time.deltaTime;
            // player.GetComponent<Rigidbody>
            playerController.FreezePlayer();
            if (timer4 >= 1f && (Input.GetKeyDown(KeyCode.Space)))
            {
                playerController.UnfreezePlayer();
                popUpIndex++;
            }
        } else if(popUpIndex == 6) {
            if (inventory.isFull[0] == false)
            {
                popUpIndex++;
            } else if (!remind)
            {
                if (detector.detect3 == true || (detector.detect4 == true || detector.detect5 == true))
                {
                    currIndex = 6;
                    popUpIndex = specialIndex;
                    remind = true;
                    timer2 = 0f;
                }
            }
        } else if(popUpIndex == specialIndex)
        {
            timer2 += Time.deltaTime;
            // playerController.isMoving = true;
            if (timer2 >= 2f)
            {
                popUpIndex = currIndex;
                timer2 = 0f;
                // playerController.isMoving = false;

                if (inventory.isFull[0] == true)
                {
                    popUpIndex++;
                }
            }
        }
    }
}
