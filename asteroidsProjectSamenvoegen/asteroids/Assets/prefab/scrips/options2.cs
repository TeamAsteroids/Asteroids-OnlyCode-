﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class options2 : MonoBehaviour {
    private bool showOptions = false;
    public float shadowDrawDistance;
    public int ResX;
    public int ResY;
    public bool Fullscreen;
    public int overallQualityInt;
    public SliderJoint2D mainSlider;
    public float m_MySliderValue;
    private  float center = Screen.width / 2 ;


    // Use this for initialization
    void Start()
    {


    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("Esc")){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

        }
          
    }
    private void OnGUI()
    {
     

        ///Create a horizontal Slider that controls volume levels.Its highest value is 1 and lowest is 0
        new Rect(500, 100, 300, 100);
        m_MySliderValue = GUI.HorizontalSlider(new Rect(center - 50, 150, 300, 100), m_MySliderValue, 0.0F, 1.0F);
        //Makes the volume of the Audio match the Slider value
        AudioListener.volume = m_MySliderValue;

       



        //1080p
        if (GUI.Button(new Rect(center - 50, 200, 95, 100), "1080p"))
        {
            Screen.SetResolution(1920, 1080, Fullscreen);
            ResX = 1920;
            ResY = 1080;
            Debug.Log("1080p");
        }
        //720p
        if (GUI.Button(new Rect(center +50, 200, 95, 100), "720p"))
        {
            Screen.SetResolution(1280, 720, Fullscreen);
            ResX = 1280;
            ResY = 720;
            Debug.Log("720p");
        }
        //480p
        if (GUI.Button(new Rect(center +150, 200, 95, 100), "480p"))
        {
            Screen.SetResolution(640, 480, Fullscreen);
            ResX = 640;
            ResY = 480;
            Debug.Log("480p");
        }
        if (GUI.Button(new Rect(center - 50, 330, 300, 100), "Back"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

        if (QualitySettings.vSyncCount == 0)
        {
            if (GUI.Button(new Rect(center - 50, 0, 300, 100), "Vsync On"))
            {
                QualitySettings.vSyncCount = 1;
            }

        }
        else
        {
            if (GUI.Button(new Rect(center - 50, 0, 300, 100), "Vsync Off"))
            {
                QualitySettings.vSyncCount = 0;
            }
        }



    }
}
