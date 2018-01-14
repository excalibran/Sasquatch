// http://pastebin.com/UPzuCUM4
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

public class FungusTrigger : MonoBehaviour
{

  [System.Serializable]
  public class Broadcast
  {
    public string messageToSend = "";
    public void Trigger() { Fungus.Flowchart.BroadcastFungusMessage(messageToSend); }
  }

  [Tooltip("broadcast a message to Fungus, which can start Fungus scripts")]
  public Broadcast[] broadcast;

  public static Fungus.Variable FindVariable(Fungus.Flowchart flowchart, string variableName)
  {
    List<Fungus.Variable> vars = flowchart.Variables;
    for (int i = 0; i < vars.Count; ++i)
    {
      if (vars[i].Key == variableName) { return vars[i]; }
    }
    return null;
  }

  public static Fungus.Flowchart FindFlowchartWithVariable(string variableName, out Fungus.Variable foundVariable)
  {
    Fungus.Flowchart flowchart = null;
    Fungus.Flowchart[] flows = GameObject.FindObjectsOfType<Fungus.Flowchart>();
    foundVariable = null;
    for (var f = 0; f < flows.Length && foundVariable == null; ++f)
    {
      flowchart = flows[f]; // check to see if the variable in question is in this flowchart
      foundVariable = FindVariable(flowchart, variableName);
    }
    if (!flowchart) { Debug.LogError("Could not find flowchart with variable \"" + variableName + "\""); }
    return flowchart;
  }

  [System.Serializable]
  public class SetStringVariable
  {
    public string variableName, variableValue;
    [Tooltip("will automagically find a Fungus flowchart if none is given")]
    public Fungus.Flowchart flowchart;
    public void Trigger()
    {
      Fungus.Variable v = null;
      if (!flowchart) { flowchart = FindFlowchartWithVariable(variableName, out v); } else { v = FindVariable(flowchart, variableName); }
      if (v.GetType() == typeof(Fungus.StringVariable)) { flowchart.SetStringVariable(variableName, variableValue); }
      if (v.GetType() == typeof(Fungus.FloatVariable)) { flowchart.SetFloatVariable(variableName, System.Single.Parse(variableValue)); }
      if (v.GetType() == typeof(Fungus.IntegerVariable)) { flowchart.SetIntegerVariable(variableName, System.Int32.Parse(variableValue)); }
      if (v.GetType() == typeof(Fungus.BooleanVariable)) { flowchart.SetBooleanVariable(variableName, (variableValue != "" && variableValue != "0" && variableValue.ToLower() != "false")); }
    }
  }
  public SetStringVariable[] setVariable;

  [System.Serializable]
  public class AddToVariable
  {
    public string variableName, variableValue;
    [Tooltip("will automagically find a Fungus flowchart if none is given")]
    public Fungus.Flowchart flowchart = null;
    public void Trigger()
    {
      Fungus.Variable v = null;
      if (!flowchart) { flowchart = FindFlowchartWithVariable(variableName, out v); } else { v = FindVariable(flowchart, variableName); }
      if (v.GetType() == typeof(Fungus.StringVariable)) { flowchart.SetStringVariable(variableName, flowchart.GetStringVariable(variableName) + variableValue); }
      if (v.GetType() == typeof(Fungus.FloatVariable)) { flowchart.SetFloatVariable(variableName, flowchart.GetFloatVariable(variableName) + System.Single.Parse(variableValue)); }
      if (v.GetType() == typeof(Fungus.IntegerVariable)) { flowchart.SetIntegerVariable(variableName, flowchart.GetIntegerVariable(variableName) + System.Int32.Parse(variableValue)); }
      if (v.GetType() == typeof(Fungus.BooleanVariable)) { flowchart.SetBooleanVariable(variableName, !flowchart.GetBooleanVariable(variableName)); }
    }
  }
  public AddToVariable[] addToVariable;

  [Tooltip("Only triggered by an object with one of these tags, or any object if left blank")]
  public string[] tagsThatCanTrigger;

  [Tooltip("Disables after triggering once")]
  public bool onlyTriggerOnce = false;

  /// <summary>Trigger this instance</summary>
  public void Trigger()
  {
    if (this.enabled)
    {
      if (setVariable != null) { System.Array.ForEach(setVariable, (i) => { i.Trigger(); }); }
      if (addToVariable != null) { System.Array.ForEach(addToVariable, (i) => { i.Trigger(); }); }
      if (broadcast != null) { System.Array.ForEach(broadcast, (i) => { i.Trigger(); }); }
      if (onlyTriggerOnce) { this.enabled = false; }
    }
  }

  private bool IsTaggedCorrectly(GameObject go)
  {
    return tagsThatCanTrigger.Length == 0 || System.Array.IndexOf(tagsThatCanTrigger, go.tag) >= 0;
  }

  void OnTriggerEnter(Collider other)
  {
    if (IsTaggedCorrectly(other.gameObject)) { Trigger(); }
  }

  void OnCollisionEnter(Collision collision)
  {
    if (IsTaggedCorrectly(collision.gameObject)) { Trigger(); }
  }

  void OnControllerColliderHit(ControllerColliderHit hit)
  {
    if (IsTaggedCorrectly(hit.collider.gameObject)) { Trigger(); }
  }

}