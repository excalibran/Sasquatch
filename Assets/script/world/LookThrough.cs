using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LookThrough : MonoBehaviour {

  MeshRenderer mesh;
  public Transform player;
  public bool drawDebug = false;
	
	void Start () {
    mesh = GetComponent<MeshRenderer>();
  
  }
	
	void Update () {
  
    Ray rayMouse = Camera.main.ScreenPointToRay(Input.mousePosition);
    RaycastHit hitMouse;

    Ray rayPlayer = Camera.main.ScreenPointToRay(Camera.main.WorldToScreenPoint(player.position));
    RaycastHit hitPlayer;

    bool mouseOver = Physics.Raycast(rayMouse, out hitMouse, 100, (1 << 9));
    bool playerUnder = Physics.Raycast(rayPlayer, out hitPlayer, 100, (1 << 9));

    if (mouseOver || playerUnder)
    {
      mesh.enabled = false;
    }
    else {
      mesh.enabled = true;
    }

    if (drawDebug){
      Debug.DrawRay(rayMouse.origin, rayMouse.direction * 10, Color.red);
      Debug.DrawRay(rayPlayer.origin, rayPlayer.direction * 10, Color.blue);
    }

  }
}
