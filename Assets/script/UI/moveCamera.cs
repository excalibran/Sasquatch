using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    
   // transform.position += Vector3.right * 10f * 
	}

  void FixedUpdate()
  {
    float moveHorizontal = Input.GetAxis("Horizontal");
    float moveVertical = Input.GetAxis("Vertical");


    Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
    transform.position += movement * 1f;
  }
}
