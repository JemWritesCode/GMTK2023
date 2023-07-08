using UnityEngine;

public class InputManager : MonoBehaviour {
  [field: SerializeField, Header("UI")]
  public DialogPanelController DialogPanel { get; private set; }

  [field: SerializeField]
  public QuestItemPanelController QuestItemPanel { get; private set; }

  public DialogActor TestDialogActor;
  public DialogNode TestDialogNode;
  public QuestItemData TestQuestItem;

  static InputManager _instance;

  public static InputManager Instance {
    get {
      if (!_instance) {
        _instance = FindObjectOfType<InputManager>();

        if (!_instance) {
          GameObject inputManager = new("InputManager");
          _instance = inputManager.AddComponent<InputManager>();
          DontDestroyOnLoad(inputManager);
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

  void Update() {
    if (Input.GetKeyDown(KeyCode.Tab)) {
      if (DialogPanel.IsPanelVisible) {
        DialogPanel.HidePanel();
        QuestItemPanel.HidePanel();
      } else {
        DialogPanel.ShowDialogNode(TestDialogActor, TestDialogNode);
      }
    }
  }
}
