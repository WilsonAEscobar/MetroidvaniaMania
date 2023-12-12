using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelLogic : MonoBehaviour
{
    public GameObject[] characterPrefabs; // Array of characters

    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public TextMeshProUGUI[] tutorialBoxes;
    public int numberOfEnemies = 5;
    public float spawnDelay = 2f;
    public int score = 0;
    public int enemiesK = 0;
    private float currentTime;
    public int startTime = 0;


    void Start()
    {
        if(PlayerPrefs.GetInt("Tutorial") == 1)
        {
            Debug.Log("Tutorial is ON");
            for (int i = 0; i<tutorialBoxes.Length; i++)
            {
                tutorialBoxes[i].gameObject.SetActive(true);
            }
        }
        else
        {
            for(int i = 0; i < tutorialBoxes.Length; i++)
            {
                tutorialBoxes[i].gameObject.SetActive(false);
            }
        }
        currentTime = startTime;

        SpawnEnemies();

        int selectedCharacterIndex = PlayerPrefs.GetInt("SelectedCharacterIndex", 0);

        GameObject selectedCharacter = characterPrefabs[selectedCharacterIndex];
        selectedCharacter.SetActive(true);

        for (int i = 0; i < characterPrefabs.Length; i++)
        {
            if (i != selectedCharacterIndex)
            {
                characterPrefabs[i].SetActive(false); // sets inactive the characters in characterPrefabs that are not the selectedCharacter
            }
        }
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            Transform spawnPoint = spawnPoints[i];
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }


    public void enemiesKilled()
    {
        enemiesK++;
    }
    public void calculateScore()
    {
        float timeMultiplier = 1000; 
        float timeBasedScore = Mathf.Max(0, (timeMultiplier / currentTime));

        score = (enemiesK * 15)+ Mathf.RoundToInt(timeBasedScore);
        PlayerPrefs.SetFloat("CurrentTime" + SaveID.saveID, Mathf.Round(currentTime*100)/100);
 
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
    }
}
