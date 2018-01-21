using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneParticipant : MonoBehaviour {

  public Vector3 cameraAngle;
  public Transform cameraPosition;

	// Use this for initialization
	void Start () {

    if (cameraPosition) {
      cameraAngle = cameraPosition.position;
    }

    if (cameraAngle == null || cameraAngle == Vector3.zero) {
      cameraAngle = new Vector3(transform.position.x, 25, transform.position.z - 10);
    }

	}
	
	//// Update is called once per frame
	//void Update () {
		
	//}
}
