using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HealthDisplay : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI scoreText;
    public PlayerHealth playerHealth;
    public float startTime = 0f; 
    private float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (playerHealth != null && healthText != null)
        {
            // Update the TextMeshPro text with the player's health
            healthText.text = "Health: " + playerHealth.health.ToString();
        }
        scoreText.text = "Score: " + currentTime.ToString();
    }
}
