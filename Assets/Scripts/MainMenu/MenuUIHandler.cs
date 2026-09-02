using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif
public class MenuUIHandler : MonoBehaviour
{
    public TMP_Text heightestPSText;

    public GameObject menuCanvas;

    public void Start()
    {
        loadPlayerData();
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        menuCanvas.SetActive(false);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
    public void assignPlayerName(string playerName)
    {   
        MenuManger.instance.playerName = playerName;
        Debug.Log("User Name : " + MenuManger.instance.playerName);
    }
    public void loadPlayerData()
    {
        heightestPSText.text = MenuManger.instance.LoadHighScores();
    }
}

