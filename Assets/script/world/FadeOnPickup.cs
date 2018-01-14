using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOnPickup : MonoBehaviour {

  MeshRenderer mesh;
  BoxCollider coll;
  public bool pickupOnce = true;
  public bool disappearAfter = true;


	// Use this for initialization
	void Start () {
    mesh = GetComponent<MeshRenderer>();
    coll = GetComponent<BoxCollider>();

	}

  //// Update is called once per frame
  //void Update () {

  //}

  void OnTriggerEnter(Collider other) {
    if (other.tag == "Player") {
      if(disappearAfter)
        mesh.enabled = false;

      if(pickupOnce)
        coll.enabled = false;      
    }
  }
}
