using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;

public class Leaderboard : MonoBehaviour
{
    public TextMeshProUGUI Player1Winstext;
    public TextMeshProUGUI Player2Winstext;

    private static string leaderboardFileName = "leaderboard.txt";

    public static void SaveLeaderboard(int player1Wins, int player2Wins)
    {
        using (StreamWriter sw = new StreamWriter(leaderboardFileName))
        {
            sw.WriteLine(player1Wins + " " + player2Wins); 
        }
    }
   private void Awake()
    {
        LoadLeaderboard(out int player1Wins, out int player2Wins);
        Player1Winstext.text = player1Wins.ToString();
        Player2Winstext.text = player2Wins.ToString();
    }
    public static bool LoadLeaderboard(out int player1Wins, out int player2Wins)
    {
        if (File.Exists(leaderboardFileName))
        {
            using (StreamReader sr = new StreamReader(leaderboardFileName))
            {
                string input = sr.ReadToEnd().Trim();
                Debug.Log(input);
                string[] strings = input.Split(" ", System.StringSplitOptions.RemoveEmptyEntries);
                foreach (var S in strings)
                {
                    Debug.Log(S);
                }
               player1Wins = int.Parse(strings[0]);
               player2Wins = int.Parse(strings[1]);
               return true;
}
        }

        player1Wins = 0;
        player2Wins = 0;
        return false;
    }

    public static void IncrementPlayer1Wins()
    {
        int player1Wins, player2Wins;
        LoadLeaderboard(out player1Wins, out player2Wins);
        player1Wins++;
        SaveLeaderboard(player1Wins, player2Wins);
    }

    public static void IncrementPlayer2Wins()
    {
        int player1Wins, player2Wins;
        LoadLeaderboard(out player1Wins, out player2Wins);
        player2Wins++;
        SaveLeaderboard(player1Wins, player2Wins);
    }
    public void ResetAllWins()
    {
        
        SaveLeaderboard(0, 0);
        Player1Winstext.text = Player2Winstext.text = "0";
    }
    public static void ResetPlayer1Wins()
    {
        int player1Wins, player2Wins;
        LoadLeaderboard(out player1Wins, out player2Wins);
        player1Wins = 0;
        SaveLeaderboard(player1Wins, player2Wins);
    }

    public static void ResetPlayer2Wins()
    {
        int player1Wins, player2Wins;
        LoadLeaderboard(out player1Wins, out player2Wins);
        player2Wins = 0;
        SaveLeaderboard(player1Wins, player2Wins);

    } 
}



