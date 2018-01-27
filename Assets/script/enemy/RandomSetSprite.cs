using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSetSprite : MonoBehaviour {

  public List<Sprite> spriteSet;
  SpriteRenderer render;

	// Use this for initialization
	void Start () {

    render = GetComponent<SpriteRenderer>();

    if (spriteSet == null)
    {
      Debug.Log("Missing random sprites");
    }
    else {
      render.sprite = spriteSet[Random.Range(0, spriteSet.Count-1)];
    }
	}
	
	
}
