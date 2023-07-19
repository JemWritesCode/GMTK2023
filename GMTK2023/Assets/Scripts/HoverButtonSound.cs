using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverButtonSound : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] List<AudioSource> startButtonSounds;

    public void OnPointerEnter(PointerEventData eventData)
    {
        PlayButtonSound();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        PauseButtonSound();
    }


    public void PlayButtonSound()
    {
        foreach (AudioSource sound in startButtonSounds)
        {
            sound.Play();
        }

    }

    public void PauseButtonSound()
    {
        foreach (AudioSource sound in startButtonSounds)
        {
            sound.Pause();
        }
    }
}
