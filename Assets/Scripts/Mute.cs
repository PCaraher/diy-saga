using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mute : MonoBehaviour
{

    bool soundToggle = true;
    public GameObject audioSource; //Audio Listener
    //public AudioSource audioSource;

    private void OnGUI()
    {
        soundToggle = !soundToggle;
        if (soundToggle)
        {
            audioSource.SetActive(true);
            

        }
        else
        {
            audioSource.SetActive(false);

        }

    }
}
