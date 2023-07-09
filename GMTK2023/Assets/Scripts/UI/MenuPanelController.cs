using DG.Tweening;

using UnityEngine;
using UnityEngine.UI;

public class MenuPanelController : MonoBehaviour {
  [field: SerializeField]
  public CanvasGroup MenuPanel { get; private set; }

  [field: SerializeField]
  public Button QuitGameButton { get; private set; }

  public bool IsVisible { get; private set; }

  void Start() {
    ResetPanel();
  }

  public void ResetPanel() {
    IsVisible = false;
    MenuPanel.alpha = 0f;
    MenuPanel.blocksRaycasts = false;
  }

  public void ShowPanel() {
    IsVisible = true;
    MenuPanel.DOFade(1f, 0.25f);
    MenuPanel.blocksRaycasts = true;
  }

  public void HidePanel() {
    IsVisible = false;
    MenuPanel.DOFade(0f, 0.25f);
    MenuPanel.blocksRaycasts = false;
  }

  public void TogglePanel() {
    if (IsVisible) {
      HidePanel();
    } else {
      ShowPanel();
    }
  }

  public void OnQuitGameButton() {
#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
  }
}
