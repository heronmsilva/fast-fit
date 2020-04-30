using UnityEngine;

public class CountDown : MonoBehaviour
{
    [SerializeField] private AudioClip countDownBip = null;

    private AudioSource audioSource;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void CountDownBip()
    {
        audioSource.PlayOneShot(countDownBip);
    }
}
