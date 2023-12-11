using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class EndLevelFlag : MonoBehaviour
{
    public GameObject scoreDisplayCanvas;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI HighScoreText;
    public int currentScore;

    private int level;
    private int currentHighScore;

    // Start is called before the first frame update
    void Start()
    {
        level = PlayerPrefs.GetInt("SelectedLevelIndex", 0);
        currentHighScore = SaveManager.GetHighScoreForCurrentLevel(level);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Time.timeScale = 0f; // Freeze the level

        // Access the LevelLogic script to get the player's score
        LevelLogic levelLogic = FindObjectOfType<LevelLogic>();
        

        if (other.CompareTag("Player"))
        {
            scoreDisplayCanvas.gameObject.SetActive(true);
            levelLogic.calculateScore();
            currentScore = levelLogic.score;

            // Update the high score in PlayerPrefs if the current score is higher
            if (currentScore > currentHighScore)
            {
                SaveManager.SetHighScoreForCurrentLevel(level, currentScore);
                DatabaseManager.Instance.InsertPlayerScore(PlayerPrefs.GetString("SaveSlotUsername" + SaveID.saveID), level, currentScore, PlayerPrefs.GetFloat("CurrentTime" + SaveID.saveID));
            }

            // Display scores
            ScorePopUp popupScript = FindObjectOfType<ScorePopUp>();
            if (popupScript != null)
            {
                popupScript.DisplayScore(currentScore, scoreText);
                popupScript.DisplayHighScore(currentHighScore, HighScoreText);
            }
        }
    }
}
