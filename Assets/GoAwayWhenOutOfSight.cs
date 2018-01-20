using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoAwayWhenOutOfSight : MonoBehaviour {

  MeshRenderer mesh;
  Transform player;
  Transform parent;
  int rate = 0;

	// Use this for initialization
	void Start () {
    mesh = GetComponent<MeshRenderer>();
    player = GameState.stPlayerRef.transform;
    parent = GetComponentInParent<Transform>();
	}
	
	
	void Update () {
    Debug.DrawLine(parent.transform.position, player.position, Color.blue);
    if (rate <= 0)
    {
      if (Physics.Linecast(parent.transform.position, player.position, ~(1 << 8)))
      {
        mesh.enabled = false;
      }
      else {
        mesh.enabled = true;
      }

      rate = 0;

    }
    else {
      rate--;
    }
	}
}
