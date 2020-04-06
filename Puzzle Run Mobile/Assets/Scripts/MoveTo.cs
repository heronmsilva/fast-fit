using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTo : MonoBehaviour
{
    private bool concluded = false;
    private float speed;
    private Vector3 waypoint;

    public bool IsConcluded { get { return concluded; } }

    private void Update()
    {
        concluded = this.transform.position == waypoint;

        this.transform.position = Vector3.MoveTowards(
            this.transform.position, 
            waypoint, 
            Time.deltaTime * speed
        );
    }

    public void SetSpeed(float value)
    {
        speed = value;
    }

    public void SetWaypoint(Vector3 point)
    {
        waypoint = point;
    }
}
