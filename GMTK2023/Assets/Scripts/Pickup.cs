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

    private void Update()
    {
        grabTheItem(itemToPickup); // jemdebug
    }

    public void grabTheItem(GameObject itemToGrab)
    {
        // add to player inventory. I think it'll be byref based on what was being raycasted 
        // lets not instantiate or destroy because that takes resources. simply move it's position to being attached to the bird

        //GameObject.Destroy(this.gameObject);
        itemToGrab.transform.SetParent(GameObject.FindWithTag("Player").transform); // this sets it to be a child of the player BUT it's transform is relative to the center of the player, it's not connected to the animation rig
        PlayPickupSound();

    }

    private void PlayPickupSound()
    {
        if (pickupSound != null)
        {
            pickupSound.Play();
        }
    }
}
