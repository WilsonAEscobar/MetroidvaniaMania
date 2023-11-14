using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelectionLogic : MonoBehaviour
{
    private int selectedCharacter;
    public Button[] characterButtons;

    // Start is called before the first frame update
    void Start()
    {
        // Set the initial selection
        SelectCharacter(selectedCharacter);
    }
    public void SelectCharacter(int buttonIndex)
    {
        // Deselect the previously selected button
        characterButtons[selectedCharacter].interactable = true;

        // Select the new button
        selectedCharacter = buttonIndex;
        characterButtons[selectedCharacter].interactable = false;

        Debug.Log("Selected Button Index: " + selectedCharacter);
    }
    public int GetSelectedCharacterIndex()
    {
        return selectedCharacter;
    }

    public void OnCharacterButtonClick(int buttonIndex)
    {
        SelectCharacter(buttonIndex);
    }
    
    public void StartGame()
    {
        PlayerPrefs.SetInt("SelectedCharacterIndex", selectedCharacter);

        int selectedLevelIndex = PlayerPrefs.GetInt("SelectedLevelIndex", 0);
        SceneManager.LoadScene("Level " + selectedLevelIndex);

    }
}
