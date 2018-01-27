using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangableSightRange : MonoBehaviour {

  Transform detecterCollider;
  public Vector3 defaultSize;
  public bool exception;
  
	// Use this for initialization
	void Start () {
    detecterCollider = GetComponentInChildren<SpotObject>().gameObject.GetComponent<Transform>();
    defaultSize = detecterCollider.localScale;
	}

  public void setSightActive() {
    //detecterCollider.bounds.Expand(defaultSize * 3);
    //detecterCollider.localScale = new Vector3(defaultSize *3, defaultSize * 3, defaultSize * 3);
    detecterCollider.localScale = defaultSize * 3;
  }

  public void setNeutral() {
    //detecterCollider.bounds.Expand(defaultSize);
    //detecterCollider.localScale = new Vector3(defaultSize, defaultSize, defaultSize);
    detecterCollider.localScale = defaultSize;
  }

  public void setReduced() {
    //detecterCollider.bounds.Expand(defaultSize /2 );
    //detecterCollider.localScale = new Vector3(defaultSize / 2, defaultSize / 2, defaultSize / 2);
    detecterCollider.localScale = defaultSize / 2;
  }

  public void setBlind() {
    //detecterCollider.bounds.Expand(defaultSize / 10);
    //detecterCollider.localScale = new Vector3(defaultSize / 10, defaultSize / 10, defaultSize / 10);
    detecterCollider.localScale = defaultSize / 10;
  }
}
