using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    [SerializeField] private AudioSource backgroundAudioSource = null;
    [SerializeField] private AudioClip wallCrossClip = null;

    private AudioSource audioSource;

    private void Awake()
    {
        backgroundAudioSource = backgroundAudioSource.GetComponent<AudioSource>();
        audioSource = GetComponent<AudioSource>();
    }

    public void IncreaseBackgroundPitch(float delta)
    {
        backgroundAudioSource.pitch += delta;
    }

    public IEnumerator PlayWallCross(float delay)
    {
        yield return new WaitForSeconds(delay);

        audioSource.clip = wallCrossClip;
        audioSource.Play();
    }
}
