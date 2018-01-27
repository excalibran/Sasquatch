using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallGuard : MonoBehaviour {

  SpotObject detect;
  public SpriteRenderer emote;
  public Reports reports;
  BucketOnTouch bucketable;
  int delay = 60;

  bool reporting = false;

	// Use this for initialization
	void Start () {
    detect = GetComponentInChildren<SpotObject>();
    //emote = GameObject.Find("Emote").GetComponent<SpriteRenderer>();
    emote = detect.GetComponentInChildren<SpriteRenderer>();
    bucketable = GetComponent<BucketOnTouch>();
    emote.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

    if (detect.targetSeen > 0)
    {
      if (delay <= 0)
      {
        if (reports.reportsForGuards.Count >= 0 && reports.reportsForGuards.Count < 5)
        {
          reporting = true;
        }
        delay = 60;
      }
      else {
        delay--;
      }
    }
    else {
      emote.enabled = false;
    }

    if (bucketable && bucketable.currentlyBucketed) {
      reporting = false;
    }

    if (reporting) {
      emote.enabled = true;
      reports.reportsForGuards.Add(detect.target.transform.position);
    }

	}
}
