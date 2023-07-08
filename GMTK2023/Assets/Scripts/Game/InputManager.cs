using SUPERCharacter;

using UnityEditor;

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
      } else {
        DialogPanel.ShowDialogNode(TestDialogActor, TestDialogNode);
      }
    }

    UpdateCursorLockState();
  }

  SUPERCharacterAIO _playerCharacterController;

  public SUPERCharacterAIO PlayerCharacterController {
    get {
      if (!_playerCharacterController) {
        _playerCharacterController =
          GameObject.FindGameObjectWithTag("Player").GetComponent<SUPERCharacterAIO>();
      }

      return _playerCharacterController;
    }
  }

  public bool IsCursorLocked { get; private set; }

  public void UpdateCursorLockState() {
    bool shouldUnlockCursor = DialogPanel.IsPanelVisible;

    if (shouldUnlockCursor) {
      if (IsCursorLocked) {
        UnlockCursor();
      }
    } else {
      if (!IsCursorLocked) {
        LockCursor();
      }
    }
  }

  public void LockCursor() {
    IsCursorLocked = true;
    PlayerCharacterController.UnpausePlayer();

    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
  }

  public void UnlockCursor() {
    IsCursorLocked = false;
    PlayerCharacterController.PausePlayer(PauseModes.BlockInputOnly);

    Cursor.lockState = CursorLockMode.Confined;
    Cursor.visible = true;
  }
}
