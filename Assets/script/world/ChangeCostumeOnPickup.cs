using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCostumeOnPickup : MonoBehaviour {

  public string designation;

	// Use this for initialization
	void Start () {
		
	}

  
  void OnTriggerEnter(Collider other) {
    if (other.tag == "Player") {
      other.GetComponent<PlayerWalkKeyboard>().swapCostume(designation);
      GameState.ChangeSightLines("Reduced");
    }
  }
}
