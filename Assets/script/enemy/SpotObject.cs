using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotObject : MonoBehaviour {

  public GameObject target;
  public string targetTag;
  //Transform spot;
  public int targetSeen = 0;
  public int sensitivity = 120;
  

	
	void Start () {
    if (targetTag == "")
      targetTag = "Player";

    if (!target) {
      target = GameObject.FindGameObjectWithTag("Player");
    }
	}
	
	
	void Update () {

    if (targetSeen > 0)
    {
      targetSeen--;
      //Debug.Log("decrement");
    }
    
	}

  void OnTriggerStay(Collider other) {
    if (other.tag == "Player") {
      Debug.DrawLine(transform.position, other.transform.position);
      //Debug.Log("Spot");

      target = other.gameObject;
      if (Physics.Linecast(transform.position, other.transform.position, ~(1 << 8)))
      {
        //Debug.Log("player blocked");
      }
      else {
        targetSeen = sensitivity;
      }
    }
  }
}
