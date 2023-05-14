using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public static bool MultiMode = true;
    private AudioSource finishSound;

    private bool levelCompleted = false;
    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !levelCompleted)
        {
            finishSound.Play();
            levelCompleted = true;
            CompleteLevel();
            if (MultiMode)
            {
                var playerLife = collision.gameObject.GetComponent<PlayerMovement>();
                if (playerLife.isPlayer2)
                {
                    Leaderboard.IncrementPlayer2Wins();
                }
                else
                {
                    Leaderboard.IncrementPlayer1Wins();
                }
                CompleteLevel();
            }
            
        }
    }

    private void CompleteLevel()
    {
        int Index = (SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(Index);
        PlayerPrefs.SetInt("CurrentLevel", Index);
        PlayerPrefs.Save();
        var playerLives = FindObjectsOfType<PlayerLife>();
        foreach (var life in playerLives)
        {
            life.lastCheckPointPos = Vector2.zero;
        }
    }
}
