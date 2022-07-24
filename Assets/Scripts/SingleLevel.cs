using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// using UnityEngine.Analytics;
using UnityEngine.Networking;

public class SingleLevel : MonoBehaviour
{
    public GameObject[] passInfo;
    private int passIndex;
    // public GameObject restart;
    // public GameObject menu;
    public GameObject deadInfo;

    private int currentStarsNum = 0;
    public int levelIndex;
    private GameObject player;
    private HeartSystem heartSystem;
    private PlayerController playerController;
    private TimerController timerController;

    public float durationSessoin;
    float timeSpent;
    // int stars;

    public bool messageFlag = false;

    private string url = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSdGOqN5DYsR79HX0byJl7bJ_Eqo7aVJPFN7Mr1ObypHP7n9wg/formResponse";

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        heartSystem = player.GetComponent<HeartSystem>();
        playerController = player.GetComponent<PlayerController>();

        timerController = player.GetComponent<TimerController>();
        timerController.BeginTimer();
        // timeSpent = timerController.elapsedTime;
        // stars = player.GetComponent<Inventory>().stars;

        playerController.currentLevel = levelIndex;
        // AnalyticsResult levelResult =  Analytics.CustomEvent("repeatLevel", new Dictionary<string, object>{{"Level", levelIndex}});
        // Debug.Log("level analytics "+levelResult);
        WWWForm form = new WWWForm();
        form.AddField("entry.1378015617", levelIndex);
        UnityWebRequest www = UnityWebRequest.Post(url, form);
        www.SendWebRequest();
    }

    void Update()
    {
        durationSessoin += Time.deltaTime * durationSessoin;

        StarRecord();

        if(heartSystem.dead)
        {
            deadInfo.SetActive(true);
            // restart.SetActive(true);
            // menu.SetActive(true);
            if (!messageFlag)
            {
                PlayerDied();
                messageFlag = true;
            }
        }

        for (int i = 0; i < passInfo.Length; i++)
        {
            if (i == passIndex)
            {
                passInfo[i].SetActive(true);
            }
            else
            {
                passInfo[i].SetActive(false);
            }
        }


    }

    public void BackButton()
    {
        SceneManager.LoadScene("Level Selection");
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    //public void PressStarsButton(int _starsNum)
    // {
    //     currentStarsNum = _starsNum;

    //     if (currentStarsNum > PlayerPrefs.GetInt("Lv" + levelIndex))
    //     {
    //         PlayerPrefs.SetInt("Lv" + levelIndex, _starsNum);
    //     }

    //     //BackButton();
    //     //MARKER Each level has saved their own stars number
    //     //CORE PLayerPrefs.getInt("KEY", "VALUE"); We can use the KEY to find Our VALUE
    //     Debug.Log(PlayerPrefs.GetInt("Lv" + levelIndex, _starsNum));

    //     // BackButton();
    // }

    public void StarRecord()
    {
        // Player get the destination
        if (playerController.playVictoryAnimation)
        {
            // restart.SetActive(true);
            // menu.SetActive(true);
            if (heartSystem.life == 1)
            {
                currentStarsNum = 1;
                passIndex = 1; //1 star pass
            }
            else if (heartSystem.life == 2)
            {
                currentStarsNum = 2;
                passIndex = 2;  //2 star pass
            }
            else if (heartSystem.life == 3)
            {
                currentStarsNum = 3;
                passIndex = 3;  //3 star pass
            }


            if (currentStarsNum > PlayerPrefs.GetInt("Lv" + levelIndex))
            {
                PlayerPrefs.SetInt("Lv" + levelIndex, currentStarsNum);
            }

            // Debug.Log(PlayerPrefs.GetInt("Lv" + levelIndex, currentStarsNum));

            if (!messageFlag)
            {
                //timeSpent = timerController.elapsedTime;
                //// stars = player.GetComponent<Inventory>().stars;
                //// level win and how many starts
                //AnalyticsResult analyticsResult = Analytics.CustomEvent("LevelWin_", new Dictionary<string, object>{{"Stars", currentStarsNum },{"Level", levelIndex}});
                //// Debug.Log("AnalyticsResult"+ analyticsResult);
                //// Debug.Log(PlayerPrefs.GetInt("LevelWin" + levelIndex, currentStarsNum));
                //// time spent in Level
                //Analytics.CustomEvent("time_spent_Level", new Dictionary<string, object>{{"time_spent_Level", timeSpent}});
                //messageFlag = true;

                timeSpent = timerController.elapsedTime;
                WWWForm form = new WWWForm();
                form.AddField("entry.994881676", levelIndex + " " + timeSpent + " " + currentStarsNum);
                UnityWebRequest www = UnityWebRequest.Post(url, form);
                www.SendWebRequest();

                messageFlag = true;
            }

        }

    }

    public void PlayerDied()
    {
        // AnalyticsResult analyticsResult = Analytics.CustomEvent("PlayerDied", new Dictionary<string, object> { { "Level", levelIndex } });
        // Debug.Log("AnalyticsResult" + analyticsResult);
        // Debug.Log("Die"+PlayerPrefs.GetInt("PlayerDied" + levelIndex, currentStarsNum));

        WWWForm form = new WWWForm();
        form.AddField("entry.630080447", levelIndex);
        UnityWebRequest www = UnityWebRequest.Post(url, form);
        www.SendWebRequest();
    }

}
