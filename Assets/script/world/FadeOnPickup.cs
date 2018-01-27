using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOnPickup : MonoBehaviour {

  MeshRenderer mesh;
  SpriteRenderer sprite;
  BoxCollider coll;
  public bool pickupOnce = true;
  public bool disappearAfter = true;


	// Use this for initialization
	void Start () {
    mesh = GetComponent<MeshRenderer>();
    coll = GetComponent<BoxCollider>();
    sprite = GetComponent<SpriteRenderer>();

	}

  void OnTriggerEnter(Collider other) {
    if (other.tag == "Player") {
      if(disappearAfter)
        if(mesh)
          mesh.enabled = false;

      if (sprite)
        sprite.enabled = false;

      if(pickupOnce)
        coll.enabled = false;      
    }
  }
}
