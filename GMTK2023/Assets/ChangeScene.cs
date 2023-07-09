using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [Tooltip("The string name of the scene")]
    [SerializeField] string SceneToGoTo;
    public void ChangeTheScene()
    {
        Debug.Log("Attempting to load next scene by name:" + SceneToGoTo);
        SceneManager.LoadScene(SceneToGoTo);
    }
}
