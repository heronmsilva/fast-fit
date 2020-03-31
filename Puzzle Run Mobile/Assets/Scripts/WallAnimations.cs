using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallAnimations : MonoBehaviour
{
    private Animator _anim;
    
    private List<string> xAnimations = new List<string>() { "WallRotateX", "WallRotateX-" };
    private List<string> yAnimations = new List<string>() { "WallRotateY", "WallRotateY-" };
    private List<string> xyAnimations = new List<string>() { "WallRotateXY", "WallRotateX-Y", "WallRotateX-Y-", "WallRotateXY-" };

    private void Start()
    {
        _anim = this.gameObject.GetComponent<Animator>();
        _anim.SetFloat("Speed", GameManager.Instance.AnimationSpeed);
    }
    
    public void Fade()
    {
        foreach (Transform cube in this.transform)
        {
            cube.gameObject.GetComponent<CubeAnimations>().Fade();
        }
    }

    public void RotateX()
    {
        int i = Random.Range(0, xAnimations.Count);
        StartCoroutine(PlayAnimation(xAnimations[i]));
    }

    public void RotateY()
    {
        int i = Random.Range(0, yAnimations.Count);
        StartCoroutine(PlayAnimation(yAnimations[i]));
    }

    public void RotateXY()
    {
        int i = Random.Range(0, xyAnimations.Count);
        StartCoroutine(PlayAnimation(xyAnimations[i]));
    }

    // Random should play none, fade and/or any rotation
    // a 50% chance will be set for each of the cases
    public void RandomAnims()
    {
        int animChance = GameManager.Instance.AnimationChance;
        int shouldPlay = Random.Range(1, 101);
        if (shouldPlay < animChance)
        {
            int shouldFade = Random.Range(1, 101);
            if (shouldFade < animChance)
                Fade();
            int shouldRotate = Random.Range(1, 101);
            if (shouldRotate < animChance)
            {
                List<string> animations = new List<string>();
                animations.AddRange(xAnimations);
                animations.AddRange(xAnimations);
                animations.AddRange(yAnimations);
                animations.AddRange(yAnimations);
                animations.AddRange(xyAnimations);
                int i = Random.Range(0, animations.Count);
                StartCoroutine(PlayAnimation(animations[i]));
            }
        }
    }

    IEnumerator PlayAnimation(string animation)
    {
        float delay = GameManager.Instance.AnimationDelay;
        yield return new WaitForSeconds(delay);
        _anim.Play(animation);
    }
}
