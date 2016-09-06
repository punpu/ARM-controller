using UnityEngine;
using System.Collections;

public class hingeControl : MonoBehaviour {

    public float forceAmount;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
       
       GetComponent<Rigidbody2D>().AddForce(-transform.forward * forceAmount, ForceMode2D.Force);
       
     
    }
}
