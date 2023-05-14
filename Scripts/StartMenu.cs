using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public int gameStartScene;
    public void StartGame()
    {
        SceneManager.LoadScene(gameStartScene);

    }
    public void Load()
    {
        if (PlayerPrefs.HasKey("CurrentLevel"))
        {
            int currentLevel = PlayerPrefs.GetInt("CurrentLevel");
            SceneManager.LoadScene(currentLevel);
            Time.timeScale = 1f;
        }
    }
}
     
