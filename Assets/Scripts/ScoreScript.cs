using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour {

    public static int scoreValue = 0;
    TextMeshProUGUI score;
    private int temp;


    void Start()
    {
        score = GetComponent<TextMeshProUGUI>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        score.text = "Score: " + scoreValue;
	}

    
    public void ButtonPress()
    {
        scoreValue = 0;
    }
}
