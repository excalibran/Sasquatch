using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Costume : MonoBehaviour {

  public string name;
  public List<Sprite> sprites;
  public SpriteRenderer sp;

	// Use this for initialization
	void Start () {
    sp = GetComponent<SpriteRenderer>();
  }

  public Sprite getSprite(int index) {
    return sprites[index];
  }

  public void changeSprite(int index) {
    sp.sprite = sprites[index];
  }
}
