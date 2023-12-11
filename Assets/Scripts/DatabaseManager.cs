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

    public void InsertPlayerScore(string username, int level, int score, float time)
    {
        try
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Get the playerID based on the username
                int playerID = GetPlayerID(username, connection);

                if (playerID != -1)
                {
                    // Insert or update the player score in the playerScores table
                    string query = @"
                    INSERT INTO playerScores (playerID, levelID, highScore, bestTime)
                    VALUES (@playerID, @levelID, @highScore, @bestTime)
                    ON DUPLICATE KEY UPDATE
                    highScore = GREATEST(@highScore, highScore), bestTime = LEAST(@bestTime, bestTime)";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@playerID", playerID);
                        cmd.Parameters.AddWithValue("@levelID", level);
                        cmd.Parameters.AddWithValue("@highScore", score);
                        cmd.Parameters.AddWithValue("@bestTime", time);
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    Debug.LogError("Error getting playerID for username: " + username);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error inserting/updating player score into the database: " + e.Message);
        }
    }

    private int GetPlayerID(string username, MySqlConnection connection)
    {
        // Get the playerID based on the username
        string query = "SELECT playerID FROM players WHERE username = @username";
        using (MySqlCommand cmd = new MySqlCommand(query, connection))
        {
            cmd.Parameters.AddWithValue("@username", username);
            object result = cmd.ExecuteScalar();
            return result != null ? Convert.ToInt32(result) : -1;
        }
    }

    public void DeletePlayerAndScores(string username)
    {
        try
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                int playerID = GetPlayerID(username, connection);

                if (playerID != -1)
                {
                    // Delete entry from playerScores table based on playerID
                    string deletePlayerScoresQuery = "DELETE FROM playerScores WHERE playerID = @playerID";
                    using (MySqlCommand deletePlayerScoresCmd = new MySqlCommand(deletePlayerScoresQuery, connection))
                    {
                        deletePlayerScoresCmd.Parameters.AddWithValue("@playerID", playerID);
                        deletePlayerScoresCmd.ExecuteNonQuery();
                    }
                    
                    // Delete entry from players table based on username
                    string deletePlayerQuery = "DELETE FROM players WHERE username = @username";
                    using (MySqlCommand deletePlayerCmd = new MySqlCommand(deletePlayerQuery, connection))
                    {
                        deletePlayerCmd.Parameters.AddWithValue("@username", username);
                        deletePlayerCmd.ExecuteNonQuery();
                    }

                }
                else
                {
                    Debug.LogError("Error getting playerID for username: " + username);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error deleting player and scores: " + e.Message);
        }
    }
}
