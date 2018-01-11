using System;
//using System.Data;
//using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;





public class HighScoreinput : MonoBehaviour
{
    //SqlConnection conn = new SqlConnection("Server= LocalHost; Database= Astroids; User Id=Root; Password = ;");
    internal Button btn;
    public InputField nameInputField;
    public Button btnHScore;
    public ulong HighScore;
    public string stringToEdit = "Enter your name here...";

    string name = "";
    string score = "";
    List<Scores> highscore;



    // Use this for initialization
    void Start()
    {
        
        HighScore = 0;
    
    }




    // Update is called once per frame
    private void Update()
    {
        if (btnHScore.enabled)
        {
            //ClickHighInput();
           
        }
       // Debug.Log(conn.ConnectionString);
 


    }

    void OnGUI()
    {
        stringToEdit = GUI.TextField(new Rect(500, 280, 300, 30), stringToEdit, 25);
        if (GUI.Button(new Rect(500, 320, 300, 100), "Submit"))
        {
            //ClickHighInput(stringToEdit);
     
            
        }

        if (GUILayout.Button("Add Score"))
        {
            HighScoreManager._instance.SaveHighScore(name, System.Int32.Parse(score));
            highscore = HighScoreManager._instance.GetHighScore();
        }

        if (GUILayout.Button("Get LeaderBoard"))
        {
            highscore = HighScoreManager._instance.GetHighScore();
        }

        if (GUILayout.Button("Clear Leaderboard"))
        {
            HighScoreManager._instance.ClearLeaderBoard();
        }

        GUILayout.Space(60);

        GUILayout.BeginHorizontal();
        GUILayout.Label("Name", GUILayout.Width(Screen.width / 2));
        GUILayout.Label("Scores", GUILayout.Width(Screen.width / 2));
        GUILayout.EndHorizontal();

        GUILayout.Space(25);

        foreach (Scores _score in highscore)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label(_score.name, GUILayout.Width(Screen.width / 2));
            GUILayout.Label("" + _score.score, GUILayout.Width(Screen.width / 2));
            GUILayout.EndHorizontal();
        }

    }
}
