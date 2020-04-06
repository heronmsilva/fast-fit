using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeAnimations : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
        anim.SetFloat("Speed", GameManager.Instance.GetAnimationSpeed());
    }

    public void Fade()
    {
        StartCoroutine(PlayAnimation("CubeFade"));
    }

    IEnumerator PlayAnimation(string animation)
    {
        float delay = GameManager.Instance.GetAnimationDelay();
        yield return new WaitForSeconds(delay);
        anim.Play(animation);
    }
}
