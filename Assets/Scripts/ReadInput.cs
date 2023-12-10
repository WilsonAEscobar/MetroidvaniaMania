using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using MySql.Data.MySqlClient;

public class ReadInput : MonoBehaviour
{
    static string input;
    public TMP_InputField usernameField;
    public TextMeshProUGUI usernameFixed;
    // Start is called before the first frame update
    void Start()
    {
        DatabaseManager.Instance.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.HasKey("SaveSlotUsername" + SaveID.saveID))
        {
            usernameField.gameObject.SetActive(false);
            usernameFixed.gameObject.SetActive(true);
            usernameFixed.text = "Username: "+ PlayerPrefs.GetString("SaveSlotUsername"+SaveID.saveID);
            
        }
        else
        {
            usernameField.gameObject.SetActive(true);
            usernameFixed.text = "";
            usernameFixed.gameObject.SetActive(false);
            input = string.Empty;
        }
        
    }

    public void goHome()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ValidateInput()
    {
        input = usernameField.text;
        if (IsUsernameAvailable(input))
        {
            Debug.Log("Username is available. Inserting into the database.");
            InsertPlayerIntoDatabase(input);
            PlayerPrefs.SetString("SaveSlotUsername"+SaveID.saveID, input);

        }
        else
        {
            Debug.Log("Username is already taken. Please choose another one.");
        }
    }

    private bool IsUsernameAvailable(string username)
    {
        // Check if the username exists in the database
        return DatabaseManager.Instance.CheckUsernameAvailability(username);
    }

    private void InsertPlayerIntoDatabase(string username)
    {
        // Insert a new player into the database
        DatabaseManager.Instance.InsertPlayer(username);
    }
}
