using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeAnimations : MonoBehaviour
{
    public void Fade()
    {
        StartCoroutine(PlayAnimation("CubeFade"));
    }

    IEnumerator PlayAnimation(string name)
    {
        float delay = GameManager.Instance.AnimationDelay;
        float speed = GameManager.Instance.AnimationSpeed;
        
        yield return new WaitForSeconds(delay);
        
        this.GetComponent<Animator>().SetFloat("Speed", speed);
        this.GetComponent<Animator>().Play(name);
    }
}
