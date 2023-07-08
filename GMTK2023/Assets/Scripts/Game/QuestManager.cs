using UnityEngine;

public class QuestManager : MonoBehaviour {
  static QuestManager _instance;

  public static QuestManager Instance {
    get {
      if (!_instance) {
        _instance = FindObjectOfType<QuestManager>();

        if (!_instance) {
          GameObject questManager = new("QuestManager");
          _instance = questManager.AddComponent<QuestManager>();
          DontDestroyOnLoad(questManager);
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

  [field: SerializeField]
  public DialogNode CurrentQuest { get; private set; }

  public void SetCurrentQuest(DialogNode quest) {
    CurrentQuest = quest;
  }

  [field: SerializeField]
  public QuestItemData CurrentQuestItem { get; private set; }

  public void PickupQuestItem(QuestItemData questItem) {
    CurrentQuestItem = questItem;
  }

  public void ClearCurrentQuestItem() {
    CurrentQuestItem = default;
  }
}
