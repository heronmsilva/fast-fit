using UnityEngine;

public class CubeCollider : MonoBehaviour
{
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag != "Piece")
        {
            GameManager.Instance.GameOver();   
        }
    }
}
