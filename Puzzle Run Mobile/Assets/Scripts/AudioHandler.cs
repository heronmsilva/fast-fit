using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    [SerializeField] private AudioSource backgroundAudioSource = null;
    [SerializeField] private AudioClip wallFitClip = null;
    [SerializeField] private AudioClip gameOverClip = null;
    [SerializeField] private AudioClip levelUpClip = null;
    [SerializeField] private AudioClip impactClip = null;

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

    public void PlayImpactSound()
    {
        audioSource.clip = impactClip;
        audioSource.Play();
    }

    public IEnumerator PlayWallFit(float delay)
    {
        yield return new WaitForSeconds(delay);

        audioSource.clip = wallFitClip;
        audioSource.Play();
    }

    public IEnumerator PlayLevelUp(float delay)
    {
        yield return new WaitForSeconds(delay);

        audioSource.clip = levelUpClip;
        audioSource.Play();
    }

    public void PlayGameOver()
    {
        audioSource.clip = gameOverClip;
        audioSource.Play();
    }
}
