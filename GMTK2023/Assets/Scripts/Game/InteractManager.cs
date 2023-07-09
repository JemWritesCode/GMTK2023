using UnityEngine;

public class InteractManager : MonoBehaviour {
  [field: SerializeField, Header("Agent")]
  public GameObject InteractAgent { get; private set; }

  [field: SerializeField, Header("UI")]
  public InteractPanelController InteractPanel { get; private set; }

  static InteractManager _instance;

  public static InteractManager Instance {
    get {
      if (!_instance) {
        _instance = FindObjectOfType<InteractManager>();

        if (!_instance) {
          GameObject interactManager = new("InteractManager");
          _instance = interactManager.AddComponent<InteractManager>();
          DontDestroyOnLoad(interactManager);
        }
      }

      return _instance;
    }
  }

  void Awake() {
    if (_instance) {
      Destroy(this);
    } else {
      _instance = this;
      DontDestroyOnLoad(gameObject);
    }
  }

  void Start() {
    _mainCamera = Camera.main;
  }

  Camera _mainCamera;
  readonly RaycastHit[] _raycastHits = new RaycastHit[10];
  InteractableHover _closestInteractable;

  void FixedUpdate() {
    _closestInteractable = GetClosestInteractable(InteractAgent.transform);
  }

  void Update() {
    InteractPanel.SetInteractable(_closestInteractable);
  }

  InteractableHover GetClosestInteractable(Transform origin) {
    int count =
        Physics.SphereCastNonAlloc(
            origin.position,
            1f,
            _mainCamera.transform.forward,
            _raycastHits,
            5f,
            -1,
            QueryTriggerInteraction.Ignore);

    if (count <= 0) {
      return default;
    }

    for (int i = 0; i < count; i++) {
      if (_raycastHits[i].collider.TryGetComponent(out InteractableHover interactable)
          && interactable.enabled
          && _raycastHits[i].distance <= interactable.HoverDistance) {
        return interactable;
      }
    }

    return default;
  }
}
