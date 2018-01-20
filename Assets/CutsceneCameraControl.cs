using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneCameraControl : MonoBehaviour {

  public List<Transform> participants;
  Camera mainCam;

  int index;

	// Use this for initialization
	void Start () {
    if (mainCam == null){
      mainCam = FindObjectOfType<Camera>();
    }
  }

  void cameraMoveAbove(int index) {
    
    mainCam.transform.position = new Vector3(participants[index].position.x, 25, participants[index].transform.position.z - 10);
    mainCam.transform.LookAt(participants[index]);
    
  }

  void cameraStart() {
    mainCam.gameObject.GetComponent<moveCamera>().enabled = false;
    cameraMoveAbove(0);
    index = (index + 1) % participants.Count;
  }

  void cameraNext() {
    
    cameraMoveAbove(index);
    index = (index + 1) % participants.Count;

  }

  void cameraEnd() {

    mainCam.transform.position = new Vector3(GameState.stPlayerRef.transform.position.x, 25, GameState.stPlayerRef.transform.position.z - 10);
    mainCam.transform.LookAt(GameState.stPlayerRef.transform);
    mainCam.gameObject.GetComponent<moveCamera>().enabled = true;

  }
	
	//// Update is called once per frame
	//void Update () {
		
	//}
}
