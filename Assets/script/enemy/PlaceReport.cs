using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceReport : MonoBehaviour {

  SpotObject detect;
  public Reports reports;
  int delay = 120;

	// Use this for initialization
	void Start () {
    detect = GetComponentInChildren<SpotObject>();
	}
	
	// Update is called once per frame
	void Update () {

    if (detect.targetSeen > 0) {
      if (delay <= 0) {
        reports.list.Add(detect.target.transform.position);
        //Debug.Log("report placed");
        delay = 120;
      }
      else{
        delay--;
      }
    }
	}
}
