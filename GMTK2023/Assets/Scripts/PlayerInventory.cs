using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public GameObject objectPlayerIsHolding;

    MeshSockets sockets;

    private void Start()
    {
        sockets = GetComponent<MeshSockets>();
    }

    public void EquipItem(GameObject itemToEquip, string itemName)
    {
        objectPlayerIsHolding = itemToEquip;
        sockets.AttachToSocket(itemToEquip.transform, MeshSockets.SocketId.Body, itemName);
        // I should turn off the collider for the object the bird picks up because otherwise if he's picking up something big it can collide and influence the bird's movement
        objectPlayerIsHolding.GetComponent<MeshCollider>().enabled = false;
    }

    public void UnequipItem() {
      if (objectPlayerIsHolding) {
        objectPlayerIsHolding.SetActive(false);
        objectPlayerIsHolding = default;
      }
    }

    public void GiveItemToScarecrow(GameObject itemToUnequip)
    {
        Destroy(itemToUnequip);
    }
}

