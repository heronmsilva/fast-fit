using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    [SerializeField] private AudioSource backgroundAudioSource;

    private void Awake()
    {
        backgroundAudioSource = backgroundAudioSource.GetComponent<AudioSource>();
    }

    public void IncreaseBackgroundPitch(float delta)
    {
        backgroundAudioSource.pitch += delta;
    }
}
