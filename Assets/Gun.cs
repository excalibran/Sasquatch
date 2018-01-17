using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

  SpotObject detecter;
  public GameObject bullet;
  Vector3 trajectory;
  int shootRate = 10;

	// Use this for initialization
	void Start () {
    detecter = GetComponent<SpotObject>();
    
	}
	
	// Update is called once per frame
	void Update () {
    if (detecter.targetSeen > 0) {
      if (shootRate <= 0) {
        GameObject shot = Instantiate(bullet, transform);
        //shot.GetComponent<flyToTarget>().target = detecter.target;

        shootRate = 120;
      }
      else {
        shootRate--;
      }
    }
	}
}
