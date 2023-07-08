using System.Collections.Generic;

using UnityEngine;

[CreateAssetMenu(menuName = "Dialog/DialogNode")]
public class DialogNode : ScriptableObject {
  public enum DialogNodeType {
    Conversation,
    FindItemQuest
  }

  [field: SerializeField, Header("Node")]
  public DialogNodeType NodeType { get; private set; }

  [field: SerializeField]
  public DialogNode NextNode { get; private set; }

  [field: SerializeField, Header("Conversation")]
  public List<string> ConversationTexts { get; private set; }

  [field: SerializeField, Header("Quest")]
  public QuestItemData QuestItemNeeded { get; private set; }

  [field: SerializeField, TextArea()]
  public string QuestStartText { get; private set; }

  [field: SerializeField, TextArea()]
  public string QuestPlayerMissingItemText { get; private set; }

  [field: SerializeField, TextArea()]
  public string QuestPlayerHasItemText { get; private set; }

  [field: Header("QuestTracker")]
  [field: SerializeField]
  public string TrackerTitle { get; private set; }

  [field: SerializeField, TextArea()]
  public string TrackerInfoItemMissingText { get; private set; }

  [field: SerializeField, TextArea()]
  public string TrackerInfoItemFoundText { get; private set; }

}