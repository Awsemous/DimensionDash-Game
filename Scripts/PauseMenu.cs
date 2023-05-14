using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    private bool GameIsPaused = false;
    [SerializeField] private GameObject pauseMenuUI;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
       void Resume()
        {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            GameIsPaused = false;
        }
        void Pause()
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }
    
        public void Save()
    {
        PlayerPrefs.SetInt("CurrentLevel", (SceneManager.GetActiveScene().buildIndex));
        PlayerPrefs.Save();
    }
    public void LoadMenu()
    {
        Debug.Log ("Loading");
        SceneManager.LoadScene("Scenes/Menu");
    }
    public void QuitGame()
    {
        Debug.Log("qUITITING");
        Application.Quit();
    }

}