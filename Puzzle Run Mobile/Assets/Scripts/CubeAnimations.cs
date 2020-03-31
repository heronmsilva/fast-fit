using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeAnimations : MonoBehaviour
{
    private Animator _anim;

    private void Start()
    {
        _anim = this.gameObject.GetComponent<Animator>();
        _anim.SetFloat("Speed", GameManager.Instance.AnimationSpeed);
    }

    public void Fade()
    {
        StartCoroutine(PlayAnimation("CubeFade"));
    }

    IEnumerator PlayAnimation(string animation)
    {
        float delay = GameManager.Instance.AnimationDelay;
        yield return new WaitForSeconds(delay);
        _anim.Play(animation);
    }
}
