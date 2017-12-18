using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public int Gamemode = 1;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Debug.Log("QUIT!"); //voor console
        Application.Quit();
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




        switch (Gamemode)
        {
            case 1:
                if (GUI.Button(new Rect(500, 130, 300, 100), "Gamemode 1"))
                {
                    Gamemode = 2;
                }
                break;

            case 2:
                if (GUI.Button(new Rect(500, 130, 300, 100), "Gamemode 2"))
                {
                    Gamemode = 3;
                }
                break;

            case 3:

                if (GUI.Button(new Rect(500, 130, 300, 100), "Gamemode 3"))
                {
                    Gamemode = 1;
                }
                break;
        }
        if (GUI.Button(new Rect(500, 260, 300, 100), "Options"))
        {
            QuitGame();
        }
        //if (GUI.Button(new Rect(500, 390, 300, 100), "Credits"))
        //{
        //    QuitGame();
        //}




        if (GUI.Button(new Rect(500, 0, 300, 100), "Quit"))
        {
            QuitGame();
        }

        if (GUI.Button(new Rect(500, 0, 300, 100), "Start"))
            {
            PlayGame();
            }



    }
}
