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
        sockets.AttachToSocket(itemToEquip.transform, MeshSockets.SocketId.Body);
    }

    public void GiveItemToScarecrow(GameObject itemToUnequip)
    {
        Destroy(itemToUnequip);
    }
}

