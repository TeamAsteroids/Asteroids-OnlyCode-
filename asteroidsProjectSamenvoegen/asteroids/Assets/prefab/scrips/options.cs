using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class options : MonoBehaviour
{

    private bool showOptions = false;
    public float shadowDrawDistance;
    public int ResX;
    public int ResY;
    public bool Fullscreen;
    // Use this for initialization
    void Start()
    {
        showOptions = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(500, 100, 300, 100), "Start Game"))
        {
            SceneManager.LoadScene(1);
        }
        if (GUI.Button(new Rect(500, 210, 300, 100), "Quit Game"))
        {
            Application.Quit();
        }
        if (GUI.Button(new Rect(500, 320, 300, 100), "Options Menu"))
        {
            if (!showOptions)
            {
                showOptions = true;

            }
            else
            {
                showOptions = false;
            }
        }
        if (showOptions == true)
        {
            //INCREASE QUALITY PRESET
            if (GUI.Button(new Rect(810, 100, 300, 100), "Increase Quality"))
            {
                QualitySettings.IncreaseLevel();
                Debug.Log("Increased quality");
            }
            //DECREASE QUALITY PRESET
            if (GUI.Button(new Rect(810, 210, 300, 100), "Decrease Quality"))
            {
                QualitySettings.DecreaseLevel();
                Debug.Log("Decreased quality");
            }
            
           
            //60Hz
            if (GUI.Button(new Rect(190, 320, 300, 100), "60Hz"))
            {
                Screen.SetResolution(ResX, ResY, Fullscreen, 60);
                Debug.Log("60Hz");
            }
            //120Hz
            if (GUI.Button(new Rect(190, 430, 300, 100), "120Hz"))
            {
                Screen.SetResolution(ResX, ResY, Fullscreen, 120);
                Debug.Log("120Hz");
            }
            //1080p
            if (GUI.Button(new Rect(500, 430, 93, 100), "1080p"))
            {
                Screen.SetResolution(1920, 1080, Fullscreen);
                ResX = 1920;
                ResY = 1080;
                Debug.Log("1080p");
            }
            //720p
            if (GUI.Button(new Rect(596, 430, 93, 100), "720p"))
            {
                Screen.SetResolution(1280, 720, Fullscreen);
                ResX = 1280;
                ResY = 720;
                Debug.Log("720p");
            }
            //480p
            if (GUI.Button(new Rect(692, 430, 93, 100), "480p"))
            {
                Screen.SetResolution(640, 480, Fullscreen);
                ResX = 640;
                ResY = 480;
                Debug.Log("480p");
            }
            if (GUI.Button(new Rect(500, 0, 140, 100), "Vsync On"))
            {
                QualitySettings.vSyncCount = 1;
            }
            if (GUI.Button(new Rect(645, 0, 140, 100), "Vsync Off"))
            {
                QualitySettings.vSyncCount = 0;
            }
        }
    }
}