using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketOnTouch : MonoBehaviour {

  ChangableSightRange sight;
  public SpriteRenderer render;
  public Sprite bucketHead;
  public bool currentlyBucketed = false;

	// Use this for initialization
	void Start () {
    sight = GetComponent<ChangableSightRange>();
    render = GetComponentInChildren<SpriteRenderer>();
	}

  //Update is called once per frame
  void Update()
  {
    if (currentlyBucketed) {
      sight.setBlind();
      render.sprite = bucketHead;
    }
  }

  void OnTriggerEnter(Collider other) {
    if (other.tag == "Player" && bucketHead && other.GetComponent<GrabAndUseBucket>() && other.GetComponent<GrabAndUseBucket>().bucketReady) {
      Debug.Log("bucket!");

      currentlyBucketed = true;
      other.GetComponent<GrabAndUseBucket>().loseBucket();
    }
  }
}
