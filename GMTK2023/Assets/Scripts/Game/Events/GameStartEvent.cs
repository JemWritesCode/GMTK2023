using System.Collections;

using UnityEngine;

public class GameStartEvent : MonoBehaviour{
  [field: SerializeField]
  public DialogActor OpeningConvoActor { get; private set; }

  [field: SerializeField]
  public DialogNode OpeningConvoNode { get; private set; }

  void Start() {
    StartCoroutine(StartOpeningConvo());
  }

  IEnumerator StartOpeningConvo() {
    yield return new WaitForSeconds(1f);

    DialogManager.Instance.ProcessNode(OpeningConvoActor, OpeningConvoNode);
  }
}
