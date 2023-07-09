using System.Collections;

using UnityEngine;

public class GameStartEvent : MonoBehaviour{
  [field: SerializeField]
  public DialogActor OpeningConvoActor { get; private set; }

  [field: SerializeField]
  public DialogNode OpeningConvoNode { get; private set; }

  void Start() {
    StartCoroutine(StartOpeningConvo());
    StartCoroutine(ShowHelpPanel());
  }

  IEnumerator StartOpeningConvo() {
    yield return null;
    InputManager.Instance.UnlockCursor();

    yield return new WaitForSeconds(0.5f);

    DialogManager.Instance.ProcessNode(OpeningConvoActor, OpeningConvoNode);
  }

  IEnumerator ShowHelpPanel() {
    yield return new WaitForSeconds(1f);

    InputManager.Instance.MenuPanel.ShowHelpPanel();

    yield return new WaitForSeconds(7.5f);

    if (!InputManager.Instance.MenuPanel.IsVisible) {
      InputManager.Instance.MenuPanel.HideHelpPanel();
    }
  }
}
