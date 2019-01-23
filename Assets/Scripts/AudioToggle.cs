using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioToggle : MonoBehaviour {

    private float volume;
    Toggle m_Toggle;
    public Text m_Text;

    // Use this for initialization
    //void Start () {

    //    m_Toggle = GetComponent<Toggle>();

    //    m_Toggle.onValueChanged.AddListener(delegate {
    //        ToggleValueChanged(m_Toggle);
    //    });

    //}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnEnable()
    {
        volume = AudioListener.volume;

        if (volume <= 0)
        {
            m_Toggle.isOn = true;
        }
        else {
            m_Toggle.isOn = false;
        }
        
    }

    public void OnValueChanged(float vol)
    {
        AudioListener.volume = vol;
    }

    //void ToggleValueChanged(Toggle change)
    //{
    //    m_Text.text = "Toggle is : " + m_Toggle.isOn;
    //}
}
