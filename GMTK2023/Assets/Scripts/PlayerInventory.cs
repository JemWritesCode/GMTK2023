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

    //Drop Object. Turn it into the scarecrow and delete it from the world
}

