using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallAnimations : MonoBehaviour
{
    private Animator _anim;
    
    private List<string> xAnimations = new List<string>() { "WallRotateX", "WallRotateX-" };

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

    IEnumerator PlayAnimation(string animation)
    {
        float delay = GameManager.Instance.AnimationDelay;
        yield return new WaitForSeconds(delay);
        _anim.Play(animation);
    }
}
