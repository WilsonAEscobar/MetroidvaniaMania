using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLogic : MonoBehaviour
{
    public GameObject[] characterPrefabs; // Array of characters

    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public int numberOfEnemies = 5;
    public float spawnDelay = 2f;

    public GameObject player;

    void Start()
    {

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

   

    // Update is called once per frame
    void Update()
    {
        
    }
}
