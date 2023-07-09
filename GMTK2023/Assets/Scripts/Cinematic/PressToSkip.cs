using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;

public class PressToSkip : MonoBehaviour {
  void LateUpdate() {
    if (Input.GetKeyDown(KeyCode.Q)) {
      if (_loadNextSceneCoroutine == null) {
        _loadNextSceneCoroutine = StartCoroutine(LoadNextScene());
      }
    }
  }

  Coroutine _loadNextSceneCoroutine;

  IEnumerator LoadNextScene() {
    yield return null;
    SceneManager.LoadScene("2-MainLevel");
  }
}
