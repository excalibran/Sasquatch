using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public static class GameState {

  static bool pause = false;
  static public GameObject stPlayerRef = GameObject.FindObjectOfType<PlayerWalkKeyboard>().gameObject;
  //static Object[] allObjects = GameObject.FindObjectsOfType(typeof(GameObject));
  static public int victory;

  public static void checkInventory() {
    if (victory >= 3) {
      //SceneManager.LoadScene("VictoryRoom");
    }
  }

  public static bool isPaused() {
    return pause;
  }

  public static void ChangeSightLines(string how) {
    List<ChangableSightRange> all = new List<ChangableSightRange>();
    all.AddRange(GameObject.FindObjectsOfType<ChangableSightRange>());

    if (how.Equals("Active")) {
      foreach (ChangableSightRange c in all)
      {
        c.setSightActive();
      }
    }
    else if (how.Equals("Neutral"))
    {
      foreach (ChangableSightRange c in all)
      {
        c.setNeutral();
      }
    }
    else if (how.Equals("Reduced"))
    {
      foreach (ChangableSightRange c in all)
      {
        if (!c.exception)
        {
          c.setReduced();
        }
        else {
          c.setSightActive();
        }
      }
    }
    else if (how.Equals("Blind"))
    {
      foreach (ChangableSightRange c in all)
      {
        c.setBlind();
      }
    }
    else {
      Debug.Log("Bad changeSight call");
    }
  }
  /// <summary>list of rigid bodies stopped in time</summary>
  private static Rigidbody[] bodies_s = null;
  private static List<MonoBehaviour> temporarilyDisabled_s = null;

  /// <summary>keep track of an object's physics info</summary>
  private struct Freeze
  {
    public Vector3 v;
    public Freeze(Rigidbody rb)
    {
      v = rb.velocity;
      if (rb.gameObject.GetComponent<NavMeshAgent>()) {
        rb.gameObject.GetComponent<NavMeshAgent>().enabled = false;
      }
      if (!rb.GetComponent<NavMeshAgent>())
        rb.isKinematic = true;
    }
    public void Unfreeze(Rigidbody rb)
    {
      if(rb.gameObject.GetComponent<NavMeshAgent>())
        rb.gameObject.GetComponent<NavMeshAgent>().enabled = true;

      rb.velocity = v;
      if (!rb.GetComponent<NavMeshAgent>())
        rb.isKinematic = false;
    }
  }

  /// <summary>list of velocities, saved before the objects are halted.</summary>
  private static Freeze[] snapshot_s = null;

  /// <returns><c>true</c> if the physics is frozen; otherwise, <c>false</c>.</returns>
  public static bool IsStopped() { return snapshot_s != null; }

  public static void TogglePause() { TogglePause_s(); }
  public static void PauseEverything() { PauseEverything_s(); }
  public static void UnpauseEverything() { UnpauseEverything_s(); }

  public static void PauseEverything_s()
  {
    if (IsStopped()) return;
    bodies_s = GameObject.FindObjectsOfType<Rigidbody>();
    snapshot_s = new Freeze[bodies_s.Length];
    for (int i = 0; i < bodies_s.Length; ++i)
    {
      snapshot_s[i] = new Freeze(bodies_s[i]);
    }
    // disable all active components on CharacterControllers
    NavMeshAgent[] charControllers_s = GameObject.FindObjectsOfType<NavMeshAgent>();
    temporarilyDisabled_s = new List<MonoBehaviour>();
    for (int i = 0; i < charControllers_s.Length; ++i)
    {
      if (charControllers_s[i].enabled)
      {
        MonoBehaviour[] list = charControllers_s[i].GetComponents<MonoBehaviour>();
        for (int c = 0; c < list.Length; ++c)
        {
          if (list[c].enabled)
          {
            list[c].enabled = false;
            temporarilyDisabled_s.Add(list[c]);
          }
        }
      }
    }
    if (stPlayerRef){
      stPlayerRef.GetComponent<PlayerWalkKeyboard>().enabled = false;
    }
  }

  public static void UnpauseEverything_s()
  {
    if (!IsStopped()) return;
    for (int i = 0; i < bodies_s.Length; ++i)
    {
      if (bodies_s[i] != null)
      {
        snapshot_s[i].Unfreeze(bodies_s[i]);
      }
    }
    // re-enable components on CharacterControllers
    for (int i = 0; i < temporarilyDisabled_s.Count; ++i)
    {
      temporarilyDisabled_s[i].enabled = true;
    }
    snapshot_s = null;
    bodies_s = null;
    temporarilyDisabled_s = null;
    if (stPlayerRef) {
      stPlayerRef.GetComponent<PlayerWalkKeyboard>().enabled = true;
    }
  }

  /// <summary>Toggles the rigibdody physics and character controllers.</summary>
  public static void TogglePause_s()
  {
    
    if (IsStopped())
    {
      //Debug.Log("unpause");
      UnpauseEverything_s();
    }
    else {
      //Debug.Log("pause");
      PauseEverything_s();
    }
  }
}
