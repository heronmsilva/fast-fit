using System.Collections;
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

    public bool IsClose()
    {
        return transform.position.z - waypoint.z < 0.5f;
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
