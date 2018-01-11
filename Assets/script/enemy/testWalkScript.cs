using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class testWalkScript : MonoBehaviour {

  public Transform target;
  NavMeshAgent agent;

	// Use this for initialization
	void Start () {
    agent = GetComponent<NavMeshAgent>();
    
	}
	
	// Update is called once per frame
	void Update () {
    agent.SetDestination(target.position);
	}

  void OnDisable() {
    agent.SetDestination(transform.position);
  }
}
