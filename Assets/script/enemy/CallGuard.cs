using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallGuard : MonoBehaviour {

  SpotObject detect;
  public SpriteRenderer emote;
  public Reports reports;
  int delay = 60;

	// Use this for initialization
	void Start () {
    detect = GetComponentInChildren<SpotObject>();
    emote = GameObject.Find("Emote").GetComponent<SpriteRenderer>();
    emote.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

    if (detect.targetSeen > 0)
    {
      if (delay <= 0)
      {
        emote.enabled = true;

        if (reports.reportsForGuards.Count > 0)
        {
          reports.reportsForGuards.Add(detect.target.transform.position);
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
	}
}
