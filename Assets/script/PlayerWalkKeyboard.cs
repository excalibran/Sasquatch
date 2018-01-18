using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkKeyboard : MonoBehaviour {

  CharacterController cc;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    float moveHorizontal = Input.GetAxis("Horizontal");
    float moveVertical = Input.GetAxis("Vertical");

    Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
    transform.position += movement * .3f;
  }
}
