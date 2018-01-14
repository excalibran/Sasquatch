using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChangeSpriteByTravel : MonoBehaviour {

  SpriteRenderer render;
  public Sprite[] sprites;
  NavMeshAgent agent;
  Transform parentTransform;
  int cycle = 30;

  int lastDirection;

	// Use this for initialization
	void Start () {
    render = GetComponent<SpriteRenderer>();
    agent = GetComponentInParent<NavMeshAgent>();
    parentTransform = GetComponentInParent<Transform>();
  }
	
	// Update is called once per frame
	void Update () {
    Debug.DrawLine(parentTransform.position,agent.destination,Color.red);

    bool Xgreater = agent.destination.x > parentTransform.position.x;
    bool Xdominant = agent.destination.x - parentTransform.position.x > agent.destination.z - parentTransform.position.z;
    bool Zgreater = agent.destination.z > parentTransform.position.z;

    float angle = parentTransform.transform.localRotation.eulerAngles.y;

    if (cycle == 0)
    {
      Debug.Log((agent.destination.x - parentTransform.transform.position.x) + " " + (agent.destination.z - parentTransform.transform.position.z));
      cycle = 30;
    }
    else { cycle--; }

    

    if (angle > 315 && angle <= 45)
    {
      //Debug.Log("Face left");
      render.sprite = sprites[2];
    }

    if (angle > 45 && angle <= 135)
    {
      render.sprite = sprites[1];
    }


    if (angle > 135 && angle <= 225)
    {
      //Debug.Log("Face left");
      render.sprite = sprites[0];
    }
    if (angle > 225 && angle <= 315)
    {
      render.sprite = sprites[3];
    }



  }

}
