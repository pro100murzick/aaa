using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level : MonoBehaviour
{

    public static string NEXT_LEVEL_KEY = "nextLevelToPlay";
    public static int LEVEL_TO_START = 1;
    public static string LAST_LEVEL_KEY = "lastPlayedLevel";
    public static int LEVEL_TO_PLAY = 1;
    public static string GAME_COMPLETE_KEY = "gameComplete";
    public static int GAME_INCOMPLETE = 0;
    public static int GAME_COMPLETE = 1;
  

    [SerializeField] Button[] levelButtons;
    [SerializeField] int totalSceneNumber = 25;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void EnableLevelButtons()
    {
        if (levelButtons.Length == 0)
        {
            return;
        }
    }

    public void LoadNextScene()
    {
        if (PlayerPrefs.GetInt(GAME_COMPLETE_KEY, GAME_INCOMPLETE) == 1)
        {
            SceneManager.LoadScene("SelectLevel");
            return;
        }
        int nextSceneIndex = PlayerPrefs.GetInt(NEXT_LEVEL_KEY, LEVEL_TO_START);
        SceneManager.LoadScene(nextSceneIndex);
    }

    public void ReloadScene()
    {
        int sceneIndex = PlayerPrefs.GetInt(LAST_LEVEL_KEY, LEVEL_TO_PLAY);
        SceneManager.LoadScene(sceneIndex);     
    }

    public int GetTotalSceneNumber()
    {
        return totalSceneNumber;
    }

    public void LaodMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    } 
    public void LaodLevelCompleteScene()
    {
        SceneManager.LoadScene("LevelComplete");
    }
    public void LaodLevelFailScene()
    {
        SceneManager.LoadScene("LevelFail");
    }
    public void LaodLevelSelectorScene()
    {
        SceneManager.LoadScene("SelectLevel");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
