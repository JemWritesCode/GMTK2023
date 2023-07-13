using System;

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
          //DontDestroyOnLoad(interactManager);
        }
      }

      return _instance;
    }
  }

  public bool CanInteract { get; set; } = true;

  void Awake() {
    if (_instance) {
      Destroy(this);
    } else {
      _instance = this;
      //DontDestroyOnLoad(gameObject);
    }
  }

  void Start() {
    _mainCamera = Camera.main;
  }

  Camera _mainCamera;

  readonly RaycastHit[] _raycastHits = new RaycastHit[10];
  readonly float[] _hitDistanceCache = new float[10];

  public InteractableHover ClosestInteractable { get; private set; }

  void FixedUpdate() {
    ClosestInteractable = CanInteract && InteractAgent ? GetClosestInteractable(InteractAgent.transform) : default;
  }

  void Update() {
    InteractPanel.SetInteractable(ClosestInteractable);
  }

  InteractableHover GetClosestInteractable(Transform origin) {
    int count =
        Physics.SphereCastNonAlloc(
            origin.position,
            0.25f,
            _mainCamera.transform.forward,
            _raycastHits,
            4f,
            -1,
            QueryTriggerInteraction.Ignore);

    if (count <= 0) {
      return default;
    }

    for (int i = 0; i < count; i++) {
      _hitDistanceCache[i] = _raycastHits[i].distance;
    }

    Array.Sort(_hitDistanceCache, _raycastHits, 0, count);

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
