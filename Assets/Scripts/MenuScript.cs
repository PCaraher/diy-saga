using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Analytics;

public class MenuScript : MonoBehaviour {

    public TextMeshProUGUI highscore;
    public TextMeshProUGUI totalScore;

    //Method to load a scene with the name sceneName
    //Resets the time scale and score value as the time scale is changed in the game scenes
    public void ChangeScene(string sceneName)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        ScoreScript.scoreValue = 0;
    }

    //Gets and sets the values for highscore and total score
    //Highscore and total score are stored in PlayerPrefs to persist across sessions
    private void Awake()
    {
        highscore.GetComponent<TextMeshProUGUI>();
        totalScore.GetComponent<TextMeshProUGUI>();
        highscore.text = "Highscore " + PlayerPrefs.GetInt("Highscore") + "!";

        PlayerPrefs.SetInt("Total", ScoreScript.scoreValue + PlayerPrefs.GetInt("Total"));
        totalScore.text = "Total Points " + PlayerPrefs.GetInt("Total") + "!";
        
    }

    //The total score is updated here because MenuScript is used in the store where the total score is used as currency
    //and will be updated if the player buys something or watches an ad
    private void Update()
    {
        totalScore.text = "Total Points " + PlayerPrefs.GetInt("Total") + "!";
    }

    //When the store button is pressed will send a custom event to unity analytics
    public void OnStoreEnter()
    {
        AnalyticsEvent.Custom("storeEntered", new Dictionary<string, object>
        {
            { "points", PlayerPrefs.GetInt("Total") }
        });
    }

}
