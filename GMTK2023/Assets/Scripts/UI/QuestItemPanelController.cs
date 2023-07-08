using DG.Tweening;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

public class QuestItemPanelController : MonoBehaviour {
  [field: SerializeField]
  public CanvasGroup QuestItemPanel { get; private set; }

  [field: SerializeField, Header("Item")]
  public Image ItemSprite { get; private set; }

  [field: SerializeField]
  public TMP_Text ItemName { get; private set; }

  [field: SerializeField]
  public TMP_Text ItemDescription { get; private set; }

  public void ResetPanel() {
    QuestItemPanel.alpha = 0f;
    QuestItemPanel.blocksRaycasts = false;
  }

  public void ShowPanel(QuestItemData questItem) {
    QuestItemPanel.DOComplete(true);

    DOTween.Sequence()
        .SetTarget(QuestItemPanel)
        .Insert(0f, QuestItemPanel.DOFade(0f, 0.15f))
        .InsertCallback(0.15f, () => {
          ItemName.text = questItem.ItemName;
          ItemDescription.text = questItem.ItemDescription;
        })
        .Insert(0f, ItemName.transform.DOPunchPosition(new(0f, 7.5f, 0f), 0.3f, 0, 0))
        .Insert(0f, ItemDescription.transform.DOPunchPosition(new(0f, 7.5f, 0f), 0.3f, 0, 0))
        .Insert(0.15f, QuestItemPanel.DOFade(1f, 0.15f));
  }

  public void HidePanel() {
    QuestItemPanel.DOComplete(true);
    QuestItemPanel.DOFade(0f, 0.25f);
  }
}
