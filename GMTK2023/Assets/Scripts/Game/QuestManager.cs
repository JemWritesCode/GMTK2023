using UnityEngine;
using UnityEngine.Events;

public class QuestManager : MonoBehaviour {
  [field: SerializeField]
  public QuestTrackerPanelController QuestTrackerPanel { get; private set; }

  static QuestManager _instance;

  public static QuestManager Instance {
    get {
      if (!_instance) {
        _instance = FindObjectOfType<QuestManager>();

        if (!_instance) {
          GameObject questManager = new("QuestManager");
          _instance = questManager.AddComponent<QuestManager>();
          //DontDestroyOnLoad(questManager);
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
      //DontDestroyOnLoad(gameObject);
    }
  }

  public UnityEvent<QuestItemData> OnSetCurrentQuestEvent;

  [field: SerializeField]
  public DialogNode CurrentQuest { get; private set; }

  public void SetCurrentQuest(DialogNode quest) {
    CurrentQuest = quest;
    QuestTrackerPanel.ShowQuestInfo(quest.TrackerTitle, quest.TrackerInfoItemMissingText);
    OnSetCurrentQuestEvent?.Invoke(quest.QuestItemNeeded);
  }

  public void ClearCurrentQuest() {
    CurrentQuest = default;
    QuestTrackerPanel.HidePanel();
    OnSetCurrentQuestEvent?.Invoke(default);
  }

  [field: SerializeField]
  public QuestItemData CurrentQuestItem { get; private set; }

  public void PickupQuestItem(QuestItemData questItem) {
    CurrentQuestItem = questItem;

    if (CurrentQuest) {
      QuestTrackerPanel.ShowQuestInfo(CurrentQuest.TrackerTitle, CurrentQuest.TrackerInfoItemFoundText);
      QuestTrackerPanel.ShowQuestItem(CurrentQuest.QuestItemNeeded);
    }
  }

  public void ClearCurrentQuestItem() {
    CurrentQuestItem = default;
    ClearPlayerEquippedQuestItem();
  }

  public void ClearPlayerEquippedQuestItem() {
    GameObject player = GameObject.FindWithTag("Player");
    if (player && player.TryGetComponent(out PlayerInventory inventory)) {
      inventory.UnequipItem();
    }
  }
}
