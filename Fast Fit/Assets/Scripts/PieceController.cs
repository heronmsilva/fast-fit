﻿using UnityEngine;

public class PieceController : MonoBehaviour
{
    [SerializeField] private float moveDeltaTime = .1f;

    private Joystick joystick;
    private float lastMove;
    private float isFlipped = 1;
    private float rotationOffset = .1f; // added since rotation slightly changes position

    public float LastMove { get { return lastMove; } }

    private void Start()
    {
        joystick = FindObjectOfType<DynamicJoystick>();
            
        lastMove = Time.time;
    }

    private void Update()
    {
        if (GameManager.Instance.IsGameOver || GameManager.Instance.IsPaused || GameManager.Instance.IsWallTooClose()) return;

        if (Time.time - lastMove > moveDeltaTime)
        {
            if (joystick && Mathf.Abs(joystick.Horizontal) > .5f)
            {
                this.transform.position += Vector3.right * Mathf.Sign(joystick.Horizontal);
                lastMove = Time.time;
            }
            if (joystick && Mathf.Abs(joystick.Vertical) > .5f)
            {
                this.transform.position += Vector3.up * Mathf.Sign(joystick.Vertical);
                lastMove = Time.time;
            }
        }
        
        FixIfOutOfBounds();
    }

    public void Translate(Vector3 position)
    {
        this.transform.position = new Vector3(Mathf.Round(position.x), Mathf.Round(position.y), position.z);
    }

    public void FlipUp()
    {
        Vector3 eulerAngles = this.transform.eulerAngles;
        eulerAngles += Vector3.right * 180;
        this.transform.eulerAngles = eulerAngles;
        // Single is inverted in order to
        // rotate in the correct orientation
        // once the piece has been flipped
        isFlipped = -1 * isFlipped;
    }

    public void FlipRight()
    {
        Vector3 eulerAngles = this.transform.eulerAngles;
        eulerAngles += Vector3.up * 180;
        this.transform.eulerAngles = eulerAngles;
        // Single is inverted in order to
        // rotate in the correct orientation
        // once the piece has been flipped
        isFlipped = -1 * isFlipped;
    }

    public void RotateLeft()
    {
        Vector3 eulerAngles = this.transform.eulerAngles;
        eulerAngles += Vector3.forward * 90 * isFlipped;
        this.transform.eulerAngles = eulerAngles;
    }

    public void RotateRight()
    {
        Vector3 eulerAngles = this.transform.eulerAngles;
        eulerAngles += Vector3.forward * -90 * isFlipped;
        this.transform.eulerAngles = eulerAngles;
    }

    // If the piece is moved out of the wall bounds
    // it's brought back within
    private void FixIfOutOfBounds()
    {
        Vector2 minXY = GameManager.Instance.MinXY;
        Vector2 maxXY = GameManager.Instance.MaxXY;
        
        foreach (Transform container in this.transform)
        {
            if (container.position.x < minXY.x - rotationOffset) this.transform.position += Vector3.right;
            if (container.position.x > maxXY.x + rotationOffset) this.transform.position -= Vector3.right;
            if (container.position.y < minXY.y - rotationOffset) this.transform.position += Vector3.up;
            if (container.position.y > maxXY.y + rotationOffset) this.transform.position -= Vector3.up;
        }
    }
}
