﻿using UnityEngine;
using System.Collections;

public class RightPumpArmControl : MonoBehaviour {

    float forceAmount;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        //   GetComponent<Rigidbody2D>().AddForce(-transform.forward * forceAmount, ForceMode2D.Force);
        //GetComponent<Rigidbody2D>().AddForce(new Vector2(forceAmount, 0));
        forceAmount = Input.GetAxis("RightPumpArmTurn");
        //Debug.Log("päästään");
        //  GetComponent<Rigidbody2D>().AddForce(new Vector2(0, forceAmount));

        GetComponent<Rigidbody2D>().AddTorque(forceAmount);
       // Debug.Log(GetComponent<Rigidbody2D>().GetComponent<ConstantForce>());


        // forceAmount = Input.GetAxis("Horizontal");

        //Debug.Log("päästään");
        //  GetComponent<Rigidbody2D>().AddForce(new Vector2(0, forceAmount));

        GetComponent<Rigidbody2D>().AddTorque(forceAmount);
        //Debug.Log(GetComponent<Rigidbody2D>().GetComponent<ConstantForce>());
	
	}
}
