using DG.Tweening;

using TMPro;

using UnityEngine;

public class QuestTrackerPanelController : MonoBehaviour {
  [field: SerializeField]
  public CanvasGroup QuestTrackerPanel { get; private set; }

  [field: SerializeField]
  public TMP_Text QuestTitle { get; private set; }

  [field: SerializeField]
  public TMP_Text QuestInfo { get; private set; }

  public bool IsPanelVisible { get; private set; }

  void Start() {
    ResetPanel();
  }

  public void ResetPanel() {
    QuestTrackerPanel.alpha = 0f;
    IsPanelVisible = false;
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
    QuestTitle.text = questTitle;
    QuestInfo.text = questInfo;

    ShowPanel();
  }
}
