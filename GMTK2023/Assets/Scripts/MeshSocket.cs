using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MeshSocket : MonoBehaviour
{
    public MeshSockets.SocketId socketID;
    Transform attachPont;

    private void Start()
    {
        attachPont = transform.GetChild(0);
    }

    // I might need to change the offset depending on what the prefab the bird picks up is here.

    public void Attach(Transform objectTransform) { 
        objectTransform.SetParent(attachPont, false);
    }

}
