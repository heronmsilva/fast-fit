using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceController : MonoBehaviour
{
    [SerializeField] private float _moveDeltaTime = .1f;

    private Joystick joystick;
    private float lastMove;
    private Vector2 minXY, maxXY;
    private float isFlipped = 1;
    private float rotationOffset = .1f; // added since rotation slightly changes position

    private void Start()
    {
        joystick = FindObjectOfType<FixedJoystick>();
        if (! joystick)
            joystick = FindObjectOfType<FloatingJoystick>();
            
        lastMove = Time.time;
        
        minXY = GameManager.Instance.MinXY;
        maxXY = GameManager.Instance.MaxXY;
    }

    private void Update()
    {
        if (GameManager.Instance.IsGameOver) return;

        if (Time.time - lastMove > _moveDeltaTime)
        {
            if (Mathf.Abs(joystick.Horizontal) > .5f)
            {
                this.transform.position += Vector3.right * Mathf.Sign(joystick.Horizontal);
                lastMove = Time.time;
            }
            if (Mathf.Abs(joystick.Vertical) > .5f)
            {
                this.transform.position += Vector3.up * Mathf.Sign(joystick.Vertical);
                lastMove = Time.time;
            }
        }
        
        FixIfOutOfBounds();
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
        foreach (Transform container in this.transform)
        {
            if (container.position.x < minXY.x - rotationOffset) this.transform.position += Vector3.right;
            if (container.position.x > maxXY.x + rotationOffset) this.transform.position -= Vector3.right;
            if (container.position.y < minXY.y - rotationOffset) this.transform.position += Vector3.up;
            if (container.position.y > maxXY.y + rotationOffset) this.transform.position -= Vector3.up;
        }
    }
}
