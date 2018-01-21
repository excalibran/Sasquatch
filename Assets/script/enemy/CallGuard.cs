using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallGuard : MonoBehaviour {

  SpotObject detect;
  public Reports reports;
  int delay = 60;

	// Use this for initialization
	void Start () {
    detect = GetComponentInChildren<SpotObject>();
	}
	
	// Update is called once per frame
	void Update () {

    if (detect.targetSeen > 0) {
      if (delay <= 0) {
        //reports.reportsForGuards.Add(detect.target.transform.position);
        if (reports.reportsForGuards.Count < 1) {
          reports.reportsForGuards.Add(detect.target.transform.position);
        }
        //Debug.Log("report placed");
        delay = 60;
      }
      else{
        delay--;
      }
    }
	}
}
