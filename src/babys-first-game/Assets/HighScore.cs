using UnityEngine;
using System.Collections;
using System.Linq;

public class HighScore : ScriptableObject {

    public string PlayerName;
    public int PlayerScore;

    public HighScore(string newPlayerName, int newPlayerScore)
    {
        PlayerName = newPlayerName;
        PlayerScore = newPlayerScore;
    }

    public void init(string newPlayerName, int newPlayerScore)
    {
        PlayerName = newPlayerName;
        PlayerScore = newPlayerScore;
    }

}
