using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTo : MonoBehaviour
{
    public float speed;
    public Vector3 waypoint;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoint, Time.deltaTime * speed);
    }
}
