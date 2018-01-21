using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketOnTouch : MonoBehaviour {

  ChangableSightRange sight;
  SpriteRenderer render;
  public Sprite bucketHead;

	// Use this for initialization
	void Start () {
    sight = GetComponent<ChangableSightRange>();
    render = GetComponentInChildren<SpriteRenderer>().gameObject.GetComponentInChildren<SpriteRenderer>();
	}

  // Update is called once per frame
  //void Update () {

  //}

  void OnTriggerEnter(Collider other) {
    if (other.tag == "Player" && bucketHead && other.GetComponent<GrabAndUseBucket>() && other.GetComponent<GrabAndUseBucket>().bucketReady) {
      Debug.Log("bucket!");
      sight.setBlind();
      render.sprite = bucketHead;
      other.GetComponent<GrabAndUseBucket>().bucketReady = false;
    }
  }
}
