using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

//This scene is called when the game ends
public class endingscript : MonoBehaviour {

    private bool end;
    public string editable_string = "";
    public GUISkin menuSkin;

    void OnGUI()
    {
        GUI.skin = menuSkin;
        if (!end)
        {
            //the game was finished succesfully
            if (GameManager.HappyEnding)
            {
                GUI.Box(new Rect(Screen.width / 2 - 250, Screen.height / 2 - 150, 500, 300), "The famine has ended\nand your village is safe...\nFor now.");

                if (GUI.Button(new Rect(Screen.width/2 - 55, Screen.height/2+55, 110, 40), "CONTINUE"))
                {
                    end = true;
                }
            }

            //the game ended not succesfully
            else
            {
                GUI.Box(new Rect(Screen.width / 2 - 250, Screen.height / 2 - 150, 500, 300), "Due to the drought\nyour village lies in ruins\nand the survivors have\nscattered across the country.");
                
                if (GUI.Button(new Rect(Screen.width / 2-55, Screen.height / 2+55, 110, 40), "CONTINUE"))
                {
                    end = true;
                }
            }
        }

        if (end)
        { 
            GUI.Box(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 125, 400, 250), "Enter your name:");
            editable_string = GUI.TextField(new Rect(Screen.width / 2 - 100, Screen.height / 2-20, 200, 40), editable_string, 15);
           
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 20, 200, 40), "SEE HIGH SCORES"))
            {
                if (editable_string != "")
                {
                    //Debug.Log("taasko");
                    HighScores.Sethighscores(GameManager.FinalScore, editable_string);
                }
                UnityEngine.SceneManagement.SceneManager.LoadScene("HighScoreScene");
            }
            
        }
    }

	// Use this for initialization
	void Start () {
        end = false;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
