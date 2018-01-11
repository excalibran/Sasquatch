using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class patrolSetPath : MonoBehaviour
{

  //public List< patrolPath;
  public List<Transform> waypoints;
  public List<Vector3> points;
  private int destPoint = 0;
  private NavMeshAgent agent;

  public Reports reports;

  testRayCast detecter;


  void Start()
  {
    foreach (Transform t in waypoints) {
      points.Add(t.transform.position);
    }

    agent = GetComponent<NavMeshAgent>();
    agent.autoBraking = false;
    detecter = GetComponentInChildren<testRayCast>();
    
    GotoNextPoint();
  }


  void GotoNextPoint()
  {

    if (points.Count == 0)
      return;
    
    agent.destination = points[destPoint];
    if (reports.list.Count > 0)
    {
      //points.Insert((destPoint + 1) % points.Count, reports.list[0].transform);
      points.Add(reports.list[0]);
      reports.list.Clear();
    }
    destPoint = (destPoint + 1) % points.Count;


  }


  void Update()
  {
    if (detecter.playerSeen > 0 && detecter.player)
    {
      Debug.Log("seen");
      agent.ResetPath();
      agent.destination = detecter.player.transform.position;
    }
    else if (reports.list.Count > 0) {
      agent.destination = reports.list[0];
      GotoNextPoint();
    }
    else {
      if (!agent.pathPending && agent.remainingDistance < 0.5f)
        GotoNextPoint();
    }
  }
}

