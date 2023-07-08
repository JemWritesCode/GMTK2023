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

  }
}
