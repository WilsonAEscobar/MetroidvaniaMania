using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static int GetHighScore(int saveID, int levelID)
    {
        string key = $"HighScore_SaveID_{saveID}_LevelID_{levelID}";
        return PlayerPrefs.GetInt(key, 0);
    }

    public static void SetHighScore(int saveID, int levelID, int score)
    {
        string key = $"HighScore_SaveID_{saveID}_LevelID_{levelID}";
        PlayerPrefs.SetInt(key, score);
        PlayerPrefs.Save();  // Save PlayerPrefs immediately
    }

    public void SetHighScoreForCurrentLevel(int levelID, int score)
    {
        int saveID = SaveID.saveID;

        // Set the high score for the current level and save slot
        SaveManager.SetHighScore(saveID, levelID, score);
    }

    public int GetHighScoreForCurrentLevel(int levelID)
    {
        int saveID = SaveID.saveID;

        // Get the high score for the current level and save slot
        return SaveManager.GetHighScore(saveID, levelID);
    }

    // Example method to demonstrate how to use high scores
    public void UpdateHighScoreForCurrentLevel(int levelID, int newScore)
    {
        int currentHighScore = GetHighScoreForCurrentLevel(levelID);

        if (newScore > currentHighScore)
        {
            // Update the high score if the new score is higher
            SetHighScoreForCurrentLevel(levelID, newScore);
        }
    }
}
