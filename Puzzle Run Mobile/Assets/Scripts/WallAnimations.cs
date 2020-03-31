using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallAnimations : MonoBehaviour
{
    public void Fade()
    {
        foreach (Transform cube in this.transform)
        {
            cube.gameObject.GetComponent<CubeAnimations>().Fade();
        }
    }
}
