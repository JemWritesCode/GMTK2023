using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    // When hovered over, show the [E] to interact button


    // isPickup?
    // some kind of effect on pickups. Maybe just a particle effect
    // if they pick it up then put the prefab in the bird's mouth (this will have to be done to make sure the player can tell they picked it up)

    // when picked up, change on the Player what object they are holding
    // and delete the object from it's place in the world

    [SerializeField] GameObject itemToPickup;
    [SerializeField] AudioSource pickupSound;
    [SerializeField] GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        GrabTheItem(itemToPickup); // jemdebug, this needs to be tied to e to interact
    }

    public void GrabTheItem(GameObject itemToGrab)
    {
        MakePlayerHoldItem(itemToGrab);
        PlayPickupSound();
    }

    private void MakePlayerHoldItem(GameObject itemToGrab)
    {
        itemToGrab.transform.SetParent(player.transform);
        player.GetComponent<PlayerInventory>().objectPlayerIsHolding = itemToGrab;
    }

    private void PlayPickupSound()
    {
        if (pickupSound != null)
        {
            pickupSound.Play();
        }
    }
}
