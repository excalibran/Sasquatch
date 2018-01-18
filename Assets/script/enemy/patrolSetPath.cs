using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class patrolSetPath : MonoBehaviour
{

  //public List< patrolPath;
  public List<Transform> waypoints;
  public List<Vector3> points;
  public Vector3 currentTarget;
  private int destPoint = 0;
  private NavMeshAgent agent;
  private float normSpeed = 3.5f;


  public Reports reports;

  SpotObject detecter;


  void Start()
  {
    foreach (Transform t in waypoints) {
      points.Add(t.transform.position);
    }

    agent = GetComponent<NavMeshAgent>();
    agent.autoBraking = false;
    //agent.updateRotation = false;
    detecter = GetComponentInChildren<SpotObject>();
    
    GotoNextPoint();
  }


  void GotoNextPoint()
  {

    if (points.Count == 0)
      return;
    
    agent.destination = points[destPoint];
    if (reports.reportsForGuards.Count > 0)
    {
      //points.Insert((destPoint + 1) % points.Count, reports.list[0].transform);
      //points.Add(reports.reportsForGuards[Random.RandomRange(0, reports.reportsForGuards.Count)]);
      if (points.Count <= waypoints.Count) {
        points.Add(reports.reportsForGuards[0]);
      }
      reports.reportsForGuards.Clear();
    }
    destPoint = (destPoint + 1) % points.Count;


  }


  void Update()
  {
    currentTarget = agent.destination;

    if (agent.enabled) {
      if (detecter.targetSeen > 0 && detecter.target)
      {
        //Debug.Log("seen");
        agent.ResetPath();
        agent.destination = detecter.target.transform.position;
      }
      else if (reports.reportsForGuards.Count > 0) {
        agent.destination = reports.reportsForGuards[(int)(Random.Range(0, reports.reportsForGuards.Count - 1))];
        agent.speed = 7;
        GotoNextPoint();
      }
      else {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
          agent.speed = normSpeed;
          GotoNextPoint();
        }
      }
    }
  }
}

