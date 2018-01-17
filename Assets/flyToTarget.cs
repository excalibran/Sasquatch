using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyToTarget : MonoBehaviour {

  Vector3 targetPosition;
  public GameObject target;

  // Use this for initialization
  void Start() {

  }

  // Update is called once per frame
  void Update() {
    if (target) {
      transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 100);
    }
  }

  void OnTriggerEnter(Collider other) {
    if (other.tag != "Player")
    {
      Destroy(gameObject);
    }
    else {
      other.gameObject.GetComponent<Health>().takeDamage();
    }
  }
   
}
