using SUPERCharacter;

using UnityEngine;

public class Pickup : MonoBehaviour
{
    // When hovered over, show the [E] to interact button.

    [SerializeField] AudioSource pickupSound;

    // Only show the effect if it's a relevant item for the current quest.
    // That way people don't see it sparkle too early.
    // Some kind of effect on pickups. Maybe just a particle effect.

    [field: SerializeField, Header("Quest")]
    public GameObject QuestPickupEffect { get; private set; }

    [field: SerializeField]
    public QuestItemData QuestItem { get; private set; }

    [field: SerializeField]
    public InteractableHover PickupInteractable { get; private set; } 

    GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");

        QuestManager.Instance.OnSetCurrentQuestEvent?.AddListener(OnSetCurrentQuestEventHandler);

        if (QuestPickupEffect) {
          QuestPickupEffect.SetActive(false);
        }

        // If the Pickup has an Interactable, only enable it when it's the current quest item.
        if (PickupInteractable) {
          PickupInteractable.enabled = false;
        }
    }

    public void OnSetCurrentQuestEventHandler(QuestItemData questItem) {
      if (QuestPickupEffect) {
        QuestPickupEffect.SetActive(QuestItem && QuestItem == questItem);
      }

      if (PickupInteractable) {
        PickupInteractable.enabled = QuestItem && QuestItem == questItem;
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

        if (QuestPickupEffect) {
          QuestPickupEffect.SetActive(false);
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
