using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScoreMenuController : MonoBehaviour
{

    string name = "";
    public int score;
    List<Scores> highscore;
    private bool clicked = false;

    // Use this for initialization
    void Start()
    {
        //EventManager._instance._buttonClick += ButtonClicked;

        highscore = new List<Scores>();

    }


    void ButtonClicked(GameObject _obj)
    {
        print("Clicked button:" + _obj.name);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("Name :");
        name = GUILayout.TextField(name);
        GUILayout.EndHorizontal();


        if (GUILayout.Button("Add Score") && !clicked )
        {
            HighScoreManager._instance.SaveHighScore(name, score);
            highscore = HighScoreManager._instance.GetHighScore();
            clicked = true;
           
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