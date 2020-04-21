using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    [SerializeField] private AudioSource backgroundAudioSource = null;
    [SerializeField] private AudioClip wallCrossClip = null;
    [SerializeField] private AudioClip restartClip = null;
    [SerializeField] private AudioClip gameOverClip = null;
    [SerializeField] private AudioClip levelUpClip = null;

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

    public void ResumeBackgroundSound()
    {
        backgroundAudioSource.UnPause();
    }

    public void PauseBackgroundSound()
    {
        backgroundAudioSource.Pause();
    }

    public void StopBackgroundSound()
    {
        backgroundAudioSource.Stop();
    }
    
    public void PlayBackgroundSound()
    {
        backgroundAudioSource.Play();
    }

    public void PlayWallCross()
    {
        audioSource.clip = wallCrossClip;
        audioSource.Play();
    }

    public void PlayLevelUp()
    {
        audioSource.clip = levelUpClip;
        audioSource.Play();
    }

    public void PlayRestart()
    {
        audioSource.clip = restartClip;
        audioSource.Play();
    }

    public void PlayGameOver()
    {
        audioSource.clip = gameOverClip;
        audioSource.Play();
    }
}
