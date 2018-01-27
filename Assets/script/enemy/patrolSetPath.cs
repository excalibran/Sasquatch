using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class patrolSetPath : MonoBehaviour
{

  //public List< patrolPath;
  public List<Transform> waypoints;
  public List<Vector3> points;
  //Vector3 currentTarget;

  private int destPoint = 0;
  private NavMeshAgent agent;
  private float normSpeed = 3.5f;
  public float clearReportDelay = 60f;
  public float addToPatrolDelay = 1f;
  public int maxPatrol = 5;


  public Reports reports;

  SpotObject detecter;


  void Start()
  {
    foreach (Transform t in waypoints) {
      points.Add(t.transform.position);
    }

    agent = GetComponent<NavMeshAgent>();
    agent.autoBraking = false;
    detecter = GetComponentInChildren<SpotObject>();

    if (!reports) {
      Reports [] rep = FindObjectsOfType<Reports>();
      reports = rep[0];
    }

    GotoNextPoint();
  }


  void GotoNextPoint()
  {

    if (points.Count == 0)
      return;
    
    agent.destination = points[destPoint];

    if (reports.reportsForGuards.Count > 0)
    {
      if (points.Count < maxPatrol && reports.reportsForGuards[reports.reportsForGuards.Count-1] != points[points.Count-1])
      {
        points.Add(reports.reportsForGuards[(int)(Random.Range(0, reports.reportsForGuards.Count - 1))]);
      }
      else {
        points.RemoveAt(points.Count-1);
      }
    }
    destPoint = (destPoint + 1) % points.Count;

  }


  void Update()
  {
    //currentTarget = agent.destination;

    if (agent.enabled) {
      if (detecter.targetSeen > 0 && detecter.target)
      {
        agent.ResetPath();
        agent.destination = detecter.target.transform.position;
      }
      else if (reports.reportsForGuards.Count > 0 && points.Count < maxPatrol) {
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

      ResetPatrolPath();
    }
  }

  IEnumerator ResetPatrolPath() {
    yield return new WaitForSeconds(clearReportDelay);

    points.Clear();

    foreach (Transform t in waypoints)
    {
      points.Add(t.transform.position);
    }
  }
}

