using UnityEngine;
using System.Collections;

public class RightArmController : MonoBehaviour {
    float forceAmount;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        forceAmount = Input.GetAxis("RightArmTurn");
       // Debug.Log("kulma" + GetComponent<Rigidbody2D>().transform.rotation);
        //Debug.Log("päästään");
        //  GetComponent<Rigidbody2D>().AddForce(new Vector2(0, forceAmount));

        GetComponent<Rigidbody2D>().AddTorque(forceAmount);
	}
}
