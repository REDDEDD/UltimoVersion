using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class GoogleController : MonoBehaviour {

    public Button ranking;
    public Button logros;

    public bool isConected;

	// Use this for initialization
	void Start () {
        ranking.onClick.AddListener(showRank);
        logros.onClick.AddListener(showAchievements);

        /*PlayGamesPlatform.Activate();
        PlayGamesPlatform.DebugLogEnabled = true;*/

        if (!isConected)
        {
            Social.localUser.Authenticate((bool success) =>
            {
                isConected = success;
            });
        }
    }

    void showRank()
    {
        if (Social.localUser.authenticated)
        {
            Social.ShowLeaderboardUI();
        }
    }

    void showAchievements()
    {
        if (Social.localUser.authenticated)
        {
            Social.ShowAchievementsUI();
        }
    }

    void unlockAchievement(string achievementID)
    {
        Social.ReportProgress(achievementID, 100.0f, (bool success) =>
        {
            Debug.Log("achievemetn unclokced" + success.ToString());
        });
    }

    /*void ReportScore(int score)
    {
        Social.ReportProgress(score,RPGPS.leaderboard_highscore, (bool success) => 
        {
            Debug.Log("reportes score to leaderbord" + success.ToString());
        })
    }*/
}
