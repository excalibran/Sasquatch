using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkKeyboard : MonoBehaviour {

  public float playerSpeedMod = .3f;
  public Costume currentCostume;
  public List<Costume> costumes;
 
  void Start () {
    costumes = new List<Costume>();
    costumes.AddRange( GetComponentsInChildren<Costume>());
    swapCostume("Naked");
  }

  public void swapCostume(string designation) {

    foreach (Costume c in costumes) {
      if (designation.Equals(c.designation)) {
        currentCostume = c;
        currentCostume.anim.runtimeAnimatorController = currentCostume.nAnim;
      }
    }
    //currentCostume = costumes[index];
  }
	
	void FixedUpdate () {

    float moveHorizontal = Input.GetAxis("Horizontal");
    float moveVertical = Input.GetAxis("Vertical");

    Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

    bool movingLeft = moveHorizontal < 0;
    bool movingRight = moveHorizontal > 0;
    bool movingUp = moveVertical > 0;
    bool movingDown = moveVertical < 0;

    currentCostume.anim.SetBool("Down", false);
    currentCostume.anim.SetBool("Up", false);
    currentCostume.anim.SetBool("Side", false);
    currentCostume.anim.SetBool("Idle", false);
    currentCostume.sp.flipX = false;

    //if (movingDown && !movingLeft && !movingRight)
    if (movingDown)
    {
      //currentCostume.changeSprite(0);
      currentCostume.anim.SetBool("Down", true);
    }
    //else if (movingRight && !movingDown && !movingUp)
    else if (movingRight)
    {
      //currentCostume.changeSprite(1);
      if (movingDown) {
        currentCostume.anim.SetBool("Down", true);
      }
      else if (movingUp) {
        currentCostume.anim.SetBool("Up", true);
      }
      else {
        currentCostume.anim.SetBool("Side", true);
        currentCostume.sp.flipX = true;
      }
      
    }

    //else if (movingUp && !movingLeft && !movingRight)
    else if (movingUp)
    {
      //currentCostume.changeSprite(2);
      currentCostume.anim.SetBool("Up", true);
    }

    //else if (movingLeft && !movingDown && !movingUp)
    else if (movingLeft)
    {
      //currentCostume.changeSprite(3);
      
      if (movingDown)
      {
        currentCostume.anim.SetBool("Down", true);
      }
      else if (movingUp)
      {
        currentCostume.anim.SetBool("Up", true);
      }
      else {
        currentCostume.anim.SetBool("Side", true);
      }

    }
    else {
      currentCostume.anim.SetBool("Idle", true);
    }

    transform.position += movement * playerSpeedMod;
  }
}
