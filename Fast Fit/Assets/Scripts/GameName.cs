using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameName : MonoBehaviour
{
    [SerializeField] private AudioClip letterEntry = null;
    [SerializeField] private AudioSource audioSource = null;

    private void LetterEntry()
    {
        audioSource.PlayOneShot(letterEntry);
    }
}
