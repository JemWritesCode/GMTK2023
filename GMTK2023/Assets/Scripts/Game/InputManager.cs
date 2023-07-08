using UnityEngine;

public class InputManager : MonoBehaviour {
  [field: SerializeField, Header("UIControllers")]
  public DialogPanelController DialogPanel { get; private set; }

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
        DialogPanel.ShowPanel();
      }
    }
  }
}
