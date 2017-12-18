using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;





public class HighScoreinput : MonoBehaviour
{
    SqlConnection conn = new SqlConnection("Server= LocalHost; Database= Astroids; User Id=Root; Password = ;");
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


    void Createdb()
    {
        SqlConnection connection = new SqlConnection(@"server=(localdb)\v11.0");
        using (connection)
        {
            connection.Open();

            string sql = string.Format(@"
        CREATE DATABASE
            [Asteroids]
        ON PRIMARY (
           NAME=Test_data,
           FILENAME = '{0}\Test_data.mdf'
        )
        LOG ON (
            NAME=Test_log,
            FILENAME = '{0}\Test_log.ldf'
        )",
                @"D:"
            );

            SqlCommand command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (btnHScore.enabled)
        {
            //ClickHighInput();
           
        }
        Debug.Log(conn.ConnectionString);
 


    }
    //private void TaskOnClick()
    //{
    //    Debug.Log("You have clicked the button!");
    //    string name = nameInputField.text;
    //    ulong score = HighScore;
    //    string query = "INSERT INTO Highscore (Score, Name)VALUES({0}, {1});, ";


    //    conn.Open();
    //    SqlCommand command = new SqlCommand(query, conn);
    //    command.Connection.Open();
    //    command.ExecuteNonQuery();
    //    conn.Close();


    //}
    public void ClickHighInput(string namein)
    {

        HighScore = 0;

        string name = namein;
        ulong score = HighScore;
        string query = "INSERT INTO HighScores (Score, Name)VALUES(" + score + "," + name + ");";


        SqlCommand command = new SqlCommand(query, conn);
        command.Connection.Open();
        command.ExecuteNonQuery();
      
    }
    //void Write(string namein)
    //{
    //    string newFileName = "C:\\client_20100913.csv";

    //    string clientDetails = namein + "," + HighScore;


    //    //if (!File.Exists(newFileName))
    //    //{
    //    //    string clientHeader = "Client Name(ie. Billto_desc)" + "," + "Mid_id,billing number(ie billto_id)" + "," + "business unit id" + Environment.NewLine;

    //    //    File.WriteAllText(newFileName, clientHeader);
    //    //}

    //    File.AppendAllText(newFileName, clientDetails);
    //}
    void OnGUI()
    {
        stringToEdit = GUI.TextField(new Rect(500, 280, 300, 30), stringToEdit, 25);
        if (GUI.Button(new Rect(500, 320, 300, 100), "Submit"))
        {
            //ClickHighInput(stringToEdit);
            Createdb();
            
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
