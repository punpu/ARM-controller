using UnityEngine;
using System.Collections;

public class mainmenuscript : MonoBehaviour {

    public GUISkin menuSkin;

    //booleans which are used for navigation in the menus
    private bool settings;
    private bool difficulty;
    private bool number_of_poses;
    private bool setplayers;
    private bool start;
    bool how_to_play;

    //these values are used for setting up the game
    static public int poses;
    static public difficulties difficulty_level;
    static public bool twoplayer;
    static public bool fourplayer;

    //difficultylevels
    public enum difficulties
    {
        normal,
        hard,
        rousted
    };

    //todo poset ja difficulty gamesceneen
    void OnGUI()
    {
        GUI.skin = menuSkin;

        if (start) //"New game" submenu opened
        {

            if (how_to_play) //How to play submenu opened
            {
                GUI.Box(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 250, 400, 500), "HOW TO PLAY\n\nYou must perform a rain dance\nby matching all the poses\n presented in the top right corner in time.\nLeft Arm: Q, A, W, S\nRight Arm: I, K, O, L\nLeft Leg: D, C, F, V\nRight Leg: H, N, J, M");


                if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 + 120, 300, 40), "BACK"))
                {
                    how_to_play = false;
                }
            }

            else { 

            GUI.Box(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 200, 400, 400), "START GAME");

            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 60, 300, 40), "START"))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("gameScene");
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 15, 300, 40), "HOW TO PLAY"))
            {
                how_to_play = true;
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 + 30, 300, 40), "BACK"))
            {
                start = false;
                //UnityEngine.SceneManagement.SceneManager.LoadScene("mainmenu");
            }
            }
        }

        if (settings) // "Settings" menu opened
        {
            // Make a background box
            GUI.Box(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 200, 400, 400), "SETTINGS");

            if (number_of_poses)
            {
                if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 60, 300, 40), "5 POSES"))
                {
                    poses = 5;
                    number_of_poses = false;
                }

                if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 15, 300, 40), "10 POSES"))
                {
                    poses = 10;
                    number_of_poses = false;
                }

                if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 + 30, 300, 40), "15 POSES"))
                {
                    poses = 15;
                    number_of_poses = false;
                }
            }

            

            if (difficulty) //Difficulty menu opened
            {
                if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 60, 300, 40), "NORMAL"))
                {
                    difficulty_level = difficulties.normal;
                    difficulty = false;
                }

                if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 15, 300, 40), "HARD"))
                {
                    difficulty_level = difficulties.hard;
                    difficulty = false;
                }

                if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 + 30, 300, 40), "ROUSTED"))
                {
                    difficulty_level = difficulties.rousted;
                    difficulty = false;
                }
            }

            if (setplayers) // "Set players" menu opened
            {
                if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 60, 300, 40), "2 PLAYERS"))
                {
                    twoplayer = true;
                    fourplayer = false;
                    setplayers = false;
                }

                if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 15, 300, 40), "4 PLAYERS"))
                {
                    fourplayer = true;
                    twoplayer = false;
                    setplayers = false;
                }

            }

            if (!difficulty && !number_of_poses && !setplayers) // No "Settings" submenu opened
            {
                //set player mode
                if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 60, 300, 40), "PLAYERS"))
                {
                    setplayers = true;
                }

                if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 15, 300, 40), "DIFFICULTY"))
                {
                    difficulty = true;
                }

                if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 + 30, 300, 40), "NUMBER OF POSES"))
                {
                    number_of_poses = true;
                }

                //save settings and go back to main menu
                if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 + 75, 300, 40), "BACK TO MAIN MENU"))
                {
                    settings = false;
                }
            }
        }

        if (!settings && !start) // Main menu
        {

            GUI.Box(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 200, 400, 400), "A.R.M CONTROLLER");

            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 60, 300, 40), "NEW GAME"))
            {

                start = true;
                /*
                    //by default four player mode is enabled
                if (fourplayer)
                {
                    //scene transition into four player game scene
                    UnityEngine.SceneManagement.SceneManager.LoadScene("gameScene");
                }

                if (twoplayer)
                {
                    //scene transition into two player game scene
                    UnityEngine.SceneManagement.SceneManager.LoadScene("gameScene");
                }
                */
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 15, 300, 40), "SETTINGS"))
            {
                settings = true;
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 + 30, 300, 40), "HIGH SCORES"))
            {
                //Scene transition into high scores scene
                UnityEngine.SceneManagement.SceneManager.LoadScene("HighScoreScene");
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 + 75, 300, 40), "QUIT GAME"))
            {
                Application.Quit();
            }
        }
    }

    // Use this for initialization
    void Start () {

        settings = false;
        twoplayer = false;
        fourplayer = true;
        difficulty = false;
        number_of_poses = false;
        setplayers = false;
        start = false;
        how_to_play = false;
        poses = 10;
        difficulty_level = difficulties.normal;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
