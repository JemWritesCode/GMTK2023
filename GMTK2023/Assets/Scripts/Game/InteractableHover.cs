using SUPERCharacter;

using UnityEngine;
using UnityEngine.Events;

public class InteractableHover : MonoBehaviour {
  public UnityEvent OnInteract;

  [field: SerializeField]
  public float HoverDistance { get; set; } = 2f;

  [field: SerializeField]
  public string HoverText { get; set; } = "(E) Interact";

  public bool Interact() {
    OnInteract?.Invoke();
    return true;
  }
}
