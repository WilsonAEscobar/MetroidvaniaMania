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
        //connectionString = "Server = myServer; Database = myDatabase; User ID = myUser; Password = mypass; SslMode=None";

        TestDatabaseConnection();
    }

    public void Initialize()
    {
        connectionString = "Server = metrovaniamania.c6qiuq6ftf6t.us-east-1.rds.amazonaws.com; Database = MetroidVaniaMania;User ID = Jack;Password = JackTheRipper76; SslMode=None;";
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

    public bool CheckUsernameAvailability(string username)
    {
        try
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString)) //connection to database will close when done with this block
            {
                connection.Open();

                // Check if the username already exists in the players table
                string query = "SELECT COUNT(*) FROM players WHERE username = @username";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@username", username); // sets @username in the above query to whatever we have in our username parameter - in this case it'd be the players username
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count == 0; // If count is 0, the username is available
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error checking username availability: " + e.Message);
            return false;
        }
    }

    public void InsertPlayer(string username)
    {
        try
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString)) //connection to database will close when done with this block
            {
                connection.Open();

                // Insert a new player into the players table
                string query = "INSERT INTO players (username) VALUES (@username)";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@username", username); // assigns the username parameter to the above query
                    cmd.ExecuteNonQuery();
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error inserting player into the database: " + e.Message);
        }
    }
}
