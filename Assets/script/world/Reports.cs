﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reports : MonoBehaviour {

  public List<Vector3> reportsForGuards;
  //public List<Vector3> reportsForCivilians;
  int currentDelay = 1000;
  int clearDelay = 1000;

	void Start () {

    reportsForGuards = new List<Vector3>();
	}

  void update() {
    if (currentDelay <= 0)
    {
      if (reportsForGuards.Count > 0) {
        reportsForGuards.RemoveAt(0);
      }
      currentDelay = clearDelay;
    }
    else {
      currentDelay--;
    }
  }
}
