using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// Handles the saving and loading of data, and keeps temporary data between scenes.
/// </summary>
public class DataManager : MonoBehaviour
{
    private static string username;
    
    /// <summary>
    /// Gets the username of the current session
    /// </summary>
    /// <returns></returns>
    public static string GetCurrentUsername()
    {
        return username;
    }

    /// <summary>
    /// Sets the username for the current session
    /// </summary>
    public static void SetUsername(string newUsername)
    {
        username = newUsername;
    }

    /// <summary>
    /// Saves in a highscore.json file the username and score of the best scorer
    /// </summary>
    public static void  SaveBestScore(ScoreModel score)
    {
        string json = JsonUtility.ToJson(score);

        File.WriteAllText(Application.persistentDataPath + "/highscore.json", json);
    }

    /// <summary>
    /// Returns the highscore data from a highscore.json file
    /// </summary>
    public static ScoreModel GetBestScore()
    {
        string path = Application.persistentDataPath + "/highscore.json";
        var data = new ScoreModel();
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            data = JsonUtility.FromJson<ScoreModel>(json);
        }
        return data;
    }


}
