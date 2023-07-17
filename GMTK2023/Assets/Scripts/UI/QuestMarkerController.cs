using DG.Tweening;

using System.Collections;

using TMPro;

using UnityEngine;

public class QuestMarkerController : MonoBehaviour {
  [field: SerializeField]
  public CanvasGroup MarkerCanvasGroup { get; private set; }

  [field: SerializeField]
  public RectTransform MarkerRectTransform { get; private set; }

  [field: SerializeField]
  public TMP_Text MarkerLabel { get; private set; }

  public bool IsVisible { get; private set; }

  private void Start() {
    ResetMarker();
  }

  public void ResetMarker() {
    StopTrackTarget();

    IsVisible = false;
    MarkerCanvasGroup.alpha = 0f;
    MarkerRectTransform.anchoredPosition = Vector2.zero;
  }

  public void HideMarker() {
    StopTrackTarget();

    IsVisible = false;
    MarkerCanvasGroup.DOFade(0f, 0.25f);
  }

  public void ShowMarkerOnTarget(QuestMarkerTarget target) {
    RestartTrackTarget(target);
    MarkerLabel.text = target.MarkerLabel;

    IsVisible = true;
    MarkerCanvasGroup.DOFade(1f, 0.25f);
  }

  Coroutine _trackTargetCoroutine;

  void StopTrackTarget() {
    if (_trackTargetCoroutine != null) {
      StopCoroutine(_trackTargetCoroutine);
      _trackTargetCoroutine = null;
    }
  }

  void RestartTrackTarget(QuestMarkerTarget target) {
    StopTrackTarget();
    _trackTargetCoroutine = StartCoroutine(TrackTarget(target));
  }

  IEnumerator TrackTarget(QuestMarkerTarget target) {
    Camera camera = Camera.main;
    float factor = GetComponentInParent<Canvas>().scaleFactor;
    Vector2 sizeDelta = MarkerRectTransform.sizeDelta;
    float width = Screen.width / factor;
    float height = Screen.height / factor;

    while (target) {
      yield return null;

      Vector3 screenPoint = camera.WorldToScreenPoint(target.transform.position + target.TargetOffset);

      MarkerRectTransform.anchoredPosition =
          new(Mathf.Clamp(screenPoint.x / factor, 0f, width), Mathf.Clamp(screenPoint.y / factor, 0f, height));
    }
  }
}
