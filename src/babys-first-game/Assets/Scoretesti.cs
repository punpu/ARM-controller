using UnityEngine;
using System.Collections;

public class Scoretesti : MonoBehaviour {

	// Use this for initialization
	void Start () {
        HighScores.Sethighscores(1, "kissa");
        HighScores.Sethighscores(32, "kissa3");
        HighScores.Sethighscores(321, "kissa7");
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
