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

    IEnumerator PlayAnimation(string animation)
    {
        float delay = GameManager.Instance.AnimationDelay;
        yield return new WaitForSeconds(delay);
        _anim.Play(animation);
    }
}
