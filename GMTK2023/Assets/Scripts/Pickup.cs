using UnityEngine;

public class Pickup : MonoBehaviour
{
    // When hovered over, show the [E] to interact button

    // if (currentItem'sTurn) // only show the effect if it's a relevant item for the current quest. That way people don't see it sparkle too early
    // some kind of effect on pickups. Maybe just a particle effect

    [SerializeField] AudioSource pickupSound;
    GameObject player;

    [field: SerializeField]
    public GameObject QuestPickupEffect { get; private set; }

    [field: SerializeField, Header("Quest")]
    public QuestItemData QuestItem { get; private set; }

    private void Start()
    {
        player = GameObject.FindWithTag("Player");

        QuestManager.Instance.OnSetCurrentQuestEvent?.AddListener(OnSetCurrentQuestEventHandler);

        if (QuestPickupEffect) {
          QuestPickupEffect.SetActive(false);
        }
    }

    public void OnSetCurrentQuestEventHandler(QuestItemData questItem) {
      if (QuestPickupEffect) {
        QuestPickupEffect.SetActive(QuestItem && QuestItem == questItem);
      }
    }

    public void GrabTheItem()
    {
        if (!QuestManager.Instance.CurrentQuest || QuestManager.Instance.CurrentQuest.QuestItemNeeded != QuestItem)
        {
            return;
        }

        PlayPickupSound();
        player.GetComponent<PlayerInventory>().EquipItem(gameObject, gameObject.name);

        if (gameObject.TryGetComponent(out InteractableHover interactable))
        {
            interactable.enabled = false;
        }

        if (QuestItem) {
          QuestManager.Instance.PickupQuestItem(QuestItem);
        }
    }

    private void PlayPickupSound()
    {
        if (pickupSound != null)
        {
            pickupSound.Play();
        }
    }
}
