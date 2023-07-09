using UnityEngine;

public class DialogManager : MonoBehaviour {
  [field: SerializeField, Header("UI")]
  public DialogPanelController DialogUI { get; private set; }

  static DialogManager _instance;

  public static DialogManager Instance {
    get {
      if (!_instance) {
        _instance = FindObjectOfType<DialogManager>();

        if (!_instance) {
          GameObject dialogManager = new("DialogManager");
          _instance = dialogManager.AddComponent<DialogManager>();
          DontDestroyOnLoad(dialogManager);
        }
      }

      return _instance;
    }
  }

  void Awake() {
    if (_instance) {
      Destroy(this);
    } else {
      _instance = this;
      DontDestroyOnLoad(gameObject);
    }
  }

  public void InteractWithActor(DialogActor actor) {
    if (DialogUI.IsPanelVisible) {
      return;
    }

    if (QuestManager.Instance.CurrentQuest) {
      ProcessNode(actor, QuestManager.Instance.CurrentQuest);
    } else {
      ProcessNode(actor, actor.StartingQuest);
    }
  }

  public void ProcessFindItemQuestNode(DialogActor actor, DialogNode node) {
    if (QuestManager.Instance.CurrentQuest == node) {
      if (QuestManager.Instance.CurrentQuestItem == node.QuestItemNeeded) {
        DialogUI.ShowDialogNode(
            actor,
            node.QuestPlayerHasItemText,
            () => ProcessNode(actor, node.NextNode));

        QuestManager.Instance.ClearCurrentQuest();
        QuestManager.Instance.ClearCurrentQuestItem();
      } else {
        DialogUI.ShowDialogNode(actor, node.QuestPlayerMissingItemText);
      }
    } else {
      QuestManager.Instance.SetCurrentQuest(node);
      DialogUI.ShowDialogNode(actor, node.QuestStartText);
    }
  }

  public void ProcessConversationNode(DialogActor actor, DialogNode node) {

  }

  public void ProcessNode(DialogActor actor, DialogNode node) {
    if (!node) {
      DialogUI.HidePanel();
      return;
    }

    if (node.NodeType == DialogNode.DialogNodeType.Conversation) {

    } else if (node.NodeType == DialogNode.DialogNodeType.FindItemQuest) {
      ProcessFindItemQuestNode(actor, node);
    }
  }
}
