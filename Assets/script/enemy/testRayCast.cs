using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testRayCast : MonoBehaviour {

  public GameObject player;
  //Transform spot;
  public int playerSeen = 0;

	// Use this for initialization
	void Start () {
    //spot = player.transform;
	}
	
	// Update is called once per frame
	void Update () {

    if (playerSeen > 0) {
      playerSeen--;
    }  
	}

  void OnTriggerStay(Collider other) {
    if (other.tag == "Player") {
      Debug.DrawLine(transform.position, other.transform.position);
      //Debug.Log("player nearby");
      player = other.gameObject;
      if (Physics.Linecast(transform.position, other.transform.position, ~(1 << 8)))
      {
        Debug.Log("player blocked");
      }
      else {
        playerSeen = 120;
      }
    }
  }
}
