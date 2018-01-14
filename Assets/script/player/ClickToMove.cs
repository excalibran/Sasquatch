using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour {

  public Vector3 target;
  public bool drawDebug = false;
  public NavMeshAgent agent;

  // Use this for initialization
  void Start()
  {
    agent = GetComponent<NavMeshAgent>();
    target = transform.position;
  }

  // Update is called once per frame
  void Update()
  {

    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    RaycastHit hit;

    //if (Input.GetKeyDown("P")) {
    //  GameState.togglePause();
    //}
    
    if (Input.GetMouseButton(0)) {
      if (Physics.Raycast(ray, out hit, 100)) {
        target = hit.point;
      }
    }
    setMoveTarget(target);
    if (drawDebug)
      Debug.DrawRay(ray.origin, ray.direction*10, Color.yellow);
  }

  bool setMoveTarget(Vector3 target) {
    if (agent.enabled) {
      agent.SetDestination(target);
      return true;
    }
    return false;
  }

  void OnDisable()
  {
    setMoveTarget(transform.position);
  }
}
