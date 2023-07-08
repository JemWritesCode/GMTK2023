using TMPro;

using UnityEngine;
using UnityEngine.UI;

public class DialogPanelController : MonoBehaviour {
  [field: SerializeField]
  public CanvasGroup DialogPanel { get; private set; }

  [field: SerializeField]
  public TMP_Text DialogText { get; private set; }

  [field: SerializeField]
  public Button ConfirmButton { get; private set; }

  [field: SerializeField]
  public TMP_Text ConfirmButtonLabel { get; private set; }
}
