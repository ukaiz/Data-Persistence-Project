using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif
public class MenuUIHandler : MonoBehaviour
{
    public void Awake()
    {
        loadPlayerData();
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void savePlayerData(string playerName)
    {
        MenuManger.instance.savePlayerData(playerName);
    }

    public void loadPlayerData()
    {
        MenuManger.instance.loadPlayerData();
    }
}

