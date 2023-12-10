using System;
using System.Data;
using MySql.Data.MySqlClient;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    private string connectionString; // Connection string for MySQL database
    private static DatabaseManager instance;
    public static DatabaseManager Instance { get { return instance; } }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        connectionString = "Server = metrovaniamania.c6qiuq6ftf6t.us-east-1.rds.amazonaws.com; Database = MetroidVaniaMania;User ID = Jack;Password = JackTheRipper76; SslMode=None;";

        TestDatabaseConnection();
    }

    private void TestDatabaseConnection()
    {
        try
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                Debug.Log("Database Connection Successful");

                

                connection.Close();
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Database Connection Error: " + e.Message);

            if (e.InnerException != null)
            {
                Debug.LogError("Inner Exception: " + e.InnerException.Message);
            }
        }
    }
}
