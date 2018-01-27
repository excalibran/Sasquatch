using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Costume : MonoBehaviour {

  public string designation;
  public Animator anim;
  public List<Sprite> sprites;
  public SpriteRenderer sp;
  public RuntimeAnimatorController nAnim;

  // Use this for initialization
  void Start () {
    sp = GetComponent<SpriteRenderer>();
    anim = GetComponent<Animator>();
    //nAnim = (RuntimeAnimatorController)Resources.Load("graphics/BIGFOOT/" + designation);
  }

  public Sprite getSprite(int index) {
    return sprites[index];
  }

  public void changeSprite(int index) {
    sp.sprite = sprites[index];
  }
}
