using UnityEngine;
using System.IO;
using TMPro;
public class MenuManger : MonoBehaviour
{
    public static MenuManger instance {get; private set;}
    public TMP_Text HeightestScoreText;
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
    class SaveData
    {
        public string playerName;
        // public int playerScore;
    }

    public void savePlayerData(string playerName)
    {
        SaveData data = new SaveData();
        data.playerName = playerName;
        // data.playerScore = playerScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void loadPlayerData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            HeightestScoreText.text = $"Hei: {data.playerName}";
        }
    }
}
