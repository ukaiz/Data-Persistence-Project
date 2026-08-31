using UnityEngine;
using System.Collections.Generic;
using System.IO;
using TMPro;
public class MenuManger : MonoBehaviour
{
    public static MenuManger instance {get; private set;}
    public string playerName;
    public int playerScore;
    
    public void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }


    [System.Serializable]
    public class ScoreEntry
    {
        public string playerName;
        public int playerScore;
    }
    [System.Serializable]
    class SaveData
    {
        public List<ScoreEntry> highScores = new List<ScoreEntry>();
    }
    public List<ScoreEntry> HighScores {get; private set;} = new List<ScoreEntry>();

    public void SubmitScore(string playerName, int playerScore)
    {
        HighScores.Add(new ScoreEntry { playerName = playerName, playerScore = playerScore });

        HighScores.Sort((a,b) => b.playerScore.CompareTo(a.playerScore));

        if (HighScores.Count > 3)
        {
            HighScores.RemoveRange(3, HighScores.Count - 3);
        }
        savePlayerData();
    }
    public void savePlayerData()
    {
        SaveData data = new SaveData { highScores = HighScores };
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScores()
    {
        string SavePath = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(SavePath))
        {
            string json = File.ReadAllText(SavePath);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            HighScores = data.highScores;
        }
    }

    public string highScoreResult()
    {
        string result = "";

        for (int i = 0; i < MenuManger.instance.HighScores.Count; i++)
        {
            var entry = MenuManger.instance.HighScores[i];
            result += $"{i + 1}. {entry.playerName} : {entry.playerScore}\n";
        }
        Debug.Log("High Score Result : " + result);
        return result;
    }
}
