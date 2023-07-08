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

    public void Equip(GameObject itemToEquip)
    {
        objectPlayerIsHolding = itemToEquip;
        sockets.Attach(itemToEquip.transform, MeshSockets.SocketId.Beak);
    }
}

