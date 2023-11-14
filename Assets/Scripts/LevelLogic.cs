using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLogic : MonoBehaviour
{
    public GameObject[] characterPrefabs; // Array of characters
    //Vector2 startPosition = new Vector2(-6.53f, -3.61f); // specifies the start position for the sprites - probably won't use these
    //Quaternion startRotation = Quaternion.identity; // specifies the start rotation for the sprite - probably not gonna mess with this

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
