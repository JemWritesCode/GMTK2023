using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    // When hovered over, show the [E] to interact button

    // some kind of effect on pickups. Maybe just a particle effect

    [SerializeField] AudioSource pickupSound;
    [SerializeField] GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    public void GrabTheItem()
    {
        PlayPickupSound();
        player.GetComponent<PlayerInventory>().EquipItem(gameObject);

        if (gameObject.TryGetComponent(out InteractableHover interactable))
        {
            interactable.enabled = false;
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
