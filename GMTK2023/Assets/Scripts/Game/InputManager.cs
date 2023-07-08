using UnityEngine;

public class InputManager : MonoBehaviour {
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
}
