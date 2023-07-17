using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    [SerializeField] List<AudioSource> startButtonSounds;

    public void PlayStartButtonSound()
    {
        foreach(AudioSource sound in startButtonSounds) {
            sound.Play();
        }
        
    }

    public void PauseStartButtonSound()
    {
        foreach (AudioSource sound in startButtonSounds)
        {
            sound.Pause();
        }
    }

    public void StartGame()
    {
        Debug.Log("Attempting to load next scene by name: 1-CinematicOpening");
        SceneManager.LoadScene("1-CinematicOpening");
    }
}
