using System.Collections.Generic;

using UnityEngine;

public class QuestMarkerTarget : MonoBehaviour {
  public static readonly List<QuestMarkerTarget> Targets = new();

  [field: SerializeField]
  public string TargetTag { get; private set; } = string.Empty;

  [field: SerializeField]
  public Vector3 TargetOffset { get; private set; } = Vector3.zero;

  [field: SerializeField, Header("UI")]
  public string MarkerLabel { get; private set; } = string.Empty;

  void Start() {
    Targets.Add(this);
  }

  void OnDestroy() {
    Targets.Remove(this);
  }
}