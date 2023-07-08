using DG.Tweening;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

public class DialogPanelController : MonoBehaviour {
  [field: Header("UI")]
  [field: SerializeField]
  public CanvasGroup DialogPanel { get; private set; }

  [field: SerializeField]
  public TMP_Text DialogText { get; private set; }

  [field: SerializeField]
  public Button ConfirmButton { get; private set; }

  [field: SerializeField]
  public TMP_Text ConfirmButtonLabel { get; private set; }

  public bool IsPanelVisible { get; private set; }

  void Start() {
    ResetPanel();
  }

  public void ResetPanel() {
    DialogPanel.alpha = 0f;
    DialogPanel.blocksRaycasts = false;
    IsPanelVisible = false;
  }

  public void ShowPanel() {
    DialogPanel.DOFade(1f, 0.25f);
    DialogPanel.blocksRaycasts = true;
    IsPanelVisible = true;
  }

  public void HidePanel() {
    DialogPanel.DOFade(0f, 0.25f);
    DialogPanel.blocksRaycasts = false;
    IsPanelVisible = false;
  }
}