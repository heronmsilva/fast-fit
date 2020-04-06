using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallAnimations : MonoBehaviour
{
    private Animator anim;
    
    private List<string> xAnimations = new List<string>() { "WallRotateX", "WallRotateX-" };
    private List<string> yAnimations = new List<string>() { "WallRotateY", "WallRotateY-" };
    private List<string> xyAnimations = new List<string>() { "WallRotateXY", "WallRotateX-Y", "WallRotateX-Y-", "WallRotateXY-" };

    private void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
        anim.SetFloat("Speed", GameManager.Instance.GetAnimationSpeed());
    }

    public void Play(string animation)
    {
        Invoke(animation, 0f);
    }

    private void None()
    {

    }
    
    private void Fade()
    {
        foreach (Transform cube in this.transform)
        {
            cube.gameObject.GetComponent<CubeAnimations>().Fade();
        }
    }

    private void RotateX()
    {
        int i = Random.Range(0, xAnimations.Count);
        StartCoroutine(PlayAnimation(xAnimations[i]));
    }

    private void RotateY()
    {
        int i = Random.Range(0, yAnimations.Count);
        StartCoroutine(PlayAnimation(yAnimations[i]));
    }

    private void RotateXY()
    {
        int i = Random.Range(0, xyAnimations.Count);
        StartCoroutine(PlayAnimation(xyAnimations[i]));
    }

    private void FadeRotateX()
    {
        Fade();
        RotateX();
    }

    private void FadeRotateY()
    {
        Fade();
        RotateY();
    }

    private void FadeRotateXY()
    {
        Fade();
        RotateXY();
    }

    private IEnumerator PlayAnimation(string animation)
    {
        float delay = GameManager.Instance.GetAnimationDelay();
        yield return new WaitForSeconds(delay);
        anim.Play(animation);
    }
}
