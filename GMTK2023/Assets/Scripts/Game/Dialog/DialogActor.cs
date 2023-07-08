using UnityEngine;

[CreateAssetMenu(menuName = "Dialog/DialogActor")]
public class DialogActor : ScriptableObject {
  [field: SerializeField, Header("UI")]
  public string ActorName { get; private set; }

  [field: SerializeField]
  public Sprite ActorPortrait { get; private set; }

  [field: SerializeField]
  public Vector3 ActorPortraitScale { get; private set; } = Vector3.one;

  [field: SerializeField, Header("Quest")]
  public DialogNode CurrentQuestNode { get; private set; }
}
