using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public GameObject objectPlayerIsHolding;

    MeshSockets sockets;

    private void Start()
    {
        sockets = GetComponent<MeshSockets>();
    }

    public void EquipItem(GameObject itemToEquip)
    {
        objectPlayerIsHolding = itemToEquip;
        sockets.Attach(itemToEquip.transform, MeshSockets.SocketId.Beak);
    }

    public void GiveItemToScarecrow(GameObject itemToUnequip)
    {
        Destroy(itemToUnequip);
    }
}

