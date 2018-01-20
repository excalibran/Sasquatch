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
    swapCostume(0);
  }

  public void swapCostume(int index) {
    currentCostume = costumes[index];
  }
	
	void FixedUpdate () {

    float moveHorizontal = Input.GetAxis("Horizontal");
    float moveVertical = Input.GetAxis("Vertical");

    Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

    bool movingLeft = moveHorizontal < 0;
    bool movingRight = moveHorizontal > 0;
    bool movingUp = moveVertical > 0;
    bool movingDown = moveVertical < 0;

    if (movingDown && !movingLeft && !movingRight)
    {
      currentCostume.changeSprite(0);
    }

    if (movingRight && !movingDown && !movingUp)
    {
      currentCostume.changeSprite(1);
    }

    if (movingUp && !movingLeft && !movingRight)
    {
      currentCostume.changeSprite(2);
    }

    if (movingLeft && !movingDown && !movingUp)
    {
      currentCostume.changeSprite(3);
    }

    transform.position += movement * playerSpeedMod;
  }
}
