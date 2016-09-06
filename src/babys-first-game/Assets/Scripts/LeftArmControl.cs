using UnityEngine;
using System.Collections;

public class LeftArmControl : MonoBehaviour
{

    float forceAmount;
    // Use this for initialization
    void Start()
    {

    }
   
    // Update is called once per frame
    void Update()
    {
        //   GetComponent<Rigidbody2D>().AddForce(-transform.forward * forceAmount, ForceMode2D.Force);
        //GetComponent<Rigidbody2D>().AddForce(new Vector2(forceAmount, 0));

        forceAmount = Input.GetAxis("LeftArmTurn");       
          //  Debug.Log("kulma" + GetComponent<Rigidbody2D>().transform.rotation);
            //Debug.Log("päästään");
            //  GetComponent<Rigidbody2D>().AddForce(new Vector2(0, forceAmount));

            GetComponent<Rigidbody2D>().AddTorque(forceAmount);
         //   Debug.Log(GetComponent<Rigidbody2D>().GetComponent<ConstantForce>());
        
    
    }
}
