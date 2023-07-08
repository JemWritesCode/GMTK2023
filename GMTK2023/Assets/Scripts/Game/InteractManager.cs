using UnityEngine;

public class InteractManager : MonoBehaviour {
  static InteractManager _instance;

  public static InteractManager Instance {
    get {
      if (!_instance) {
        _instance = FindObjectOfType<InteractManager>();

        if (!_instance) {
          GameObject interactManager = new("InteractManager");
          _instance = interactManager.AddComponent<InteractManager>();
          DontDestroyOnLoad(interactManager);
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
}
