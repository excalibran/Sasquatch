using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabAndUseBucket : MonoBehaviour {

  SpriteRenderer visibleBucket;
  public bool bucketReady;

	// Use this for initialization
	void Start () {
    visibleBucket = transform.Find("BucketInHand").GetComponent<SpriteRenderer>();

	}

  void loseBucket() {
    bucketReady = false;
    visibleBucket.enabled = false;
  }


  void pickupBucket() {
    if (!bucketReady) {
      bucketReady = true;
      visibleBucket.enabled = true;
    }
  }
	
}
