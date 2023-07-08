using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshSockets : MonoBehaviour
{
    public enum SocketId
    {
        Beak
    }

    Dictionary<SocketId, MeshSocket> socketMap = new Dictionary<SocketId, MeshSocket>();

    private void Start()
    {
        MeshSocket[] sockets = GetComponentsInChildren<MeshSocket>();
            foreach (MeshSocket socket in sockets) {
            socketMap[socket.socketID] = socket;
            }
    }

    public void Attach(Transform objectTransform, SocketId socketId)
    {
        socketMap[socketId].Attach(objectTransform);
    }

}
