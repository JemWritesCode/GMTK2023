using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MeshSocket : MonoBehaviour
{
    public MeshSockets.SocketId socketID;
    Transform attachPont;

    // I might need to change the offset depending on what the prefab the bird picks up is here.a

    public void AttachToSocketOffset(Transform objectTransform, string itemName) {
        attachPont = transform.Find(itemName + "Offset");
        objectTransform.SetParent(attachPont, false);
        
    }

}
