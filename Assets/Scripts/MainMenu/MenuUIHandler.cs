using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif
public class MenuUIHandler : MonoBehaviour
{
    public static MenuUIHandler instance {get; private set;}
    public GameObject menuCanvas;
    public void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
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
    public void newPlayerData(string playerName)
    {   
        MenuManger.instance.playerName = playerName;
        Debug.Log("User Name : " + MenuManger.instance.playerName);
    }
    public void savePlayerData()
    {   
        MenuManger.instance.savePlayerData();
    }

    public void loadPlayerData()
    {
        MenuManger.instance.loadPlayerData();
    }

    public void activateMenu()
    {
        menuCanvas.SetActive(true);
    }
}

