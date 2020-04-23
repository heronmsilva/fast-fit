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
        if (this.transform.position == waypoint)
            StartCoroutine(SetConclusion());

        this.transform.position = Vector3.MoveTowards(
            this.transform.position, 
            waypoint, 
            Time.deltaTime * speed
        );
    }

    private IEnumerator SetConclusion()
    {
        yield return new WaitForSeconds(0.1f);

        concluded = true;
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
