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
    if (QuestManager.Instance.CurrentQuest) {
      Debug.Log("I have CurrentQuest");
      if (QuestManager.Instance.CurrentQuestItem == QuestManager.Instance.CurrentQuest.QuestItemNeeded) {
        DialogUI.ShowDialogNode(actor, QuestManager.Instance.CurrentQuest.QuestPlayerHasItemText);
      } else {
        DialogUI.ShowDialogNode(actor, QuestManager.Instance.CurrentQuest.QuestPlayerMissingItemText);
      }
    } else if (actor.StartingQuest) {
      Debug.Log("I don't have a quest.");
      QuestManager.Instance.SetCurrentQuest(actor.StartingQuest);
      DialogUI.ShowDialogNode(actor, actor.StartingQuest.QuestStartText);
    } else {
      Debug.Log("Actor doesn't have a quest.");
    }
  }
}
