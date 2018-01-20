using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FungusLiason : MonoBehaviour {

  Camera mainCam;

	// Use this for initialization
	void Start () {
		
	}
	
	//// Update is called once per frame
	//void Update () {
		
	//}

  void togglePause() {
    GameState.TogglePause_s();
  }

  void FocusCameraOnPlayer() {
    if (mainCam == null) {
      mainCam = FindObjectOfType<Camera>();
    }

    mainCam.gameObject.GetComponent<moveCamera>().enabled = false;
    mainCam.transform.position = new Vector3(GameState.stPlayerRef.transform.position.x, transform.position.y, GameState.stPlayerRef.transform.position.z - 10);
    mainCam.transform.LookAt(GameState.stPlayerRef.transform);
    mainCam.gameObject.GetComponent<moveCamera>().enabled = true;
  }


}
