﻿using UnityEngine;

public class TimedDestructor : MonoBehaviour
{
    public float time = 1f;

    private void Start()
    {
        Destroy(this.gameObject, time);
    }
}
