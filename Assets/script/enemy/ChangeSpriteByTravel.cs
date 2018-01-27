using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChangeSpriteByTravel : MonoBehaviour {

  SpriteRenderer render;
  public Sprite[] sprites;
  NavMeshAgent agent;
  Transform parentTransform;
  Animator anim;
  public int angle;
  
	// Use this for initialization
	void Start () {
    render = GetComponent<SpriteRenderer>();
    agent = GetComponentInParent<NavMeshAgent>();
    parentTransform = GetComponentInParent<Transform>();
    anim = GetComponent<Animator>();
  }
	
	// Update is called once per frame
	void Update () {
    Debug.DrawLine(parentTransform.position,agent.destination,Color.red);

    anim.SetBool("Up", false);
    anim.SetBool("Down", false);
    anim.SetBool("Side", false);
    anim.SetBool("Idle", false);
    render.flipX = false;

    angle = (int)(parentTransform.transform.localRotation.eulerAngles.y / 90);

    if (angle == 0 || angle == 4)
    {
      //up
      //render.sprite = sprites[2];
      anim.SetBool("Up", true);
    }

    if (angle == 3 || angle == 8)
    {
      //render.sprite = sprites[1];
      anim.SetBool("Side", true);
      render.flipX = true;
    }


    if (angle == 2 || angle == 6)
    {
      //Debug.Log("Face left");
      //render.sprite = sprites[0];
      anim.SetBool("Down", true);
    }

    if (angle == 1 || angle == 5)
    {
      //render.sprite = sprites[3];
      anim.SetBool("Side", true);
      
    }

    //if (anim.velocity.magnitude < 1) {
    //  anim.SetBool("Up", false);
    //  anim.SetBool("Down", false);
    //  anim.SetBool("Side", false);
    //  anim.SetBool("Idle", true);
    //}



  }

}
