using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabAndUseBucket : MonoBehaviour {

  SpriteRenderer visibleBucket;
  bool bucketReady;

	// Use this for initialization
	void Start () {
    visibleBucket = transform.Find("BucketInHand").GetComponent<SpriteRenderer>();
	}

  void pickupBucket() {
    if (!bucketReady) {
      bucketReady = true;
    }
  }
	
}
