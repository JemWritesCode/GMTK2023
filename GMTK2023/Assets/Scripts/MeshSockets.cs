using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshSockets : MonoBehaviour
{
    public enum SocketId
    {
        Body
    }

    Dictionary<SocketId, MeshSocket> socketMap = new Dictionary<SocketId, MeshSocket>();

    private void Start()
    {
        MeshSocket[] sockets = GetComponentsInChildren<MeshSocket>();
            foreach (MeshSocket socket in sockets) {
            socketMap[socket.socketID] = socket;
            }
    }

    public void AttachToSocket(Transform objectTransform, SocketId socketId)
    {
        socketMap[socketId].AttachToSocketOffset(objectTransform);
    }

}
