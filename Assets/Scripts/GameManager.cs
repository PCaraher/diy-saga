using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Advertisements;
using UnityEngine.Analytics;

public class GameManager : MonoBehaviour
{

    private GameObject[] taskCounter;   //To hold the current number of tasks in the scene
    private GameObject nextLevel;       //nextLevel is the UI that will show when the player completes the level
    private GameObject failScreen;      //failScreen is the UI that will show if the player fails the level
    public float targetTime = 6.0f;     //The time limit for the level, can be accessed and changed in the editor
    public TextMeshProUGUI timer;       //The timer TMP Text 


    void Awake()
    {
        Time.timeScale = 1;
        nextLevel = GameObject.FindGameObjectWithTag("Next Level");
        failScreen = GameObject.FindGameObjectWithTag("Fail Screen");
        taskCounter = GameObject.FindGameObjectsWithTag("Task") as GameObject[];
    }


    // Update is called once per frame
    void Update()
    {
        //Gets all the Task game objects and checks when it's empty
        //If it's empty the player has completed the level and the next level UI is moved into the camera view
        taskCounter = GameObject.FindGameObjectsWithTag("Task") as GameObject[];
        if (taskCounter.Length == 0)
        {
            Time.timeScale = 0;
            nextLevel.transform.position = new Vector3(0f, 0f, -2f);
        }
        targetTime -= Time.deltaTime;
        targetTime = Mathf.Round(targetTime * 100f) / 100f;
        timer.text = "Time: " + targetTime;

        //When time runs out set the high score, destroy the rest of the tasks and move the fail screen into
        //the camera view
        if (targetTime <= 0.0f)
        {
            if (ScoreScript.scoreValue > PlayerPrefs.GetInt("Highscore"))
            {
                PlayerPrefs.SetInt("Highscore", ScoreScript.scoreValue);
            }
            foreach (GameObject i in taskCounter)
            {
                Destroy(i);
            }
            Time.timeScale = 0;
            failScreen.transform.position = new Vector3(0f, 0f, -2f);
            
        }
    }

    public void ChangeScene(string sceneName)
    {      
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    //If the player wants to restart from the same level then they can watch an ad
    public void ContinueButton() {
        Advertisement.Show();
    }

    public void ShowRewardedAd()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("rewardedVideo", options);
        }
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                //Is this level too hard?
                AnalyticsEvent.Custom("continueAd", new Dictionary<string, object>
                {
                 { SceneManager.GetActiveScene().name, PlayerPrefs.GetInt("Highscore") }
                });

                ChangeScene(SceneManager.GetActiveScene().name);
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                AnalyticsEvent.Custom("ad_Skipped");
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                AnalyticsEvent.Custom("ad_Failed");
                break;
        }

    }
}
