using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabAndUseBucket : MonoBehaviour {

  public SpriteRenderer visibleBucket;
  public bool bucketReady = false;

	// Use this for initialization
	void Start () {
    //visibleBucket = transform.GetComponentInChildren<Transform>().gameObject.GetComponentInChildren<SpriteRenderer>();
    visibleBucket.enabled = false;
	}

  public void loseBucket() {
    bucketReady = false;
    visibleBucket.enabled = false;
  }


  public void pickupBucket() {
    if (!bucketReady) {
      bucketReady = true;
      visibleBucket.enabled = true;
    }
  }
	
}
