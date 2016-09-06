using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class HighScores : MonoBehaviour {

    public GUISkin menuSkin;
    private int scoresHeight;
    static int oldScore;
    static string currPlayerName;
    static string currPlayerScore;
    static bool return_to_menu;

    static private string toprint;

    static List<HighScore> highscores = new List<HighScore>();
    
    void OnGUI()
    {
        GUI.skin = menuSkin;
        if (return_to_menu)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("mainmenu");
        }

        if (!return_to_menu) { 
            GUI.Box(new Rect(Screen.width/2-250, Screen.height/2-300, 500, 600), toprint);

            if (GUI.Button(new Rect(Screen.width/2-100, Screen.height/2+150, 200, 40), "TO MAIN MENU"))
            {
                return_to_menu = true;
            }
        }
    }

   static void GetScoresFromPref()
    {
        for (int i = 1; i < 11; ++i)
        {
            currPlayerScore = "HighScore" + i;
            currPlayerName = "HighScorePlayer" + i;

            if (PlayerPrefs.HasKey(currPlayerName))
            {
                highscores.Add(new HighScore(PlayerPrefs.GetString(currPlayerName), PlayerPrefs.GetInt(currPlayerScore)));
            }
        }

        highscores = highscores.OrderByDescending(o => o.PlayerScore).ToList();
    }

   static void SaveScoresToPref()
    {
       
        for (int i = 1; i < 11; ++i)
        {
            currPlayerScore = "HighScore" + i;
            currPlayerName = "HighScorePlayer" + i;

            if (i <= highscores.Count && highscores.Count > 0)
            {
                PlayerPrefs.SetInt(currPlayerScore, highscores.ElementAt<HighScore>(i - 1).PlayerScore);
                PlayerPrefs.SetString(currPlayerName, highscores.ElementAt<HighScore>(i - 1).PlayerName);
                
                //Debug.Log("pisteet " + PlayerPrefs.GetInt("HighScore" + i));
                //Debug.Log("pelaaja " + PlayerPrefs.GetString("HighScorePlayer" + i));
            }
        }
    }

    static public void Sethighscores(int NewScore, string NewPlayerName)
    {

        if (highscores.Count <= 0)
        {
            GetScoresFromPref();
        }

        if (highscores.Count <= 0)
        {
            highscores.Add(new HighScore(NewPlayerName, NewScore));
        }

        else
        {
            bool found = false;

            for (int i = 0; i < highscores.Count; ++i)
            {
                if (highscores[i].PlayerScore < NewScore)
                {
                    highscores.Insert(i, new HighScore(NewPlayerName, NewScore));
                   
                    Debug.Log("loopissa " + highscores.ElementAt(0).PlayerName);
                    
                    if (highscores.Count > 10)
                    {
                        highscores.RemoveAt(9);
                        found = true;
                    }
                    break;
                }
            }
            if (!found && highscores.Count < 10)
            {
                highscores.Add(new HighScore(NewPlayerName, NewScore));
                Debug.Log("loopissa2 " + highscores.ElementAt(0).PlayerName);
            }
        }
        SaveScoresToPref();
        //highscores.Clear();
    }

    public static List<HighScore> getHighScores()
    {
        if (highscores.Count <= 0)
        {
            GetScoresFromPref();
        }
        highscores = highscores.OrderBy(o => o.PlayerScore).ToList();

        return highscores;
    }


    //public void SetHighscores(int Newscore, string PlayerName)
    //{
    //    for (int i = 1; i < 11; ++i)
    //    {
    //        if (PlayerPrefs.HasKey("highScore" + i))
    //        {
    //            highscores.Add();
    //        }

    //    }

    //}



    //public void SetHighscores_vanha(int Newscore, string PlayerName)
    //{
    //    for (int i = 1; i < 11; ++i)
    //    {
    //        if (PlayerPrefs.HasKey("HighScore" + i))
    //        {
    //            if (PlayerPrefs.GetInt("HighScore" + i) < Newscore)
    //            {
    //                PlayerPrefs.SetInt("HighScore" + i, Newscore);
    //                PlayerPrefs.SetString("HighscorePlayer" + i, PlayerName);
    //            }
    //        }
    //    }
    //    Debug.Log("High Scores are ");
    //    for (int i = 1; i < 11; ++i)
    //    {
    //        Debug.Log(PlayerPrefs.GetInt("HighScore" + i));
    //        Debug.Log(PlayerPrefs.GetString("HighScorePlayer" + i));
    //    }

    //}   

   
    // Use this for initialization
	void Start () {
        //PlayerPrefs.DeleteAll();

        return_to_menu = false;
        toprint = "HIGH SCORES\n\n";
        
        if(highscores.Count <= 0)
        {
            GetScoresFromPref();
        }
        highscores = highscores.OrderByDescending(o => o.PlayerScore).ToList();

        for (int i = 0; i < highscores.Count; ++i)
        {
            //Debug.Log(highscores.ElementAt(i).PlayerName);

            toprint += highscores.ElementAt(i).PlayerName + " : " + highscores.ElementAt(i).PlayerScore.ToString() + '\n';
        }

        //GetScoresFromPref();
        //SaveScoresToPref();
        //PlayerPrefs.SetInt("Player1", 10);
	}


  
}
