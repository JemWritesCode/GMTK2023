using SUPERCharacter;

using UnityEngine;

public class InputManager : MonoBehaviour {
  [field: SerializeField, Header("UI")]
  public MenuPanelController MenuPanel { get; private set; }

  [field: SerializeField]
  public DialogPanelController DialogPanel { get; private set; }

  [field: SerializeField]
  public InteractPanelController InteractPanel { get; private set; }

  [field: SerializeField]
  public QuestTrackerPanelController QuestTrackerPanel { get; private set; }

  [field: SerializeField, Header("KeyBinds")]
  public KeyCode InteractKey { get; private set; } = KeyCode.E;

#if UNITY_EDITOR
  public const KeyCode ToggleMenuKey = KeyCode.F2;
#else
  public const KeyCode ToggleMenuKey = KeyCode.Escape;
#endif

  static InputManager _instance;

  public static InputManager Instance {
    get {
      if (!_instance) {
        _instance = FindObjectOfType<InputManager>();

        if (!_instance) {
          GameObject inputManager = new("InputManager");
          _instance = inputManager.AddComponent<InputManager>();
          //DontDestroyOnLoad(inputManager);
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

  void Update() {
    if (Input.GetKeyDown(ToggleMenuKey) || Input.GetKeyDown(KeyCode.Tab)) {
      MenuPanel.TogglePanel();
    }

    if (Input.GetKeyDown(InteractKey)) {
      if (DialogPanel.IsPanelVisible) {
        DialogPanel.OnConfirmAction();
      } else if (InteractManager.Instance.ClosestInteractable) {
        InteractManager.Instance.ClosestInteractable.Interact();
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
    bool shouldUnlockCursor = MenuPanel.IsVisible || DialogPanel.IsPanelVisible;

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
