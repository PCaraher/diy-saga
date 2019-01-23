using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loader : MonoBehaviour {

    public GameObject gameManager;
    //public Scene nxtScene;
    //public static Scene nextScene;
    public string nextScene;
    public static string nxtScene;
    //public Image nextLevel;
    //public static Image nxtLvl;

	// Use this for initialization
	void Awake ()
    {
        //if (GameManager.instance == null)
        //    Instantiate(gameManager);

        nxtScene = nextScene;
        //nextLevel = gameObject.GetComponent<Image>();
        //nxtLvl = nextLevel;
	}

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        ScoreScript.scoreValue = 0;
    }

}
