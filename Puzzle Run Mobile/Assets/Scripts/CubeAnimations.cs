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
        anim.Play("CubeFade");
    }

    public void DelayedFade()
    {
        anim.Play("CubeDelayedFade");
    }
}
