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

    public void Attach(Transform objectTransform) { 
        objectTransform.SetParent(attachPont, false);
    }

}
