using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;





public class HighScoreinput : MonoBehaviour
{
    internal SqlConnection conn = new SqlConnection();
    internal Button btn;
    public InputField nameInputField;
    public Button btnHScore;
    public ulong HighScore;


    // Use this for initialization
    void Start()
    {
        nameInputField = nameInputField.GetComponent<InputField>();
        btn = btnHScore.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        HighScore = 0;
        conn.ConnectionString =
        "Data Source= 127.0.0.1;" +
        "Initial Catalog= Astroids;" +
        "User id= Root;" +
        "Password=;";

    }

    // Update is called once per frame
    private void Update()
    {
        if (btnHScore.enabled)
        {
            ClickHighInput();
        }
        
    }
    private void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
        string name = nameInputField.text;
        ulong score = HighScore;
        string query = "INSERT INTO Highscore (Score, Name)VALUES({0}, {1});, ";


        conn.Open();
        SqlCommand command = new SqlCommand(query, conn);
        command.Connection.Open();
        command.ExecuteNonQuery();
        conn.Close();


    }
    public void ClickHighInput()
    {
        HighScore = 0;
        conn.ConnectionString =
        "Data Source= 127.0.0.1;" +
        "Initial Catalog= Astroids;" +
        "User id= Root;" +
        "Password=;";

        Debug.Log("You have clicked the button!");
        string name = nameInputField.text;
        ulong score = HighScore;
        string query = "INSERT INTO Highscore (Score, Name)VALUES(" + score + "," + name + ");";


        conn.Open();
        SqlCommand command = new SqlCommand(query, conn);
        command.Connection.Open();
        command.ExecuteNonQuery();
        conn.Close();
    }
    private void Connect()
    {
       string server = "localhost";
       string database = "connectcsharptomysql";
       string uid = "username";
       string password = "password";
       string connectionString;

        connectionString = "SERVER=" + server + ";" + "DATABASE=" +
        database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

      //  MySqlConnection conn = new MySqlConnection(connectionString);
    }
}
