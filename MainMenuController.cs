using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public Button Continue, Newgame, Options, About, Exit;

    private void Start()
    {
        Continue.onClick.AddListener(ContinueHandler);
        Newgame.onClick.AddListener(NewGameHandler);
        Options.onClick.AddListener(OptionsHandler);
        About.onClick.AddListener(AboutHandler);
        Exit.onClick.AddListener(ExitHandler);
    }

    private void ExitHandler()
    {
        Application.Quit();
    }

    private void AboutHandler()
    {
        throw new NotImplementedException();
    }

    private void OptionsHandler()
    {
        throw new NotImplementedException();
    }

    private void NewGameHandler()
    {
        SaveGame(1);
        SceneManager.LoadScene(1);
    }

    public void SaveGame(int value)
    {
        string saveFilePath = Path.Combine(Application.persistentDataPath, "save.json");

        SaveData saveData = new SaveData();

        saveData.Level = value;

        string json = JsonUtility.ToJson(saveData);
        File.WriteAllText(saveFilePath, json);
        Debug.Log("Save file path: " + saveFilePath);
        Debug.Log("Game saved.");
    }

    private void ContinueHandler()
    {
        string saveFilePath = Path.Combine(Application.persistentDataPath, "save.json");

        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);

            SceneManager.LoadScene(saveData.Level);
        }
        else
        {
            Debug.Log("No saved game found.");
        }
    }
}

public class SaveData
{
    public int Level;
}
