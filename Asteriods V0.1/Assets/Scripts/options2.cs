using System.Collections;
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

    // Use this for initialization
    void Start()
    {
        OnGUI();

    }
	
	// Update is called once per frame
	void Update () {

    }
    private void OnGUI()
    {
        //INCREASE QUALITY PRESET
        //if (GUI.HorizontalSlider(new Rect(500, 110, 300, 100), 5,0,5 ))
        //{
        //    QualitySettings.IncreaseLevel();
        //    Debug.Log("Increased quality");
        //}
        //GUI.HorizontalSlider(new Rect(500, 110, 300, 100), 50, 50,0);
        ////DECREASE QUALITY PRESET
        //if (GUI.Button(new Rect(500, 220, 300, 100), "Decrease Quality"))
        //{
        //    QualitySettings.DecreaseLevel();
        //    Debug.Log("Decreased quality");
        //}

        ///Create a horizontal Slider that controls volume levels.Its highest value is 1 and lowest is 0
        new Rect(500, 100, 300, 100);
        m_MySliderValue = GUI.HorizontalSlider(new Rect(500, 150, 300, 100), m_MySliderValue, 0.0F, 1.0F);
        //Makes the volume of the Audio match the Slider value
        AudioListener.volume = m_MySliderValue;

       



        //1080p
        if (GUI.Button(new Rect(500, 330, 95, 100), "1080p"))
        {
            Screen.SetResolution(1920, 1080, Fullscreen);
            ResX = 1920;
            ResY = 1080;
            Debug.Log("1080p");
        }
        //720p
        if (GUI.Button(new Rect(605, 330, 95, 100), "720p"))
        {
            Screen.SetResolution(1280, 720, Fullscreen);
            ResX = 1280;
            ResY = 720;
            Debug.Log("720p");
        }
        //480p
        if (GUI.Button(new Rect(705, 330, 95, 100), "480p"))
        {
            Screen.SetResolution(640, 480, Fullscreen);
            ResX = 640;
            ResY = 480;
            Debug.Log("480p");
        }
       
        if (QualitySettings.vSyncCount == 0)
        {
            if (GUI.Button(new Rect(500, 0, 300, 100), "Vsync On"))
            {
                QualitySettings.vSyncCount = 1;
            }

        }
        else
        {
            if (GUI.Button(new Rect(500, 0, 300, 100), "Vsync Off"))
            {
                QualitySettings.vSyncCount = 0;
            }
        }



    }
}
