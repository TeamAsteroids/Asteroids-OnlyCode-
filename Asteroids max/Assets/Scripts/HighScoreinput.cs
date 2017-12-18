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


    // Use this for initialization
    void Start()
    {
        

        nameInputField = nameInputField.GetComponent<InputField>();
        btn = btnHScore.GetComponent<Button>();
        //btn.onClick.AddListener(TaskOnClick);
        HighScore = 0;
    
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
    public void ClickHighInput()
    {

        HighScore = 0;


        Debug.Log("You have clicked the button!");
        string name = nameInputField.text;
        ulong score = HighScore;
        string query = "INSERT INTO HighScores (Score, Name)VALUES(" + score + "," + name + ");";


        SqlCommand command = new SqlCommand(query, conn);
        command.Connection.Open();
        command.ExecuteNonQuery();
      
    }
    void OnGUI()
    {
        if (GUI.Button(new Rect(500, 320, 300, 100), "Submit"))
        {
           // GUI.TextField hinput = new GUI.TextField(new Rect(500, 100, 300, 100), "Start Game");

        }
    }
}
