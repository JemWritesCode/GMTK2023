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

  readonly Collider[] _overlapBoxColliders = new Collider[10];
  InteractableHover _closestInteractable;

  void FixedUpdate() {
    _closestInteractable = GetClosestInteractable(InteractAgent.transform);

    if (InteractPanel) {
      InteractPanel.SetInteractable(_closestInteractable);
    }
  }

  InteractableHover GetClosestInteractable(Transform origin) {
    int count =
        Physics.OverlapBoxNonAlloc(
            origin.position + (origin.forward * 2f),
            Vector3.one * 2f,
            _overlapBoxColliders,
            origin.rotation,
            -1,
            QueryTriggerInteraction.Ignore);

    if (count <= 0) {
      return default;
    }

    InteractableHover closestInteractable = default;
    float closestDistance = 100f;

    for (int i = 0; i < count; i++) {
      Debug.DrawLine(origin.position, _overlapBoxColliders[i].transform.position, Color.red);
      if (_overlapBoxColliders[i].TryGetComponent(out InteractableHover interactable)) {
        float distance = Vector3.Distance(origin.position, _overlapBoxColliders[i].transform.position);

        if (distance < closestDistance) {
          closestDistance = distance;
          closestInteractable = interactable;
        }
      }
    }

    return closestInteractable;
  }
}
