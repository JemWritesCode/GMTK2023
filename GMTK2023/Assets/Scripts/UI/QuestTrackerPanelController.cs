using DG.Tweening;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

public class QuestTrackerPanelController : MonoBehaviour {
  [field: SerializeField]
  public CanvasGroup QuestTrackerPanel { get; private set; }

  [field: SerializeField]
  public TMP_Text QuestTitle { get; private set; }

  [field: SerializeField]
  public TMP_Text QuestInfo { get; private set; }

  [field: SerializeField]
  public Image ItemImage { get; private set; }

  public bool IsPanelVisible { get; private set; }

  void Start() {
    ResetPanel();
  }

  public void ResetPanel() {
    QuestTrackerPanel.alpha = 0f;
    IsPanelVisible = false;
    ItemImage.fillAmount = 0f;
  }

  public void ShowPanel() {
    QuestTrackerPanel.DOFade(1f, 0.25f);
    IsPanelVisible = true;
  }

  public void HidePanel() {
    QuestTrackerPanel.DOFade(0f, 0.25f);
    IsPanelVisible = false;
  }

  public void ShowQuestInfo(string questTitle, string questInfo) {
    DOTween.Complete(QuestTrackerPanel);

    QuestTitle.text = questTitle;
    QuestInfo.text = questInfo;

    DOTween.Sequence()
        .SetTarget(QuestTrackerPanel)
        .Insert(0f, ItemImage.DOFillAmount(0f, 0.15f))
        .Insert(0f, QuestTitle.transform.DOPunchPosition(new(0f, 8f, 0f), 0.3f, 0, 0))
        .Insert(0f, QuestInfo.transform.DOPunchPosition(new(0f, -8f, 0f), 0.3f, 0, 0))
        .Insert(0.15f, QuestTrackerPanel.DOFade(1f, 0.15f));

    IsPanelVisible = true;
  }

  public void ShowQuestItem(QuestItemData questItem) {
    ItemImage.sprite = questItem.ItemSprite;
    ItemImage.DOFillAmount(1f, 0.25f);
  }
}
