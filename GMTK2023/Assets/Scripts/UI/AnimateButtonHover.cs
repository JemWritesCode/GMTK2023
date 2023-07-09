using DG.Tweening;

using UnityEngine;
using UnityEngine.EventSystems;

public class AnimateStart : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
  [field: SerializeField]
  public Vector3 DoScaleEndValue { get; private set; } = Vector3.one;

  [field: SerializeField, Min(0f)]
  public float DoScaleDuration { get; private set; } = 0.5f;

  private Tweener _onHoverTweener;

  private void Start() {
    _onHoverTweener =
        transform
            .DOScale(DoScaleEndValue, DoScaleDuration)
            .SetLink(gameObject)
            .SetAutoKill(false)
            .SetUpdate(true)
            .Pause();
  }

  public void OnPointerEnter(PointerEventData eventData) {
    if (_onHoverTweener.IsPlaying()) {
      _onHoverTweener.PlayForward();
    } else {
      _onHoverTweener.Restart();
    }
  }

  public void OnPointerExit(PointerEventData eventData) {
    _onHoverTweener.SmoothRewind();
  }
}
