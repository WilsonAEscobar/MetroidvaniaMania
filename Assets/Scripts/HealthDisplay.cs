using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HealthDisplay : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI scoreText;
    private PlayerHealth playerHealth;
    public float startTime = 0f; 
    private float currentTime;
    private GameObject playerObject;

    void Start()
    {
        currentTime = startTime;
    
    }


    void Update()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        playerHealth = playerObject.GetComponent<PlayerHealth>();
        currentTime += Time.deltaTime;

        if (playerHealth != null && healthText != null)
        {
            // Update the TextMeshPro text with the player's health
            healthText.text = "Health: " + playerHealth.health.ToString();
        }
        scoreText.text ="Time: " + (Mathf.Round(currentTime * 100) / 100).ToString();
    }

}
