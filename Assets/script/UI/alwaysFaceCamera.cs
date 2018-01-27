using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alwaysFaceCamera : MonoBehaviour {

  Camera main;

  void Start() {
    main = GameObject.FindObjectOfType<Camera>();
  }

	void Update () {

    transform.forward = main.transform.forward;
      //Camera.main.transform.forward;
  }
}
