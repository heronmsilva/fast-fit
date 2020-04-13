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

    public void IncreaseAnimSpeed(float speed)
    {
        anim.SetFloat("Speed", speed);
        foreach (Transform cube in this.transform)
        {
            cube.gameObject.GetComponent<CubeAnimations>().IncreaseAnimSpeed(speed);
        }
    }

    public void None()
    {

    }
    
    public void Fade()
    {
        foreach (Transform cube in this.transform)
        {
            cube.gameObject.GetComponent<CubeAnimations>().Fade();
        }
    }

    public void DelayedFade()
    {
        foreach (Transform cube in this.transform)
        {
            cube.gameObject.GetComponent<CubeAnimations>().DelayedFade();
        }
    }

    public void RotateX()
    {
        int i = Random.Range(0, xAnimations.Count);
        anim.Play(xAnimations[i]);
    }

    public void RotateY()
    {
        int i = Random.Range(0, yAnimations.Count);
        anim.Play(yAnimations[i]);
    }

    public void RotateXY()
    {
        int i = Random.Range(0, xyAnimations.Count);
        anim.Play(xyAnimations[i]);
    }

    public void DelayedFadeRotateX()
    {
        DelayedFade();
        RotateX();
    }

    public void DelayedFadeRotateY()
    {
        DelayedFade();
        RotateY();
    }

    public void DelayedFadeRotateXY()
    {
        DelayedFade();
        RotateXY();
    }
}
