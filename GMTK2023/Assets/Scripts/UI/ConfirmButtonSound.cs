using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmButtonSound : MonoBehaviour
{
    [SerializeField] AudioSource confirmButtonSound;

    public void PlayConfirmButtonSound()
    {
        // if it's already playing don't play it again though because if someone is spamming ok it's annoying
        if (confirmButtonSound != null)
        {
            confirmButtonSound.Play();
        }
    }
}
