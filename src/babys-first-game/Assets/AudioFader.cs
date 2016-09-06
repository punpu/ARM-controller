using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class AudioFader : MonoBehaviour {

    float timer;
    public float delay;
   
     
	// Use this for initialization
    void Start()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.PlayDelayed(18);
        audio.Play(44100);
        
        

    }
	// Update is called once per frame
	void Update () {

      //  timer += Time.deltaTime;

      //  if (timer - delay >= 0)
     //   {
           // AudioSource audio = GetComponent<AudioSource>();
           // audio.Play();
           // audio.Play(44100);
   //     }
	}
}
