using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("Attempting to load next scene by name: 1-CinematicOpening");
        SceneManager.LoadScene("1-CinematicOpening");
    }
}
