using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif
public class MenuUIHandler : MonoBehaviour
{
    public TMP_Text heightestPSText;

    // public static MenuUIHandler instance {get; private set;}
    public GameObject menuCanvas;
    public void Awake()
    {
        // if (instance != null)
        // {
        //     Destroy(gameObject);
        //     return;
        // }
        // instance = this;
        // DontDestroyOnLoad(gameObject);
        updateHeightestPS();
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
        MenuManger.instance.LoadHighScores();
    }

    public void activateMenu()
    {
        menuCanvas.SetActive(true);
    }

    public void updateHeightestPS()
    {
        heightestPSText.text = MenuManger.instance.highScoreResult();
    }
}

