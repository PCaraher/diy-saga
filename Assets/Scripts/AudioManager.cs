using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour {

    private static AudioSource _instance;
    //public AudioSource audio;

    public static AudioSource instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<AudioSource>();

                //Tell unity not to destroy this object when loading a new scene!
                DontDestroyOnLoad(_instance.gameObject);
            }

            return _instance;
        }
    }

    void Awake()
    {
        
            if (_instance == null)
            {
                //If I am the first instance, make me the Singleton
                _instance = gameObject.GetComponentInParent<AudioSource>();
                DontDestroyOnLoad(this);

            }
            else
            {
                //If a Singleton already exists and you find
                //another reference in scene, destroy it!
                if (this != _instance)
                    Destroy(this.gameObject);
            }
            //audio = GetComponent<AudioSource>();
            //if (!audio.enabled)
            //    audio.enabled = true;
        
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Main Menu")
        {
            Destroy(this.gameObject);
        }
    }
}
