using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChangeSpriteByTravel : MonoBehaviour {

  SpriteRenderer render;
  public Sprite[] sprites;
  NavMeshAgent agent;
  Transform parentTransform;
  //int cycle = 30;

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

    int angle = (int)(parentTransform.transform.localRotation.eulerAngles.y / 90);

    if (angle == 0 || angle == 4)
    {
      //up
      render.sprite = sprites[2];
    }

    if (angle == 3 || angle == 5)
    {
      render.sprite = sprites[1];
    }


    if (angle == 2 || angle == 6)
    {
      //Debug.Log("Face left");
      render.sprite = sprites[0];
    }

    if (angle == 1 || angle == 7)
    {
      render.sprite = sprites[3];
    }



  }

}
