﻿using UnityEngine;

[CreateAssetMenu(menuName = "Dialog/DialogNode")]
public class DialogNode : ScriptableObject {
  [field: SerializeField, TextArea()]
  public string QuestStartText { get; private set; }

  [field: SerializeField]
  public QuestItemData QuestItemNeeded { get; private set; }

  [field: SerializeField, TextArea()]
  public string QuestPlayerMissingItemText { get; private set; }

  [field: SerializeField, TextArea()]
  public string QuestPlayerHasItemText { get; private set; }
}