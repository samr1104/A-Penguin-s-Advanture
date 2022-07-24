using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementController : MonoBehaviour
{
    private GameObject player;
    public int levelNumber;

    // Achivement: KillAll, KillZero
    public int numEnemy;
    // private int numKillEnemy = 0;

    // Achivement: PickAll, UseNone
    public int numTool = 0;
    private int numPickTool = 0;
    private bool useTool = false;
    private Inventory inventory;

    // Achivement: FullHearts
    private HeartSystem heartSystem;

    // Set used achivements
    public GameObject[] achievements; // 5 achievements, only 3 used are not transparent at right position for the specific level; all active=false at beginning
    public GameObject[] failAchievements; // 5 fail achievements
    //public bool killAll = false;
    //public bool killZero = false;
    //public bool pickAll = false;
    //public bool useNone = false;
    //public bool fullHearts = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        heartSystem = player.GetComponent<HeartSystem>();
        inventory = player.GetComponent<Inventory>();
        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        numEnemy = allEnemies.Length;
        Debug.Log("enemy number: " + numEnemy);
    }

    private void OnDisable()
    {
        Invoke("wait", 1);
    }

    void wait()
    {
        if (!heartSystem.dead)
        {
            // numKillEnemy = player.gameObject.GetComponent<PlayerController>().enemyKill;
            numPickTool = player.gameObject.GetComponent<PlayerController>().itemPickup;
            int numPlayerTool = 0;
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == true)
                {
                    numPlayerTool++;
                }
            }
            if(numPlayerTool < numPickTool)
            {
                useTool = true;
            }

            GameObject[] aliveEnemies = GameObject.FindGameObjectsWithTag("Enemy");
            int numAliveEnemy = aliveEnemies.Length;

            // Set Achievements
            if (numAliveEnemy == 0)
            {
                achievements[0].gameObject.SetActive(true);
                PlayerPrefs.SetInt("killAll" + levelNumber, 1);
            } else
            {
                failAchievements[0].gameObject.SetActive(true);
            }
                
            if (numAliveEnemy == numEnemy)
            {
                achievements[1].gameObject.SetActive(true);
                PlayerPrefs.SetInt("killZero" + levelNumber, 1);
            } else
            {
                failAchievements[1].gameObject.SetActive(true);
            }
                
            if (numPickTool == numTool)
            {
                // Debug.Log("pick up all tools!");
                achievements[2].gameObject.SetActive(true);
                PlayerPrefs.SetInt("pickAll" + levelNumber, 1);
            } else
            {
                failAchievements[2].gameObject.SetActive(true);
            }
                
            if (!useTool)
            {
                // Debug.Log("did not use tools!");
                achievements[3].gameObject.SetActive(true);
                PlayerPrefs.SetInt("useNone" + levelNumber, 1);
            } else
            {
                // Debug.Log("did use tools!");
                failAchievements[3].gameObject.SetActive(true);
            }
                
            if (heartSystem.life == 3)
            {
                achievements[4].gameObject.SetActive(true);
                PlayerPrefs.SetInt("fullHearts" + levelNumber, 1);
            } else
            {
                failAchievements[4].gameObject.SetActive(true);
            }
                
        }
    }
}
