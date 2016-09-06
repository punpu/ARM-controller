using UnityEngine;
using System.Collections;

public class Fader : MonoBehaviour {

    float alphalevel = 1f;
    float timer;
    public float delay;
    public float alphamultiplier;
	// Use this for initialization
	void Start () {

       // GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
        
        timer += Time.deltaTime;

       if(timer - delay >= 0)
       {
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, alphalevel-(timer - delay)*alphamultiplier);
       }
	}
}

