using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    private void Awake()
    {
        audioSource = audioSource.GetComponent<AudioSource>();
    }

    public void IncreasePitch(float delta)
    {
        audioSource.pitch += delta;
    }
}
