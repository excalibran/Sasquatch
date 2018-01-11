using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceMarker : MonoBehaviour {

  testRayCast detect;
  public Reports reports;
  int delay = 120;

	// Use this for initialization
	void Start () {
    detect = GetComponentInChildren<testRayCast>();
	}
	
	// Update is called once per frame
	void Update () {
    if (detect.playerSeen > 0) {
      if (delay <= 0) {
        reports.list.Add(detect.player.transform.position);
        Debug.Log("report placed");
        delay = 120;
      }
      else{
        delay--;
      }
    }
	}
}
