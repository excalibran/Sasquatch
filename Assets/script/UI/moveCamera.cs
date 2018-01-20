using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCamera : MonoBehaviour {

  public bool lockOnPlayer = true;
  public GameObject player;

	// Use this for initialization
	void Start () {
    player = FindObjectOfType<PlayerWalkKeyboard>().gameObject;
	}
	

  void FixedUpdate()
  {
    if (!lockOnPlayer)
    {
      float moveHorizontal = Input.GetAxis("Horizontal");
      float moveVertical = Input.GetAxis("Vertical");
      
      Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
      transform.position += movement * 1f;
    }
    else {
      transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z-10);
      transform.LookAt(player.transform);
    }
  }
}
