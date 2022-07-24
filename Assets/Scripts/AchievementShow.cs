using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementShow : MonoBehaviour
{
    public int levelNumber;
    public GameObject[] achievements; // 5 achievements, only 3 used are not transparent at right position for the specific level; all active=false at beginning
    public GameObject[] failAchievements; // 5 fail achievements

    // Update is called once per frame
    void Update()
    {
        // killAll
        if(PlayerPrefs.GetInt("killAll" + levelNumber) == 1)
        {
            achievements[0].gameObject.SetActive(true);
        } else
        {
            failAchievements[0].gameObject.SetActive(true);
        }

        // killZero
        if (PlayerPrefs.GetInt("killZero" + levelNumber) == 1)
        {
            achievements[1].gameObject.SetActive(true);
        }
        else
        {
            failAchievements[1].gameObject.SetActive(true);
        }

        // pickAll
        if (PlayerPrefs.GetInt("pickAll" + levelNumber) == 1)
        {
            achievements[2].gameObject.SetActive(true);
        }
        else
        {
            failAchievements[2].gameObject.SetActive(true);
        }

        // useNone
        if (PlayerPrefs.GetInt("useNone" + levelNumber) == 1)
        {
            achievements[3].gameObject.SetActive(true);
        }
        else
        {
            failAchievements[3].gameObject.SetActive(true);
        }

        // fullHearts
        if (PlayerPrefs.GetInt("fullHearts" + levelNumber) == 1)
        {
            achievements[4].gameObject.SetActive(true);
        }
        else
        {
            failAchievements[4].gameObject.SetActive(true);
        }
    }
}
