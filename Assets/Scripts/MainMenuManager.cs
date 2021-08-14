using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenuManager : MonoBehaviour
{
    public InputField userNameInput;
    public Text BestScoreText;


    private void Start()
    {
        UpdateBestScoreText();
    }

    /// <summary>
    /// Sends the inputed username to the DataManager and loads the main level
    /// </summary>
    public void StartGame()
    {
        DataManager.SetUsername(userNameInput.text);
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// Closes the game
    /// </summary>
    public void Exit()
    {
        #if UNITY_EDITOR
                EditorApplication.ExitPlaymode();
        #else
                Application.Quit(); // original code to quit Unity player
        #endif
    }

    /// <summary>
    /// Updates the best score text 
    /// </summary>
    private void UpdateBestScoreText()
    {
        var highScoreData = DataManager.GetBestScore();
        BestScoreText.text = $"Best Score : {highScoreData.Username} : {highScoreData.Score}";
    }
}
