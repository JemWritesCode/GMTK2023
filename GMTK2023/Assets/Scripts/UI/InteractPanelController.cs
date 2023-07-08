using DG.Tweening;

using TMPro;

using UnityEngine;

public class InteractPanelController : MonoBehaviour {
  [field: SerializeField]
  public CanvasGroup InteractPanel { get; private set; }

  [field: SerializeField]
  public TMP_Text InteractText { get; private set; }

  public bool IsVisible { get; private set; }
  public InteractableHover CurrentInteractable { get; private set; }

  void Start() {
    ResetPanel();
  }

  public void ResetPanel() {
    InteractPanel.alpha = 0f;
    InteractPanel.blocksRaycasts = false;
    InteractText.text = "...";
    IsVisible = false;
  }

  public void SetInteractable(InteractableHover interactable) {
    if (CurrentInteractable == interactable) {
      return;
    }

    CurrentInteractable = interactable;

    if (interactable) {
      ShowInteractPanel(interactable.HoverText);
    } else {
      HideInteractPanel();
    }
  }

  public void ShowInteractPanel(string interactText) {
    InteractText.text = interactText;
    IsVisible = true;

    InteractPanel.DOComplete(withCallbacks: true);

    DOTween.Sequence()
        .SetTarget(InteractPanel)
        .Insert(0f, InteractPanel.transform.DOPunchPosition(new(0f, 40f, 0f), 0.4f, 0, 0f))
        .Insert(0.2f, InteractPanel.DOFade(1f, 0.2f));
  }

  public void HideInteractPanel() {
    IsVisible = false;
    InteractPanel.DOComplete(withCallbacks: false);
    InteractPanel.DOFade(0f, 0.2f);
  }
}
