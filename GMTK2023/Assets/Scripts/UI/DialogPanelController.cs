using DG.Tweening;

using TMPro;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogPanelController : MonoBehaviour {
  [field: SerializeField, Header("DialogPanel")]
  public CanvasGroup DialogPanel { get; private set; }

  [field: SerializeField]
  public TMP_Text DialogTitle { get; private set; }

  [field: SerializeField]
  public TMP_Text DialogText { get; private set; }

  [field: SerializeField]
  public Image SpeakerPortrait { get; private set; }

  [field: SerializeField]
  public Button ConfirmButton { get; private set; }

  [field: SerializeField]
  public TMP_Text ConfirmButtonLabel { get; private set; }

  [field: SerializeField, Header("QuestItemPanel")]
  public QuestItemPanelController QuestItemPanel { get; private set; }

  public bool IsPanelVisible { get; private set; }

  void Start() {
    ResetPanel();
    QuestItemPanel.HidePanel();
  }

  public void ResetPanel() {
    DialogPanel.alpha = 0f;
    DialogPanel.blocksRaycasts = false;
    IsPanelVisible = false;
  }

  public void ShowPanel() {
    DialogPanel.DOComplete(withCallbacks: true);
    InteractManager.Instance.CanInteract = false;
    DialogPanel.DOFade(1f, 0.25f)
        .OnComplete(() => {
          DialogPanel.blocksRaycasts = true;
          IsPanelVisible = true;
        });
  }

  public void HidePanel() {
    DialogPanel.DOComplete(withCallbacks: true);
    InteractManager.Instance.CanInteract = true;
    DialogPanel.DOFade(0f, 0.25f)
        .OnComplete(() => {
          DialogPanel.blocksRaycasts = false;
          IsPanelVisible = false;
        });
  }

  UnityAction _confirmAction;

  public void ShowDialogNode(DialogActor actor, string dialogText, UnityAction confirmAction = default) {
    DialogTitle.text = actor.ActorName;
    DialogText.text = dialogText;
    SpeakerPortrait.sprite = actor.ActorPortrait;
    SpeakerPortrait.transform.localScale = actor.ActorPortraitScale;

    _confirmAction = confirmAction;

    ShowPanel();
  }

  public void OnConfirmAction() {
    if (_confirmAction == null) {
      HidePanel();
    } else {
      UnityAction confirmAction = _confirmAction;
      _confirmAction = default;
      confirmAction();
    }
  }
}
